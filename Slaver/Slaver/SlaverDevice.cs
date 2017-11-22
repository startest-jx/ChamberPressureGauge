using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Newtonsoft.Json.Linq;
using Slaver.Channel;
using Slaver.Panel;
using Tools.Configuration;
using Tools.Log;

namespace Slaver.Slaver
{
    public enum ConnectStatus  // 连接状态
    {
        Disconnected,
        Connecting,
        Connected,
        Measuring,
        Error,
    }
    public enum TriggerMode  // 触发方式
    {
        Auto,
        Manual,
        External,
    }
    public class SlaverDevice  // 下位机
    {
        private CommandPanel _commandPanel;
        private DataPanel _dataPanel;
        private ConnectStatus _status;
        public ConnectStatus Status
        {
            set
            {
                _status = value;
                ChangeStatus?.Invoke(_status);
            }
            get => _status;
        }
        public TriggerMode TriggerMode { set; get; }

        public int PressureTriggerIndex
        {
            set => SetTriggerChannelIndex(value);
            get => GetTriggerChannelIndex(ChannelType.Pressure);
        }
        public int DigitalTriggerIndex
        {
            set => SetTriggerChannelIndex(value);
            get => GetTriggerChannelIndex(ChannelType.Digital);
        }
        public BaseChannel PressureTriggerChannel
        {
            set
            {
                var triggerIndex = GetTriggerChannelIndex(ChannelType.Pressure);
                Channels[triggerIndex] = value;
            }
            get
            {
                var triggerIndex = GetTriggerChannelIndex(ChannelType.Pressure);
                return triggerIndex == -1 ? null : Channels[triggerIndex];
            }
        }
        public BaseChannel DigitalTriggerChannel
        {
            set
            {
                var triggerIndex = GetTriggerChannelIndex(ChannelType.Digital);
                Channels[triggerIndex] = value;
            }
            get
            {
                var triggerIndex = GetTriggerChannelIndex(ChannelType.Digital);
                return triggerIndex == -1 ? null : Channels[triggerIndex];
            }
        }
        public Action<ConnectStatus> ChangeStatus;
        private Configuration _config;
        public Configuration Config
        {
            set
            {
                _config = value;
                var connectTable = (JObject)Config.ConfigTable["Connect"];
                CmdTable = (JObject)connectTable["CommandPanel"];
                DataTable = (JObject)connectTable["DataPanel"];
                _mappingRule = Config.MappingRule;
                var autoTrigger = (JObject) Config.Measure["AutoTrigger"];
                var manualTrigger = (JObject)Config.Measure["ManualTrigger"];
                AutoMeasuringTime = (int) autoTrigger["MeasureTime"];
                ManualMeasuringTime = (int)manualTrigger["MeasureTime"];
            }
            get => _config;
        }

        private JObject CmdTable { get; set; }

        private JObject DataTable { get; set; }

        private Hashtable _mappingRule;

        public Log Log{ set; get; }
        public Action<BaseChannel[]> DrawLines;
        public Action<double> StartCountDown;
        public Action CancelCountDown;

