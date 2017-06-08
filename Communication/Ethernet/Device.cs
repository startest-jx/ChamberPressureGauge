using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Communication.Ethernet
{
    public class Device : Base.Device  // 网口设备
    {
        private IPAddress _IP;
        private IPEndPoint _IPE;
        private Socket _Socket;
        bool _IsConnected;
        protected Thread ReadThread;  // 连接线程，接收线程
        public volatile bool KeepReading;  // 控制接收线程
        public delegate void EventHandle(byte[] readBuffer, int offset, int length);
        public event EventHandle DataReceived;  // 用于让外部引用处理接收到的数据
        protected byte[] ReveivedBuffer;
        protected Mutex BufferLock = new Mutex();
        protected bool LengthSwitch = false;  // 长度校验开关
        protected int TempReceiveLength = 0;  // 用于上次未收全情况下更改接收长度
        public Device(string host, int port, 
                                bool CheckLength = false, 
                                int BufferSize = 1024, 
                                int ReceiveTimeOut = 500) : base(Base.DeviceType.Ethernet)
        {
            _IP = IPAddress.Parse(host);
            _IPE = new IPEndPoint(_IP, port);
            _IsConnected = false;
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _Socket.ReceiveTimeout = ReceiveTimeOut;
            _Socket.ReceiveBufferSize = BufferSize;
        }
        public override bool Open()  // 连接端口
        {
            try
            {
                _Socket.Connect(_IPE);
            }
            catch
            {
                _IsConnected = false;
                return false;
            }
            _IsConnected = true;
            return true;
        }
        public override bool IsOpen()  // 判断是否打开
        {
            return _IsConnected;
        }
        public override void Close()  // 关闭端口
        {
            StopReading();
            _Socket.Close();
            _IsConnected = false;
        }
        public override bool Send(byte[] send, int offSet, int count)  // 发送消息
        {
            if (IsOpen())
            {
                _Socket.Send(send, send.Length, 0);
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void Read(object bytes)  // 接收线程
        {
            //int PreIndex = 0;
            //int TotalLength = (int)obj;
            int my_bytes = (int)bytes;
            while (KeepReading)
            {
                //int bytes = PreIndex == 0 || !LengthSwitch ? TotalLength : TotalLength - PreIndex;
                if (_IsConnected)
                {
                    byte[] readBuffer = new byte[my_bytes];
                    try
                    {
                        int count = 0;
                        if (LengthSwitch)
                        {
                            count = _Socket.Receive(readBuffer, 0, my_bytes, SocketFlags.None);
                            while (count < my_bytes)
                            {
                                count += _Socket.Receive(readBuffer, count, my_bytes - count, SocketFlags.None);
                            }
                        }
                        else
                        {
                            count = _Socket.Receive(readBuffer);
                        }
                        
                        ReveivedBuffer = new byte[count];
                        BufferLock.WaitOne();
                        for (int i = 0; i < count; i++)
                        {
                            ReveivedBuffer[i] = readBuffer[i];
                        }
                        BufferLock.ReleaseMutex();
                        if (DataReceived != null)
                        {
                            DataReceived(readBuffer, 0, count);
                            readBuffer = null;
                        }
                        //Thread.Sleep(100);
                    }
                    catch (SocketException)
                    {
                        continue;
                    }

                }
            }
        }
        public override bool StartReading(int bytes)  // 开始监听，启动接收线程
        {
            if (!KeepReading)
            {
                KeepReading = true;
                ReadThread = new Thread(new ParameterizedThreadStart(Read));
                ReadThread.Start(bytes);
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool StopReading()  // 结束监听，关闭接收线程
        {
            if (KeepReading)
            {
                KeepReading = false;
                ReadThread.Join();
                ReadThread = null;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
