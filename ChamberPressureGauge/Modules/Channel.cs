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
        Measuring
    }
    public enum ChannelType  // 通道类型
    {
        Pressure,
        Digital,
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
        }
        public void SelfTest()
        {
            _CtrlPanel.SelfTest();
        }
        public void SelfTest(bool Result)
        {
            _CtrlPanel.SelfTest(Result);
        }
    }
    public class Channel  // 通道对象
    {
        public ChannelType _Type { set; get; }
        public string Name { set; get; }
        public bool Health { set; get; }
        public bool DeviceExist { set; get; }
        public int Range { set; get; }
        public double Calibration { set; get; }
        public double CurrentData { set; get; }
        public Channel(string Name, ChannelType Type)
        {
            this.Name = Name;
            _Type = Type;
        }
    }
    public class ChnLED : TextBox
    {
        public ChnLED()
        {
            ReadOnly = true;
            TabStop = false;
            TextAlign = HorizontalAlignment.Right;
        }
        public void Activate()
        {
            Enabled = true;
            //Text = "- DEVICE FOUND -";
        }
        public void Silenced()
        {
            Enabled = false;
            Text = "- NO DEVICE -";
        }
        public void MarkHealth()
        {
            BackColor = System.Drawing.Color.White;
        }
        public void MarkIll()
        {
            BackColor = System.Drawing.Color.Red;
        }
    }
}