        //public int TriggerInterval { set; get; }
        private BaseChannel[] _channels;  // 通道
        public BaseChannel[] Channels
        {
            set => _channels = value;
            get => _channels;
        }
        public SlaverDevice(Log log,
            Action<ConnectStatus> changeStatus, 
            Action<BaseChannel[]> drawLines, 
            Action<double> startCountDown)
        {
            ChangeStatus = changeStatus;
            Log = log;
            DrawLines = drawLines;
            StartCountDown = startCountDown;
            _channels = new BaseChannel[12];
            for (var i = 0; i < _channels.Length; i++)
            {
                if (i < 6)
                {
                    _channels[i] = new PressureChannel($"压力通道<{i + 1}>");
                }
                else if (i >=6 && i < 10)
                {
                    _channels[i] = new DigitalChannel($"数字量/计时通道<{i - 5}>");
                }
                else if (i == 10)
                {
                    _channels[i] = new SpeedChannel($"速度通道<{i - 9}>");
                }
                else
                {
                    _channels[i] = new PressureChannel($"其他通道<{i - 10}>");
                }
            }
        }
        public bool Connect()
        {
            Log.Show("正在连接主控板...");
            string cmdIP, dataIP;
            int cmdPort, dataPort;
            try
            {
                cmdIP = CmdTable["IPAddress"].ToString();
                cmdPort = (int)CmdTable["Port"];
                dataIP = DataTable["IPAddress"].ToString();
                dataPort = (int)DataTable["Port"];
            }
            catch
            {
                Log.Show("IP地址/端口号信息读取失败,请检查配置文件.");
                return false;
            }
            if (OpenControl(cmdIP, cmdPort))
            {
                Log.Show("主控板连接成功.");
            }
            else
            {
                Log.Show("主控板连接失败.");
                Status = ConnectStatus.Disconnected;

                return false;
            }
            Thread.Sleep(500);
            Log.Show("正在连接数位板...");
            if (OpenData(dataIP, dataPort))
            {
                Log.Show("数位板连接成功.");
            }
            else
            {
                Log.Show("数位板连接失败.");
                Status = ConnectStatus.Disconnected;
                _commandPanel.StopReading();
                _commandPanel.Close();
                return false;
            }
            return true;
        }
        public bool OpenControl(string ip, int port)
        {
            _commandPanel = new CommandPanel(ip, port);
            try
            {
                _commandPanel.ReceiveTimeOut = (int)CmdTable["TimeOut"];
            }
            catch
            {
                CmdTable["TimeOut"] = "500";
            }
            try
            {
                _commandPanel.ReceiveBufferSize = (int)CmdTable["BufferSize"];
            }
            catch
            {
                CmdTable["BufferSize"] = "1024";
            }
            _commandPanel.StartReading();
            return _commandPanel.Open();
        }
        public bool OpenData(string ip, int port)
        {
            _dataPanel = new DataPanel(ip, port);
            try
            {
                _dataPanel.ReceiveTimeOut = (int)DataTable["TimeOut"];
            }
            catch
            {
                DataTable["TimeOut"] = "500";
            }
            try
            {
                _dataPanel.ReceiveBufferSize = (int)DataTable["BufferSize"];
            }
            catch
            {
                DataTable["BufferSize"] = "1024";
            }
            _dataPanel.StartReading();
            _dataPanel.DataReceived += _dataPanel.DataUpdate;
            return _dataPanel.Open();
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
            Log.Show("正在断开连接...");
            if (_dataPanel != null)
            {
                _dataPanel.DataReceived -= _dataPanel.DataUpdate;
                _dataPanel.StopReading();
                _dataPanel.Close();
                _dataPanel = null;
                Log.Show("已断开数位板连接.");
            }
            if (_commandPanel != null)
            {
                _commandPanel.StopReading();
                _commandPanel.Close();
                _commandPanel = null;
                Log.Show("已断开主控板连接.");
            }
            Thread.Sleep(500);
        }
        public bool CheckClockStatus()
        {
            Log.Show("正在发送时钟检测命令...");
            var result = _commandPanel.CheckClockStatus();
            Log.Show(result ? "时钟状态正常." : "时钟状态异常.");
            return result;
        }
        public void StartReceiving()
        {
            _dataPanel.StartReceiving();
        }
        public void Reset()
        {
            Log.Show("发送复位命令.");
            _commandPanel.Reset();
        }
        public void UpdateChannelHealth()
        {
            _dataPanel.CheckChannelStatus(ref _channels);
            for (var i = 0; i < _channels.Length - 2; i++)
            {
                Log.Show($"{_channels[i].Name}: {(_channels[i].Health ? "正常" : "异常")}.");
            }
        }
        public bool UpdateChannelExist()
        {
            return _commandPanel.CheckChannelStatus(ref _channels);
        }
        public void UpdateChannelData()
        {
            _dataPanel.GetCurrentChannelData(ref _channels);
            foreach (var t in Channels)
            {
                if (t.DeviceExist)
                {
                    t.RefreshData();  // 设备存在才刷新数据
                }
            }
        }
        public void SetTriggerChannelIndex(int channelIndex)
        {
            int startIndex = 0, endIndex = 0;
            if (channelIndex < 6)
            {
                startIndex = 0;
                endIndex = 6;
            }
            else if (channelIndex >= 6 && channelIndex < 10)
            {
                startIndex = 6;
                endIndex = 10;
            }
            for (var i = startIndex; i < endIndex; i++)
            {
                _channels[i].IsTrigger = false;
            }
            _channels[channelIndex].IsTrigger = true;
        }
        public int GetTriggerChannelIndex(ChannelType channelType)
        {
            int startIndex = 0, endIndex = 0;
            switch (channelType)
            {
                case ChannelType.Pressure:
                    startIndex = 0;
                    endIndex = 6;
                    break;
                case ChannelType.Digital:
                    startIndex = 6;
                    endIndex = 10;
                    break;
            }
            for (var i = startIndex; i < endIndex; i++)
            {
                if (_channels[i].IsTrigger)
                {
                    return i;
                }
            }
            return -1;
        }

