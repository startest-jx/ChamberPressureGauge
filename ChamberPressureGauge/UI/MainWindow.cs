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
        byte[] CmdStock, DataStock;  // 命令、数据存放
        Mutex CmdLock = new Mutex(), DataLock = new Mutex(), ChannelLock = new Mutex();  // 命令、数据、通道使能互斥锁
        bool[] ChannelEnable = new bool[12];  // 通道使能

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
                return;
            }
            //_CntCtrl = new Thread(new ThreadStart(ConnectCtrl));
            //_CntCtrl.Start();
            Log("正在连接数位板...");
            if (!ConnectDgtl())
            {
                ChangeStatus(0);
                StopThread();
                return;
            }
            //_CntDgtl = new Thread(new ThreadStart(ConnectDgtl));
            //_CntDgtl.Start();
            //while (_CntCtrl.ThreadState == ThreadState.Running || _CntDgtl.ThreadState == ThreadState.Running);
            //if (!(IsCtrlOK && IsDgtlOK))
            //{
            //    ChangeStatus(0);
            //    return;
            //}
            ChangeStatus(2);

            // 复位
            Reset(null, null);

            // 自检
            Log("正在发送时钟检测命令...");
            _CtrlPanel.SendCmd("CLOCKSTA");
            string rtCmd = CheckCmd();
            switch (rtCmd)
            {
                case "CLKSUCCEED":
                    Log("时钟状态正常.");
                    break;
                case "CLKFAILED":
                    Log("时钟状态异常.");
                    break;
                default:
                    Log("未接收到下位机回复.");
                    ChangeStatus(0);
                    StopThread();
                    return;
            }
            Log("正在发送自检成功命令...");
            _CtrlPanel.SendCmd("TESTPASSED");

            // 通道检测
            Log("正在检查通道连接状态...");
            _ChannelCheck = new Thread(new ThreadStart(ChannelCheck));
            _ChannelCheck.Start();
            _CtrlPanel.SendCmd("LINESTATUE");
            string LineStatusString = CheckCmd();
            for (int i = 0; i < LineStatusString.Length; i ++)
            {
                if (LineStatusString[i] == '0')
                {
                    ChannelEnable[i] = true;
                }
                else
                {
                    ChannelEnable[i] = false;
                }
            }
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
            ChannelLock.WaitOne();
            for (int i = 0; i < ChannelEnable.Length; i ++)
            {
                if (ChannelEnable[i])
                {

                }
            }
            ChannelLock.ReleaseMutex();
        }
        public void StartThread()
        {
            // 打开监听
            _CtrlPanel.StartRead();
            _CtrlPanel.DataReceived += new Comm.EventHandle(CmdStore);
            _DgtlPanel.StartRead();
            _DgtlPanel.DataReceived += new Comm.EventHandle(DataStore);
        }
        public void StopThread()
        {
            // 关闭监听
            _CtrlPanel.DataReceived -= new Comm.EventHandle(CmdStore);
            _CtrlPanel.StopReading();
            _DgtlPanel.DataReceived -= new Comm.EventHandle(DataStore);
            _DgtlPanel.StopReading();
        }
        public void CmdStore(byte[] readBuffer, int offset, int length)
        {
            CmdLock.WaitOne();
            CmdStock = new byte[length];
            for (int i = 0; i < length; i ++)
            {
                CmdStock[i] = readBuffer[i];
            }
            CmdLock.ReleaseMutex();
        }
        public string CmdRead()
        {
            CmdLock.WaitOne();
            string str = "";
            if (CmdStock != null)
                str = Encoding.Default.GetString(CmdStock);
            CmdLock.ReleaseMutex();
            return str;
        }
        public string CheckCmd()
        {
            long PreSec = DateTime.Now.ToBinary();
            long CurSec = DateTime.Now.ToBinary();
            while (CurSec - PreSec <= 10000)
            {
                string str = CmdRead();
                if (str.Length == 0)
                    continue;
                if (str[0] == 0x23 && str[str.Length - 1] == 0x0A)
                {
                    return str.Substring(1, str.Length - 2);
                }
            }
            return "";
        }
        public void DataStore(byte[] readBuffer, int offset, int length)
        {
            DataLock.WaitOne();
            DataStock = new byte[length];
            for (int i = 0; i < length; i++)
            {
                DataStock[i] = readBuffer[i];
            }
            DataLock.ReleaseMutex();
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
            timClock.Start();

            Log("初始化完成.");
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
            CmdStock = null;
            DataStock = null;
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
            else if (_Status == 2 || _Status == 3)
            {
                _CntTotal.Abort();

                StopThread();

                // 关闭连接
                _DgtlPanel.Close();
                Log("已断开数位板连接.");
                _CtrlPanel.Close();
                Log("已断开主控板连接.");
                ChangeStatus(0);

            }
        }

        private void Start(object sender, EventArgs e)
        {

        }
    }
}
