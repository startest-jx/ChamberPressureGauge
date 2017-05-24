using System;
using System.Collections.Generic;
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
        public delegate void ChangeStatusFun(ConnectStatus Status);
        public event ChangeStatusFun ChangeStatus;
        private Channel[] _Channels;  // 通道
        public Channel[] Channels { set { _Channels = value; } get { return _Channels; } }
        public Slaver(ChangeStatusFun ChangeStatus)
        {
            this.ChangeStatus = ChangeStatus;
            _Channels = new Channel[12];
            for (int i = 0; i < _Channels.Length; i ++)
            {
                _Channels[i] = new Channel(string.Format("{0}通道<{1}>", i < 6 ? "压力" : "数字量/计时", i < 6 ? i + 1 : i - 5),
                    i < 6 ? ChannelType.Pressure : ChannelType.Digital);
            }
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
            _CtrlPanel.StopReading();
            _CtrlPanel.Close();
            _CtrlPanel = null;
            _DgtlPanel.DataReceived -= new Comm.EventHandle(_DgtlPanel.DataUpdate);
            _DgtlPanel.StopReading();
            _DgtlPanel.Close();
            _DgtlPanel = null;
        }
        public bool CheckClockStatus()
        {
            return _CtrlPanel.CheckClockStatus();
        }
        public void StartReceiving()
        {
            _DgtlPanel.StartReceiving();
        }
        public void Reset()
        {
            _CtrlPanel.Reset();
        }
        public void UpdateChannelHealth()
        {
            _DgtlPanel.CheckChannelStatus(ref _Channels);
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
                if (Channels[i].Health)
                {
                    Channels[i].Health = true;
                }
                else
                {
                    Channels[i].Health = false;
                }
                if (Channels[i].DeviceExist)
                {
                    Channels[i].DeviceExist = true;
                    Channels[i].Control.RefreshData();  // 设备存在才刷新数据
                }
                else
                {
                    Channels[i].DeviceExist = false;
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
        public double MeasuringTime { set; get; }
        public void SelfTest()
        {
            _CtrlPanel.SelfTest();
        }
        public void SelfTest(bool Result)
        {
            _CtrlPanel.SelfTest(Result);
        }
        public void Start()
        {

        }
    }
}
