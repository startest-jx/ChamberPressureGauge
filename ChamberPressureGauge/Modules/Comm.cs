using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChamberPressureGauge.Modules
{
    public class Comm  // 通用网口通信
    {
        private IPAddress _IP;
        private IPEndPoint _IPE;
        private Socket _Socket;
        bool _IsConnected;
        protected Thread ReadThread;  // 连接线程，接收线程
        public volatile bool KeepReading;  // 控制接收线程
        public delegate void EventHandle(byte[] readBuffer, int offset, int length);
        public event EventHandle DataReceived;
        public Comm(string host, int port)
        {
            _IP = IPAddress.Parse(host);
            _IPE = new IPEndPoint(_IP, port);
            _IsConnected = false;
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _Socket.ReceiveTimeout = 500;
        }
        public bool Open()  // 连接端口
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
        void Connect(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);
                _IsConnected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _IsConnected = false;
            }
            finally
            {

            }
        }
        public bool IsOpen()  // 判断是否打开
        {
            return _IsConnected;
        }
        public void Close()  // 关闭端口
        {
            StopReading();
            _Socket.Close();
            _IsConnected = false;
        }
        public bool Send(byte[] send, int offSet, int count)  // 发送消息
        {
            _Socket.Send(send, send.Length, 0);
            return true;
        }
        protected void Read(object obj)  // 接收线程
        {
            long bytes = (long)obj;
            while (KeepReading)
            {
                if (_IsConnected)
                {
                    byte[] readBuffer = new byte[bytes];
                    try
                    {
                        int count = _Socket.Receive(readBuffer);
                        if (DataReceived != null)
                        {
                            DataReceived(readBuffer, 0, count);
                            readBuffer = null;
                        }
                        Thread.Sleep(100);
                    }
                    catch (SocketException)
                    {
                        continue;
                    }

                }
            }
        }
        protected bool StartReading(long bytes)  // 开始监听，启动接收线程
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
        public bool StopReading()  // 结束监听，关闭接收线程
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

    public class CtrlPanel : Comm
    {
        public CtrlPanel() : base ("192.168.1.178", 4001)
        {

        }
        public bool StartRead()
        {
            return StartReading(16);
        }
        public new bool SendCmd(string send)
        {
            string FormatSend = string.Format("#{0}\n", send);
            byte[] SendBytes = Encoding.Default.GetBytes(FormatSend);
            Send(SendBytes, SendBytes.Length, 0);
            return true;
        }
    }
    public class DgtlPanel : Comm
    {
        public DgtlPanel() : base("192.168.1.126", 8000)
        {

        }
        public bool StartRead()
        {
            return StartReading(32 * 2000);
        }
    }

}
