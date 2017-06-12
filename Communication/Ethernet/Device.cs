using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Communication.Ethernet
{
    public class Device : Base.Device  // 网口设备
    {
        private readonly IPEndPoint _ipe;
        private readonly Socket _socket;
        private bool _isConnected;
        protected Thread ReadThread;  // 连接线程，接收线程

        protected int ReceiveTimeOut
        {
            set => _socket.ReceiveTimeout = value;
            get => _socket. ReceiveTimeout;
        }
        protected int ReceiveBufferSize
        {
            set => _socket.ReceiveBufferSize = value;
            get => _socket.ReceiveBufferSize;
        }
        public volatile bool KeepReading;  // 控制接收线程
        public delegate void EventHandle(byte[] readBuffer, int offset, int length);
        public event EventHandle DataReceived;  // 用于让外部引用处理接收到的数据
        protected byte[] ReveivedBuffer;
        protected Mutex BufferLock = new Mutex();
        protected bool LengthSwitch = false;  // 长度校验开关
        protected int TempReceiveLength = 0;  // 用于上次未收全情况下更改接收长度
        public Device(string host, int port) : base(Base.DeviceType.Ethernet)
        {
            var ip = IPAddress.Parse(host);
            _ipe = new IPEndPoint(ip, port);
            _isConnected = false;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public override bool Open()  // 连接端口
        {
            try
            {
                _socket.Connect(_ipe);
            }
            catch
            {
                _isConnected = false;
                return false;
            }
            _isConnected = true;
            return true;
        }
        public override bool IsOpen()  // 判断是否打开
        {
            return _isConnected;
        }
        public override void Close()  // 关闭端口
        {
            StopReading();
            _socket.Close();
            _isConnected = false;
        }
        public override bool Send(byte[] send, int offSet, int count)  // 发送消息
        {
            if (!IsOpen())
                return false;
            _socket.Send(send, send.Length, 0);
            return true;
        }
        protected override void Read(object bytes)  // 接收线程
        {
            //int PreIndex = 0;
            //int TotalLength = (int)obj;
            var myBytes = (int)bytes;
            while (KeepReading)
            {
                //int bytes = PreIndex == 0 || !LengthSwitch ? TotalLength : TotalLength - PreIndex;
                if (!_isConnected)
                    continue;
                var readBuffer = new byte[myBytes];
                try
                {
                    int count;
                    if (LengthSwitch)
                    {
                        count = _socket.Receive(readBuffer, 0, myBytes, SocketFlags.None);
                        while (count < myBytes)
                        {
                            count += _socket.Receive(readBuffer, count, myBytes - count, SocketFlags.None);
                        }
                    }
                    else
                    {
                        count = _socket.Receive(readBuffer);
                    }
                        
                    ReveivedBuffer = new byte[count];
                    BufferLock.WaitOne();
                    for (var i = 0; i < count; i++)
                    {
                        ReveivedBuffer[i] = readBuffer[i];
                    }
                    BufferLock.ReleaseMutex();
                    DataReceived?.Invoke(readBuffer, 0, count);
                    //Thread.Sleep(100);
                }
                catch (SocketException)
                {
                }
            }
        }
        public override bool StartReading(int bytes)  // 开始监听，启动接收线程
        {
            if (KeepReading)
                return false;
            KeepReading = true;
            ReadThread = new Thread(Read);
            ReadThread.Start(bytes);
            return true;
        }
        public override bool StopReading()  // 结束监听，关闭接收线程
        {
            if (!KeepReading)
                return false;
            KeepReading = false;
            ReadThread.Join();
            ReadThread = null;
            return true;
        }
    }
}
