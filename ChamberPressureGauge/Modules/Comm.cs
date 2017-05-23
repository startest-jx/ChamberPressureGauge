using System;
using System.Collections.Generic;
using System.IO;
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
        public event EventHandle DataReceived;  // 用于让外部引用处理接收到的数据
        protected byte[] ReveivedBuffer;
        protected Mutex BufferLock = new Mutex();
        protected bool LengthSwitch = false;  // 长度校验开关
        protected int TempReceiveLength = 0;  // 用于上次未收全情况下更改接收长度
        public Comm(string host, int port, bool CheckLength)
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
        protected void Read(object obj)  // 接收线程
        {
            while (KeepReading)
            {
                int bytes = TempReceiveLength == 0 || !LengthSwitch ? (int)obj : TempReceiveLength;
                if (_IsConnected)
                {
                    byte[] readBuffer = new byte[bytes];
                    try
                    {
                        int count = _Socket.Receive(readBuffer);
                        TempReceiveLength = bytes - count;
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
        protected bool StartReading(int bytes)  // 开始监听，启动接收线程
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
        public CtrlPanel(string IP, int Port) : base(IP, Port, false)
        {

        }
        public bool StartRead()
        {
            return StartReading(16);
        }
        public string SendCmd(string send, bool rtExist = false, int TimeOut = -1)
        {
            string FormatSend = string.Format("#{0}\n", send);
            byte[] SendBytes = Encoding.Default.GetBytes(FormatSend);
            Send(SendBytes, SendBytes.Length, 0);
            string ReturnString = null;
            long PreSec = DateTime.Now.ToBinary();
            long CurSec = DateTime.Now.ToBinary();
            while (rtExist && ReturnString == null && (CurSec - PreSec <= TimeOut || TimeOut < 0))
            {
                ReturnString = ReadReceived();
            }
            return ReturnString;
        }
        public string ReadReceived()
        {
            BufferLock.WaitOne();
            if (ReveivedBuffer != null)
            {
                string str = Encoding.Default.GetString(ReveivedBuffer);
                if (str[0] == 0x23 && str[str.Length - 1] == 0x0A)
                {
                    ReveivedBuffer = null;  // 清除原有接收数据
                    BufferLock.ReleaseMutex();
                    return str.Substring(1, str.Length - 2);
                }
            }
            BufferLock.ReleaseMutex();
            return null;
        }
        public void SelfTest()
        {
            SendCmd("SELFTEST");
        }
        public void SelfTest(bool IsSuccess)
        {
            if (IsSuccess)
                SendCmd("TESTPASSED");
            else
                SendCmd("TESTFAILED");
        }
        public bool CheckChannelStatus(ref Channel[] Channels)
        {
            //bool[] ChannelStatus = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false, };
            string ChannelStatusString = SendCmd("LINESTATUE", true, 500);
            if (ChannelStatusString != null)
            {
                for (int i = 0; i < ChannelStatusString.Length; i++)
                {
                    if (ChannelStatusString[i] == '0')
                    {
                        Channels[i].DeviceExist = true;
                    }
                    else
                    {
                        Channels[i].DeviceExist = false;
                    }
                }
                return true;
            }
            return false;
        }
        public bool CheckClockStatus()
        {
            string ClockStatus = SendCmd("CLOCKSTA", true);
            if (ClockStatus == "CLKSUCCEED")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            SendCmd("RESET");
        }
    }
    public class DgtlPanel : Comm
    {
        private bool IsNewData = false;  // 确保不会记录重复数据
        private Mutex DataLock = new Mutex();
        public ushort[] CurrentData = new ushort[16];
        public DgtlPanel(string IP, int Port) : base(IP, Port, true)
        {

        }
        public void DataUpdate(byte[] readBuffer, int offset, int length)  // 接收采集板发来的16进制数据，并将其转换成双字节数组
        {
            if (length < 1024)  // 丢弃错误数据
            {
                return;
            }
            for (int BufferIndex = 0; BufferIndex < length; BufferIndex += 32)
            {
                string LogLine = "";
                var DataArray = new ushort[16];
                for (int ArrayIndex = 0; ArrayIndex < 16; ArrayIndex++)
                {
                    DataArray[ArrayIndex] = (ushort)((readBuffer[BufferIndex + 2 * ArrayIndex + 1] << 8) | readBuffer[BufferIndex + 2 * ArrayIndex]);
                    LogLine += DataArray[ArrayIndex].ToString() + " ";
                }
                DataLock.WaitOne();
                CurrentData = DataArray;
                IsNewData = true;
                DataLock.ReleaseMutex();
            }
        }
        public bool StartRead()
        {
            return StartReading(1024);
        }
        public void Reset()
        {
            byte[] Bytes = { 0x00, 0x01, 0x02, 0x03 };
            Send(Bytes, 0, Bytes.Length);
            //DataLock.WaitOne();
            //DataStock.Clear();
            //DataLock.ReleaseMutex();
        }
        public void StartReceiving()
        {
            byte[] Bytes = { 0xFF, 0xFE, 0x00, 0x01, 0x01 };
            Send(Bytes, 0, Bytes.Length);
        }
        public void StopReceiving()
        {
            byte[] Bytes = { 0xFF, 0xFE, 0x00, 0x01, 0x00 };
            Send(Bytes, 0, Bytes.Length);
        }
        public void SetGroupCount()
        {
            byte[] Bytes = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x09, 0x01, 0x10, 0x00, 0x14, 0x00, 0x01, 0x02, 0x00, 0x20 };
            Send(Bytes, 0, Bytes.Length);
        }
        public void StartPicking()
        {
            byte[] Bytes = { 0xFF, 0xFD, 0x00, 0x01, 0x01 };
            Send(Bytes, 0, Bytes.Length);
        }
        public void CheckChannelStatus(ref Channel[] Channels)
        {
            List<ushort[]> DataStock = new List<ushort[]>();
            // 接收1秒钟的数据
            long PreSec = DateTime.Now.ToBinary();
            long CurSec = DateTime.Now.ToBinary();
            while (CurSec - PreSec < 1000)
            {
                if (IsNewData)
                {
                    DataLock.WaitOne();
                    DataStock.Add(CurrentData);
                    IsNewData = false;
                    DataLock.ReleaseMutex();
                }
                CurSec = DateTime.Now.ToBinary();
            }
            //bool[] ChannelStatus = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            long[] ChannelValueSum = new long[Channels.Length];
            for (int i = 0; i < Channels.Length; i++)
                ChannelValueSum[i] = 0;
            foreach (ushort[] DataArray in DataStock)
            {
                ChannelValueSum[0] += DataArray[9];
                ChannelValueSum[1] += DataArray[10];
                ChannelValueSum[2] += DataArray[11];
                ChannelValueSum[3] += DataArray[12];
                ChannelValueSum[4] += DataArray[13];
                ChannelValueSum[5] += DataArray[14];
                ChannelValueSum[6] += DataArray[0];
                ChannelValueSum[7] += DataArray[1];
                ChannelValueSum[8] += DataArray[2];
                ChannelValueSum[9] += DataArray[3];
            }
            for (int i = 0; i < Channels.Length; i ++)
            {
                if (ChannelValueSum[i] > 52000 * DataStock.Count)
                {
                    Channels[i].Health = true;
                }
                else
                {
                    Channels[i].Health = false;
                }
            }
        }
        public void GetCurrentChannelData(ref Channel[] Channels)
        {
            for (int i = 0; i < 6; i ++)
            {
                DataLock.WaitOne();
                Channels[i].CurrentData = (Convert.ToDouble(CurrentData[i + 9]) * Math.Pow(2, -20) * 25 - 0.25)
                    * Channels[i].Range + Channels[i].Calibration;
                DataLock.ReleaseMutex();
            }
        }
    }

}