        public int AutoMeasuringTime { set; get; }
        public int ManualMeasuringTime { set; get; }

        public int MeasuringTime => TriggerMode == TriggerMode.Auto ? AutoMeasuringTime : ManualMeasuringTime;
        public void SelfTest()
        {
            Log.Show("发送自检命令.");
            _commandPanel.SelfTest();
        }
        public void SelfTest(bool result)
        {
            Log.Show(result ? "发送自检成功命令." : "发送自检失败命令.");
            _commandPanel.SelfTest(result);
        }
        public bool WaitTrigger(ref BackgroundWorker sender, ref DoWorkEventArgs e)
        {
            if (PressureTriggerIndex == -1)
            {
                Log.Show("需要设置触发通道.");
                return false;
            }
            double increment = 0;
            var mapIndex = (int)_mappingRule[PressureTriggerIndex];
            var autoTrigger = (JObject)Config.Measure["AutoTrigger"];
            while (increment < (double)autoTrigger["Value"])
            {
                if (sender.CancellationPending)
                {
                    e.Cancel = true;
                    return false;
                }
                increment = PressureTriggerChannel.Formula(_dataPanel.CurAverageData[mapIndex]);
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
                Log.Show("等待触发...");
                //Channels[TriggerIndex].WaitTriggerSwitch = !StopFlag;
                if (!WaitTrigger(ref sender, ref e)) return;
                StartCountDown?.Invoke(MeasuringTime / 1000d);
                Log.Show($"{Channels[GetTriggerChannelIndex(ChannelType.Pressure)].Name}触发.");
                if (!Measure(ref sender, ref e))
                    return;
                Log.Show("正在绘制图表...");
                DrawLines?.Invoke(Channels);
                Log.Show("正在显示图表...");
            }
            else if (TriggerMode == TriggerMode.Manual)
            {
                StartCountDown?.Invoke(MeasuringTime / 1000d);
                if (!Measure(ref sender, ref e))
                    return;
                Log.Show("正在绘制图表...");
                DrawLines?.Invoke(Channels);
                Log.Show("正在显示图表...");
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
            Log.Show("正在记录数据...");
            //var ByteData = DataPanel.DataStoreByTime(MeasuringTime);
            var byteData = _dataPanel.DataStoreByCount(Convert.ToInt64(MeasuringTime * 6.4));
            Log.Show("正在处理数据...");
            foreach (var t in Channels)
            {
                if (sender.CancellationPending)
                {
                    e.Cancel = true;
                    return false;
                }
                t.MeasuringData = new List<double>();
            }
            foreach (var t in byteData)
            {
                if (sender.CancellationPending)
                {
                    e.Cancel = true;
                    return false;
                }
                for (var i = 0; i < 12; i++)
                {
                    if (sender.CancellationPending)
                    {
                        e.Cancel = true;
                        return false;
                    }
                    Channels[i].MeasuringData.Add(Channels[i].Formula(t[(int)_mappingRule[i]]));
                }
                //for (var i = 0; i < 6; i++)
                //{
                //    if (sender.CancellationPending)
                //    {
                //        e.Cancel = true;
                //        return false;
                //    }
                //    Channels[i].MeasuringData.Add(Channels[i].Formula(t[i + 9]));
                //}
                //for (var i = 6; i < 10; i++)
                //{
                //    if (sender.CancellationPending)
                //    {
                //        e.Cancel = true;
                //        return false;
                //    }
                //    Channels[i].MeasuringData.Add(Channels[i].Formula(t[i - 6]));
                //}
            }
            Log.Show("数据处理完毕.");
            return true;
        }

        public void DischargeGateOpenTime(out double openTime, out double lastTime)
        {
            openTime = 0;
            lastTime = 0;
            var triggerIndex = GetTriggerChannelIndex(ChannelType.Digital);
            if (triggerIndex == -1) return;
            var triggerChannel = Channels[triggerIndex];
            var i = 0; var count = 0;
            var hasOpened = false;
            foreach (var t in triggerChannel.MeasuringData)
            {
                i++;
                if (t < 2.5)
                {
                    count++;
                    if (count > 4000)
                    {
                        hasOpened = true;
                    }
                }
                else
                {
                    if (!hasOpened) continue;
                    openTime = (i - count) / 6400d;
                    lastTime = count / 6400d;
                    return;
                }

            }
        }
    }
}
