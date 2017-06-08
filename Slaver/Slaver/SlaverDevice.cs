using Communication.Ethernet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using Slaver.Channel;
using Slaver.Panel;

namespace Slaver
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
    public class SlaverDevice  // 下位机
    {

        CommandPanel CommandPanel;
        DataPanel DataPanel;
        private ConnectStatus _Status;
        public ConnectStatus Status
        {
            set
            {
                _Status = value;
                ChangeStatus?.Invoke(_Status);
            }
            get { return _Status; }
        }
        public TriggerMode TriggerMode { set; get; }
        //private bool StopFlag = false;
        public delegate void ChangeStatusFun(ConnectStatus Status);
        public event ChangeStatusFun ChangeStatus;
        public delegate void LogFun(string LogInfo);
        public event LogFun Log;
        public delegate void DrawLinesFun(BaseChannel[] Channels);
        public event DrawLinesFun DrawLines;
        public delegate void StartCountDownFun(double value);
        public event StartCountDownFun StartCountDown;
        public delegate void NonParaFun();
        public NonParaFun CancelCountDown;

        public int TriggerInterval { set; get; }
        private BaseChannel[] _Channels;  // 通道
        public BaseChannel[] Channels { set { _Channels = value; } get { return _Channels; } }
        public SlaverDevice(LogFun Log, ChangeStatusFun ChangeStatus, DrawLinesFun DrawLines, StartCountDownFun StartCountDown)
        {
            this.ChangeStatus = ChangeStatus;
            this.Log = Log;
            this.DrawLines = DrawLines;
            this.StartCountDown = StartCountDown;
            _Channels = new BaseChannel[12];
            for (int i = 0; i < _Channels.Length; i++)
            {
                if (i < 6)
                {
                    _Channels[i] = new PressureChannel(string.Format("压力通道<{0}>", i + 1));
                }
                else if (i >=6 && i < 10)
                {
                    _Channels[i] = new DigitalChannel(string.Format("数字量/计时通道<{0}>", i - 5));
                }
                else if (i == 10)
                {
                    _Channels[i] = new SpeedChannel(string.Format("速度通道<{0}>", i - 9));
                }
                else
                {
                    _Channels[i] = new PressureChannel(string.Format("其他通道<{0}>", i - 10));
                }
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
                CommandPanel.StopReading();
                CommandPanel.Close();
                return false;
            }
            return true;
        }
        public bool CPOpen(string IP, int Port)
        {
            CommandPanel = new CommandPanel(IP, Port);
            CommandPanel.StartRead();
            return CommandPanel.Open();
        }
        public bool DPOpen(string IP, int Port)
        {
            DataPanel = new DataPanel(IP, Port);
            DataPanel.StartReading();
            DataPanel.DataReceived += new Device.EventHandle(DataPanel.DataUpdate);
            return DataPanel.Open();
        }
        //public void StartListening()
        //{
        //    CommandPanel.StartRead();
        //    //CommandPanel.DataReceived += new Comm.EventHandle(CmdStore);
        //    DataPanel.StartRead();
        //    DataPanel.DataReceived += new Comm.EventHandle(DataPanel.DataUpdate);
        //}
        //public void StopListening()
        //{
        //    //CommandPanel.DataReceived -= new Comm.EventHandle(CmdStore);
        //    CommandPanel.StopReading();
        //    DataPanel.DataReceived -= new Comm.EventHandle(DataPanel.DataUpdate);
        //    DataPanel.StopReading();
        //}
        public void Close()
        {
            Log("正在断开连接...");
            if (DataPanel != null)
            {
                DataPanel.DataReceived -= new Device.EventHandle(DataPanel.DataUpdate);
                DataPanel.StopReading();
                DataPanel.Close();
                DataPanel = null;
                Log("已断开数位板连接.");
            }
            if (CommandPanel != null)
            {
                CommandPanel.StopReading();
                CommandPanel.Close();
                CommandPanel = null;
                Log("已断开主控板连接.");
            }
            Thread.Sleep(500);
        }
        public bool CheckClockStatus()
        {
            Log("正在发送时钟检测命令...");
            bool result = CommandPanel.CheckClockStatus();
            if (result)
                Log("时钟状态正常.");
            else
                Log("时钟状态异常.");
            return result;
        }
        public void StartReceiving()
        {
            DataPanel.StartReceiving();
        }
        public void Reset()
        {
            Log("发送复位命令.");
            CommandPanel.Reset();
        }
        public void UpdateChannelHealth()
        {
            DataPanel.CheckChannelStatus(ref _Channels);
            for (int i = 0; i < _Channels.Length - 2; i++)
            {
                Log(string.Format("{0}: {1}.",
                    _Channels[i].Name,
                    _Channels[i].Health ? "正常" : "异常"));
            }
        }
        public bool UpdateChannelExist()
        {
            return CommandPanel.CheckChannelStatus(ref _Channels);
        }
        public void UpdateChannelData()
        {
            DataPanel.GetCurrentChannelData(ref _Channels);
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
            for (int i = StartIndex; i < EndIndex; i++)
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
            CommandPanel.SelfTest();
        }
        public void SelfTest(bool Result)
        {
            if (Result)
                Log("发送自检成功命令.");
            else
                Log("发送自检失败命令.");
            CommandPanel.SelfTest(Result);
        }
        public bool WaitTrigger(ref BackgroundWorker sender, ref DoWorkEventArgs e)
        {
            int TriggerIndex = GetTriggerChannel(ChannelType.Pressure);
            if (TriggerIndex == -1)
            {
                Log("需要设置触发通道.");
                return false;
            }
            BaseChannel TriggerChannel = Channels[TriggerIndex];
            double Increment = 0;
            int MapIndex = -1;
            if (TriggerIndex < 6)
            {
                MapIndex = TriggerIndex + 9;
            }
            else if (TriggerIndex >= 6 && TriggerIndex < 10)
            {
                MapIndex = TriggerIndex - 6;
            }
            //WaitTriggerSwitch = true;
            while (Increment < TriggerChannel.TriggerIncrement)
            {
                if (sender.CancellationPending)
                {
                    e.Cancel = true;
                    return false;
                }
                Increment = TriggerChannel.Formula(DataPanel.CurAverageData[MapIndex]);
                Thread.Sleep(5);
            }
            return true;
        }
        public void StartMeasuring(ref BackgroundWorker sender, ref DoWorkEventArgs e)
        {
            //StopFlag = false;
            if (TriggerMode == TriggerMode.Auto)
            {
                //int TriggerIndex = GetTriggerChannel(ChannelType.Pressure);
                //if (TriggerIndex == -1)
                //{
                //    Log("需要设置触发通道.");
                //    return;
                //}
                Log("等待触发...");
                //Channels[TriggerIndex].WaitTriggerSwitch = !StopFlag;
                if (WaitTrigger(ref sender, ref e))
                {
                    StartCountDown(MeasuringTime / 1000);
                    Log(string.Format("{0}触发.", Channels[GetTriggerChannel(ChannelType.Pressure)].Name));
                    if (Measure(ref sender, ref e))
                    {
                        Log("正在绘制图表...");
                        DrawLines(Channels);
                        Log("正在显示图表...");
                    }
                }
            }
            else if (TriggerMode == TriggerMode.manual)
            {
                StartCountDown(MeasuringTime / 1000);
                if (Measure(ref sender, ref e))
                {
                    Log("正在绘制图表...");
                    DrawLines(Channels);
                    Log("正在显示图表...");
                }
            }
        }
        //public void StopMeasuring()
        //{
        //    StopFlag = true;
        //    int TriggerIndex = GetTriggerChannel(ChannelType.Pressure);
        //    Channels[TriggerIndex].WaitTriggerSwitch = false;
        //    Log("正在取消当前测量...");
        //}
        private bool Measure(ref BackgroundWorker sender, ref DoWorkEventArgs e)
        {
            Log("正在记录数据...");
            //var ByteData = DataPanel.DataStoreByTime(MeasuringTime);
            var ByteData = DataPanel.DataStoreByCount(Convert.ToInt64(MeasuringTime * 6.4));
            Log("正在处理数据...");
            foreach (var Item in Channels)
            {
                if (sender.CancellationPending)
                {
                    e.Cancel = true;
                    return false;
                }
                Item.MeasuringData = new List<double>();
            }
            foreach (var Item in ByteData)
            {
                if (sender.CancellationPending)
                {
                    e.Cancel = true;
                    return false;
                }
                for (int i = 0; i < 6; i++)
                {
                    if (sender.CancellationPending)
                    {
                        e.Cancel = true;
                        return false;
                    }
                    _Channels[i].MeasuringData.Add(Channels[i].Formula(Item[i + 9]));
                }
                for (int i = 6; i < 10; i++)
                {
                    if (sender.CancellationPending)
                    {
                        e.Cancel = true;
                        return false;
                    }
                    _Channels[i].MeasuringData.Add(Channels[i].Formula(Item[i - 6]));
                }
            }
            Log("数据处理完毕.");
            return true;
        }
    }
}
