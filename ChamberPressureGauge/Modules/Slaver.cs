using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace ChamberPressureGauge.Modules
{

    public enum ConnectStatus  // 连接状态
    {
        Disconnected,
        Connecting,
        Connected,
        Measuring,
    }
    public enum TriggerMode  // 触发方式
    {
        Auto,
        manual,
        External,
    }
    public class Slaver  // 下位机
    {
        
        CtrlPanel _CtrlPanel;
        DgtlPanel _DgtlPanel;
        private ConnectStatus _Status;
        public ConnectStatus Status
        {
            set
            {
                _Status = value;
                ChangeStatus?.Invoke(_Status);
            }
            get{ return _Status; }
        }
        public TriggerMode TriggerMode { set; get; }
        private bool StopFlag = false;
        public delegate void ChangeStatusFun(ConnectStatus Status);
        public event ChangeStatusFun ChangeStatus;
        public delegate void LogFun(string LogInfo);
        public event LogFun Log;
        public delegate void DrawLinesFun(Channel[] Channels);
        public event DrawLinesFun DrawLines;
        private Channel[] _Channels;  // 通道
        public Channel[] Channels { set { _Channels = value; } get { return _Channels; } }
        public Slaver(LogFun Log, ChangeStatusFun ChangeStatus, DrawLinesFun DrawLines)
        {
            this.ChangeStatus = ChangeStatus;
            this.Log = Log;
            this.DrawLines = DrawLines;
            _Channels = new Channel[12];
            for (int i = 0; i < _Channels.Length; i ++)
            {
                _Channels[i] = new Channel(string.Format("{0}通道<{1}>", i < 6 ? "压力" : "数字量/计时", i < 6 ? i + 1 : i - 5),
                    i < 6 ? ChannelType.Pressure : ChannelType.Digital, Log);

            }
        }
        public bool Connect()
        {
            Log("正在连接主控板...");
            if (CPOpen("192.168.1.178", 4001))
            {
                Log("主控板连接成功.");
            }
            else
            {
                Log("主控板连接失败.");
                Status = ConnectStatus.Disconnected;

                return false;
            }
            Thread.Sleep(500);
            Log("正在连接数位板...");
            if (DPOpen("192.168.1.126", 8000))
            {
                Log("数位板连接成功.");
            }
            else
            {
                Log("数位板连接失败.");
                Status = ConnectStatus.Disconnected;
                _CtrlPanel.StopReading();
                _CtrlPanel.Close();
                return false;
            }
            return true;
        }
        public bool CPOpen(string IP, int Port)
        {
            _CtrlPanel = new CtrlPanel(IP, Port);
            _CtrlPanel.StartRead();
            return _CtrlPanel.Open();
        }
        public bool DPOpen(string IP, int Port)
        {
            _DgtlPanel = new DgtlPanel(IP, Port);
            _DgtlPanel.StartRead();
            _DgtlPanel.DataReceived += new Comm.EventHandle(_DgtlPanel.DataUpdate);
            return _DgtlPanel.Open();
        }
        //public void StartListening()
        //{
        //    _CtrlPanel.StartRead();
        //    //_CtrlPanel.DataReceived += new Comm.EventHandle(CmdStore);
        //    _DgtlPanel.StartRead();
        //    _DgtlPanel.DataReceived += new Comm.EventHandle(_DgtlPanel.DataUpdate);
        //}
        //public void StopListening()
        //{
        //    //_CtrlPanel.DataReceived -= new Comm.EventHandle(CmdStore);
        //    _CtrlPanel.StopReading();
        //    _DgtlPanel.DataReceived -= new Comm.EventHandle(_DgtlPanel.DataUpdate);
        //    _DgtlPanel.StopReading();
        //}
        public void Close()
        {
            Log("正在断开连接...");
            _DgtlPanel.DataReceived -= new Comm.EventHandle(_DgtlPanel.DataUpdate);
            _DgtlPanel.StopReading();
            _DgtlPanel.Close();
            _DgtlPanel = null;
            Log("已断开数位板连接.");
            _CtrlPanel.StopReading();
            _CtrlPanel.Close();
            _CtrlPanel = null;
            Log("已断开主控板连接.");
            Thread.Sleep(500);
        }
        public bool CheckClockStatus()
        {
            Log("正在发送时钟检测命令...");
            bool result = _CtrlPanel.CheckClockStatus();
            if (result)
                Log("时钟状态正常.");
            else
                Log("时钟状态异常.");
            return result;
        }
        public void StartReceiving()
        {
            _DgtlPanel.StartReceiving();
        }
        public void Reset()
        {
            Log("发送复位命令.");
            _CtrlPanel.Reset();
        }
        public void UpdateChannelHealth()
        {
            _DgtlPanel.CheckChannelStatus(ref _Channels);
            for (int i = 0; i < _Channels.Length - 2; i++)
            {
                Log(string.Format("{0}: {1}.",
                    _Channels[i].Name,
                    _Channels[i].Health ? "正常" : "异常"));
            }
        }
        public bool UpdateChannelExist()
        {
            return _CtrlPanel.CheckChannelStatus(ref _Channels);
        }
        public void UpdateChannelData()
        {
            _DgtlPanel.GetCurrentChannelData(ref _Channels);
            for (int i = 0; i < Channels.Length; i++)
            {
                if (Channels[i].DeviceExist == false)
                {
                    Channels[i].DeviceExist = false;
                }
                else
                {
                    Channels[i].DeviceExist = true;
                    Channels[i].RefreshData();  // 设备存在才刷新数据
                }
                if (Channels[i].Health)
                {
                    Channels[i].Health = true;
                }
                else
                {
                    Channels[i].Health = false;
                }
            }
        }
        public void SetTriggerChannel(int ChannelIndex)
        {
            int StartIndex = 0, EndIndex = 0;
            if (ChannelIndex < 6)
            {
                StartIndex = 0;
                EndIndex = 6;
            }
            else if (ChannelIndex >= 6 && ChannelIndex < 10)
            {
                StartIndex = 6;
                EndIndex = 10;
            }
            for (int i = StartIndex; i < EndIndex; i ++)
            {
                _Channels[i].IsTrigger = false;
            }
            _Channels[ChannelIndex].IsTrigger = true;
        }
        public int GetTriggerChannel(ChannelType ChannelType)
        {
            int StartIndex = 0, EndIndex = 0;
            if (ChannelType == ChannelType.Pressure)
            {
                StartIndex = 0;
                EndIndex = 6;
            }
            else if (ChannelType == ChannelType.Digital)
            {
                StartIndex = 6;
                EndIndex = 10;
            }
            for (int i = StartIndex; i < EndIndex; i++)
            {
                if (_Channels[i].IsTrigger)
                {
                    return i;
                }
            }
            return -1;
        }
        public int MeasuringTime { set; get; }
        public void SelfTest()
        {
            Log("发送自检命令.");
            _CtrlPanel.SelfTest();
        }
        public void SelfTest(bool Result)
        {
            if (Result)
                Log("发送自检成功命令.");
            else
                Log("发送自检失败命令.");
            _CtrlPanel.SelfTest(Result);
        }
        public void StartMeasuring()
        {
            StopFlag = false;
            if (TriggerMode == TriggerMode.Auto)
            {
                int TriggerIndex = GetTriggerChannel(ChannelType.Pressure);
                if (TriggerIndex == -1)
                {
                    Log("需要设置触发通道.");
                    return;
                }
                Log("等待触发...");
                Channels[TriggerIndex].WaitTriggerSwitch = !StopFlag;
                if (Channels[TriggerIndex].WaitTriggered(_DgtlPanel, TriggerIndex))
                {
                    Log(string.Format("{0}触发.", Channels[TriggerIndex].Name));
                    if(Measure())
                    {
                        Log("正在绘制图表...");
                        DrawLines(Channels);
                    }
                }
            }
            else if (TriggerMode == TriggerMode.manual)
            {
                if (Measure())
                {
                    Log("正在绘制图表...");
                    DrawLines(Channels);
                    Log("正在显示图表...");
                }
            }
        }
        public void StopMeasuring()
        {
            StopFlag = true;
            int TriggerIndex = GetTriggerChannel(ChannelType.Pressure);
            Channels[TriggerIndex].WaitTriggerSwitch = false;
            Log("正在取消当前测量...");
        }
        private bool Measure()
        {
            Log("正在记录数据...");
            var ByteData = _DgtlPanel.DataStoreByTime(MeasuringTime);
            Log("正在处理数据...");
            foreach (var Item in Channels)
            {
                if (StopFlag)
                {
                    return false;
                }
                Item.MeasuringData = new List<double>();
            }
            foreach (var Item in ByteData)
            {
                if (StopFlag)
                {
                    return false;
                }
                for (int i = 0; i < 6; i++)
                {
                    _Channels[i].MeasuringData.Add(Channels[i].GetActualValue(Item[i + 9]));
                }
                for (int i = 6; i < 10; i++)
                {
                    _Channels[i].MeasuringData.Add(Channels[i].GetActualValue(Item[i - 6]));
                }
            }
            Log("数据处理完毕.");
            return true;
        }
    }
}
