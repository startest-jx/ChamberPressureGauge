using ChamberPressureGauge.UI;
using ChamberPressureGauge.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Windows;
using ChamberPressureGauge.Properties;

namespace ChamberPressureGauge
{
    public partial class MainWindow : Form
    {
        // 全局变量
        CtrlPanel _CtrlPanel;
        DgtlPanel _DgtlPanel;
        Thread _CntTotal, _ChannelCheck;  // 连接线程，通道检测线程
        int _Status = 0;  // 0 未连接 1 正在连接 2 已连接 3 测量
        int[] DataStock;  // 采集卡数据存放
        Mutex CmdLock = new Mutex(), DataLock = new Mutex(), ChannelLock = new Mutex();  // 命令、数据、通道使能互斥锁
        Channel[] _Channels = new Channel[10];  // 通道
        bool[] ChannelExist = new bool[12];  // 通道存在情况
        bool[] ChannelHealth = new bool[10];  // 通道健康状况
        bool AutoChannelCheck = false;  // 通道自动检查开关

        public void Log(string LogInfo)  // 日志输出
        {
            txtLog.AppendText(LogInfo + Environment.NewLine);
        }
        public void ChangeStatus(int Status)
        {
            _Status = Status;
            switch (Status)
            {
                case 0:
                    tbConnet.Enabled = true;
                    tbConnet.ToolTipText = "连接";
                    tbConnet.Image = Resources.toolbar_connect;

                    tbStart.Enabled = false;
                    tbStart.ToolTipText = "开始测量(需要先连接)";

                    tbReset.Enabled = false;
                    tbReset.ToolTipText = "复位(需要先连接)";

                    tbChart.Enabled = false;
                    tbChart.ToolTipText = "查看图表(需要先连接)";

                    lblStatus.Text = "断开";

                    foreach (ChnLED Item in txtPressure)
                    {
                        Item.Silenced();
                    }
                    break;
                case 1:
                    Log("开始连接...");
                    tbConnet.Enabled = false;
                    tbConnet.ToolTipText = "正在连接...";

                    tbStart.Enabled = false;
                    tbStart.ToolTipText = "开始测量(需要先连接)";

                    tbReset.Enabled = false;
                    tbReset.ToolTipText = "复位(需要先连接)";

                    tbChart.Enabled = false;
                    tbChart.ToolTipText = "查看图表(需要先连接)";

                    lblStatus.Text = "正在连接...";
                    break;
                case 2:
                    tbConnet.Enabled = true;
                    tbConnet.ToolTipText = "断开连接";
                    tbConnet.Image = Resources.toolbar_disconnect;

                    tbStart.Enabled = true;
                    tbStart.ToolTipText = "开始测量";

                    tbReset.Enabled = true;
                    tbReset.ToolTipText = "复位";

                    tbChart.Enabled = true;
                    tbChart.ToolTipText = "查看图表";

                    lblStatus.Text = "已连接";
                    break;
                case 3:
                    tbConnet.Enabled = true;
                    tbConnet.ToolTipText = "断开连接";
                    tbConnet.Image = Resources.toolbar_disconnect;

                    tbStart.Enabled = true;
                    tbStart.ToolTipText = "停止测量";
                    tbConnet.Image = Resources.toolbar_stop_listening;

                    tbReset.Enabled = true;
                    tbReset.ToolTipText = "复位";

                    tbChart.Enabled = true;
                    tbChart.ToolTipText = "查看图表";

                    lblStatus.Text = "正在获取数据...";
                    break;
            }
        }
        public void ConnectTotal()
        {
            // 连接
            Log("正在连接主控板...");
            if (!ConnectCtrl())
            {
                ChangeStatus(0);
                StopThread();
                // 断开原有连接
                _CtrlPanel.Close();
                _DgtlPanel.Close();
                return;
            }
            Thread.Sleep(500);
            Log("正在连接数位板...");
            if (!ConnectDgtl())
            {
                ChangeStatus(0);
                StopThread();
                // 断开原有连接
                _CtrlPanel.Close();
                _DgtlPanel.Close();
                return;
            }
            ChangeStatus(2);
            // 复位
            Reset(null, null);
            // 自检
            Log("正在发送时钟检测命令...");
            if (_CtrlPanel.CheckClockStatus())
                Log("时钟状态正常.");
            else
                Log("时钟状态异常.");

            //string ClockStatusString = CheckCmd();
            //switch (ClockStatusString)
            //{
            //    case "CLKSUCCEED":
            //        Log("时钟状态正常.");
            //        break;
            //    case "CLKFAILED":
            //        Log("时钟状态异常.");
            //        break;
            //    default:
            //        Log("未接收到下位机回复.");
            //        ChangeStatus(0);
            //        StopThread();
            //        return;
            //}
            Log("发送自检命令.");
            _CtrlPanel.SelfTest();
            Thread.Sleep(1000);
            // 开始接收
            _DgtlPanel.StartReceiving();
            Thread.Sleep(1000);
            // 检查通道是否正常
            ChannelHealth = _DgtlPanel.CheckChannelStatus();
            for (int i = 0; i < ChannelHealth.Length; i ++)
            {
                _Channels[i] = new Channel(string.Format("{0}通道{1}", i < 6 ? "压力" : "数字量/计时", i < 6 ? i + 1 : i - 5),
                    i < 6 ? ChannelType.Pressure : ChannelType.Digital, ChannelHealth[i]);
                _Channels[i].Health = ChannelHealth[i];
                Log(string.Format("{0}通道{1}工作{2}.", 
                    i < 6 ? "压力" : "数字量/计时", 
                    i < 6 ? i + 1 : i - 5,
                    ChannelHealth[i] ? "正常" : "异常"));
            }

            Log("发送自检成功命令.");
            _CtrlPanel.SelfTest(true);
            _CtrlPanel.Reset();

            // 通道检测
            Log("打开通道检测线程.");
            _ChannelCheck = new Thread(new ThreadStart(ChannelCheck));
            _ChannelCheck.Start();

            Log("通知数位板发送数据.");
            _DgtlPanel.StartPicking();;
        }
        public bool ConnectCtrl()
        {
            if (_CtrlPanel.Open())
            {
                Log("主控板连接成功.");
                return true;
            }
            else
            {
                Log("主控板连接失败.");
                return false;
            }
        }
        public bool ConnectDgtl()
        {
            if (_DgtlPanel.Open())
            {
                Log("数位板连接成功.");
                return true;
            }
            else
            {
                Log("数位板连接失败.");
                return false;
            }
        }
        public void ChannelCheck()
        {
            while (AutoChannelCheck && (_Status == 2 || _Status == 3))
            {
                string rtStr = null;
                ChannelExist = _CtrlPanel.CheckChannelStatus(ref rtStr);
                if (ChannelExist == null)
                {
                    Thread.Sleep(500);
                    continue;
                }
                for (int i = 0; i < _Channels.Length; i ++)
                {
                    _Channels[i].DeviceExist = ChannelExist[i];
                    if (i < 6)
                    {
                        _Channels[i].Range = int.Parse(System.Text.RegularExpressions.Regex.Replace(cbPressure[i].SelectedItem.ToString(), @"[^0-9]+", ""));
                    }
                }
                _DgtlPanel.GetCurrentChannelData(ref _Channels);
                for (int i = 0; i < txtPressure.Length; i ++)
                {
                    if (_Channels[i].Health)
                    {
                        txtPressure[i].MarkHealth();
                    }
                    else
                    {
                        txtPressure[i].MarkIll();
                    }
                    if (_Channels[i].DeviceExist)
                    {
                        txtPressure[i].Activate();
                        txtPressure[i].Text = string.Format("{0:000.000}", _Channels[i].CurrentData);
                    }
                    else
                    {
                        txtPressure[i].Silenced();
                    }
                }
                Thread.Sleep(500);
            }
        }
        public void StartThread()
        {
            // 打开监听
            _CtrlPanel.StartRead();
            //_CtrlPanel.DataReceived += new Comm.EventHandle(CmdStore);
            _DgtlPanel.StartRead();
            _DgtlPanel.DataReceived += new Comm.EventHandle(_DgtlPanel.DataUpdate);

            AutoChannelCheck = true;
        }
        public void StopThread()
        {
            // 关闭监听
            AutoChannelCheck = false;

            //_CtrlPanel.DataReceived -= new Comm.EventHandle(CmdStore);
            _CtrlPanel.StopReading();
            _DgtlPanel.DataReceived -= new Comm.EventHandle(_DgtlPanel.DataUpdate);
            _DgtlPanel.StopReading();

        }
        //public void CmdStore(byte[] readBuffer, int offset, int length)
        //{
        //    CmdLock.WaitOne();
        //    CmdStock = new byte[length];
        //    for (int i = 0; i < length; i ++)
        //    {
        //        CmdStock[i] = readBuffer[i];
        //    }
        //    CmdLock.ReleaseMutex();
        //}
        //public string CmdRead()
        //{
        //    CmdLock.WaitOne();
        //    string str = "";
        //    if (CmdStock != null)
        //        str = Encoding.Default.GetString(CmdStock);
        //    CmdLock.ReleaseMutex();
        //    return str;
        //}
        //public string CheckCmd()
        //{
        //    long PreSec = DateTime.Now.ToBinary();
        //    long CurSec = DateTime.Now.ToBinary();
        //    while (CurSec - PreSec <= 10000)
        //    {
        //        string str = CmdRead();
        //        if (str.Length == 0)
        //            continue;
        //        Log("接收到主控板消息: " + str);
        //        if (str[0] == 0x23 && str[str.Length - 1] == 0x0A)
        //        {
        //            CmdLock.WaitOne();
        //            CmdStock = null;  // 抹除原命令防止干扰
        //            CmdLock.ReleaseMutex();
        //            return str.Substring(1, str.Length - 2);
        //        }
        //    }
        //    // Log("命令接收超时.");
        //    return "";
        //}
        public void DataStore(byte[] readBuffer, int offset, int length)  // 接收采集板发来的16进制数据，并将其转换成双字节数组
        {
            DataLock.WaitOne();
            DataStock = new int[length];
            string LogInfo = "";
            for (int i = 0; i < length / 2; i++)
            {
                DataStock[i] = (readBuffer[2 * i + 1] << 8) | readBuffer[2 * i];
                LogInfo += string.Format("{0:X4} ", DataStock[i]);
                if ((i + 1) % 16 == 0)
                {
                    lstData.Items.Add(LogInfo);
                    LogInfo = "";
                }
            }
            DataLock.ReleaseMutex();
            //Log(LogInfo);
        }
        public MainWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void WinLoad(object sender, EventArgs e)
        {
            Log("程序初始化...");
            ChangeStatus(0);
            //timClock.Start();
            foreach (ComboBox Item in cbPressure)
            {
                Item.SelectedItem = "10 MPa";
            }
            Log("初始化完成.");
        }
        private void WinClosing(object sender, FormClosingEventArgs e)
        {
            if (_Status == 0)
            {
                
            }
            else
            {
                
                Connect(null, null);
            }
            Environment.Exit(Environment.ExitCode);
        }
        private void WinClosing(object sender, EventArgs e)
        {
            WinClosing(null, null);
        }
        private void EventConfig(object sender, EventArgs e)
        {
            ConfigWindow _ConfigWindow = new ConfigWindow();
            _ConfigWindow.ShowDialog();
        }
        private void timClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void Reset(object sender, EventArgs e)
        {
            DataStock = null;
            Log("发送复位指令.");
            _CtrlPanel.Reset();
        }
        private void Connect(object sender, EventArgs e)
        {
            if (_Status == 0)
            {
                ChangeStatus(1);
                _CtrlPanel = new CtrlPanel();
                _DgtlPanel = new DgtlPanel();
                StartThread();

                _CntTotal = new Thread(new ThreadStart(ConnectTotal));
                _CntTotal.Start();
            }
            else
            {
                Log("正在断开连接...");
                ChangeStatus(0);
                _CntTotal.Abort();
                StopThread();
                ChangeStatus(0);  // 二次信号
                // 关闭连接
                _DgtlPanel.Close();
                Log("已断开数位板连接.");
                _CtrlPanel.Close();
                Log("已断开主控板连接.");
            }
        }
        private void Start(object sender, EventArgs e)
        {

        }
    }
}
