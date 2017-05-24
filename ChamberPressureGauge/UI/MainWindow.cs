using ChamberPressureGauge.UI;
using ChamberPressureGauge.Modules;
using ChamberPressureGauge.Controls;
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
        private delegate void _Log(string LogInfo);
        private delegate void _ChangeStatus(ConnectStatus Status);
        private delegate void _RefreshTriggerChannel();

        Slaver _Slaver;  // 下位机
        Thread _Connect;  // 连接线程，通道检测线程
        bool ChannelUpdating = false;  // 通道检测Timer是否被占用

        public void Log(string LogInfo)  // 日志输出
        {
            if (InvokeRequired)
            {
                _Log me = new _Log(Log);
                object[] arg = new object[] { LogInfo };
                Invoke(me, arg);
            }
            else
            {
                txtLog.AppendText(LogInfo + Environment.NewLine);
            }
                
        }
        public void ChangeStatus(ConnectStatus Status)
        {
            if (InvokeRequired)
            {
                _ChangeStatus me = new _ChangeStatus(ChangeStatus);
                object[] arg = new object[] { Status };
                Invoke(me, arg);
                return;
            }
            switch (Status)
            {
                case ConnectStatus.Disconnected:
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

                    foreach (var Item in _Slaver.Channels)
                    {
                        Item.DeviceExist = false;
                    }
                    break;
                case ConnectStatus.Connecting:
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
                case ConnectStatus.Connected:
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
                case ConnectStatus.Measuring:
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
        public void ConnectControl()
        {
            // 连接
            Log("正在连接主控板...");
            if (!ConnectCtrl())
            {
                _Slaver.Status = ConnectStatus.Disconnected;
                // 断开原有连接
                _Slaver.Close();
                return;
            }
            Thread.Sleep(500);
            Log("正在连接数位板...");
            if (!ConnectDgtl())
            {
                _Slaver.Status = ConnectStatus.Disconnected;
                // 断开原有连接
                _Slaver.Close();
                return;
            }
            // 复位
            Reset(null, null);
            // 自检
            Log("正在发送时钟检测命令...");
            if (_Slaver.CheckClockStatus())
                Log("时钟状态正常.");
            else
                Log("时钟状态异常.");
            Log("发送自检命令.");
            _Slaver.SelfTest();
            Thread.Sleep(1000);
            // 开始接收
            _Slaver.StartReceiving();
            Thread.Sleep(1000);
            // 检查通道是否正常
            _Slaver.UpdateChannelHealth();
            for (int i = 0; i < _Slaver.Channels.Length - 2; i ++)
            {
                Log(string.Format("{0}: {1}.", 
                    _Slaver.Channels[i].Name, 
                    _Slaver.Channels[i].Health ? "正常" : "异常"));
            }

            Log("发送自检成功命令.");
            _Slaver.SelfTest(true);
            _Slaver.Reset();

            // 通道检测
            Log("打开通道检测线程.");
            timChannelUpdate.Start();

            _Slaver.Status = ConnectStatus.Connected;
            Thread.Sleep(2000);
            RefreshTriggerChannel();
        }
        public bool ConnectCtrl()
        {
            if (_Slaver.CPOpen("192.168.1.178", 4001))
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
            if (_Slaver.DPOpen("192.168.1.126", 8000))
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
        private void timChannelUpdate_Tick(object sender, EventArgs e)
        {
            if (ChannelUpdating)
                return;
            ChannelUpdating = true;
            ChannelCheck();
            ChannelUpdating = false;
        }
        public void ChannelCheck()
        {
            if (_Slaver.Status == ConnectStatus.Connected || _Slaver.Status == ConnectStatus.Measuring)
            {
                if (!_Slaver.UpdateChannelExist())
                {
                    return;
                }
                _Slaver.UpdateChannelData();

            }
        }
        public MainWindow()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
        }
        private void WinLoad(object sender, EventArgs e)
        {
            Log("程序初始化...");
            _Slaver = new Slaver(ChangeStatus);  // 主对象
            // 控件放置
            for (int i = 0; i < 6; i ++)
            {
                tpPressure.Controls.Add(_Slaver.Channels[i].Control);
                _Slaver.Channels[i].Control.Location = 
                    new Point(i % 2 == 0 ? 10 : _Slaver.Channels[i].Control.Width + 20,
                    10 + i / 2 * (_Slaver.Channels[i].Control.Height + 10));
                //_Slaver.Channels[i].Control.Size = new Size(220, 100);
                _Slaver.Channels[i].Control.TabIndex = i;
                _Slaver.Channels[i].Control.TabStop = false;
            }
            _Slaver.Status = ConnectStatus.Disconnected;
            cbTriggerMode.SelectedIndex = 0;
            timClock.Start();
            Log("初始化完成.");
        }
        private void WinClosing(object sender, FormClosingEventArgs e)
        {
            if (_Slaver.Status == ConnectStatus.Disconnected)
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
            Log("发送复位指令.");
            _Slaver.Reset();
        }
        private void Connect(object sender, EventArgs e)
        {
            if (_Slaver.Status == ConnectStatus.Disconnected)
            {
                _Slaver.Status = ConnectStatus.Connecting;
                _Connect = new Thread(new ThreadStart(ConnectControl));
                _Connect.Start();
            }
            else
            {
                Log("正在断开连接...");
                timChannelUpdate.Stop();
                _Connect.Abort();
                _Slaver.Status = ConnectStatus.Disconnected;
                // 关闭连接
                _Slaver.Close();
                Log("已断开数位板连接.");
                Log("已断开主控板连接.");
            }
        }
        private void Start(object sender, EventArgs e)
        {
            _Slaver.Start(); /////////
        }

        private void cbTriggerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Slaver.TriggerMode = (TriggerMode)cbTriggerMode.SelectedIndex;
            if (cbTriggerMode.SelectedIndex == 0)
            {
                AutoTrigger(true);
            }
            else
            {
                AutoTrigger(false);
            }
        }
        private void cbTriggerChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTriggerChannel.SelectedIndex == -1)
            {
                return;
            }
            _Slaver.SetTriggerChannel(int.Parse(System.Text.RegularExpressions.Regex.Replace(cbTriggerChannel.SelectedItem.ToString(), @"[^0-9]+", "")));
        }

        private void AutoTrigger(bool IsOrNot)
        {
            lblTriggerChannel.Visible = IsOrNot;
            cbTriggerChannel.Visible = IsOrNot;
            btnRefreshTriggerChannel.Visible = IsOrNot;
            RefreshTriggerChannel();
        }
        private void RefreshTriggerChannel()
        {
            if (InvokeRequired)
            {
                _RefreshTriggerChannel me = new _RefreshTriggerChannel(RefreshTriggerChannel);
                Invoke(me);
                return;
            }
            cbTriggerChannel.Items.Clear();
            for (int i = 0; i < 6; i++)
            {
                if (_Slaver.Channels[i].DeviceExist)
                {
                    cbTriggerChannel.Items.Add(_Slaver.Channels[i].Name);
                }
            }
            if (cbTriggerChannel.SelectedIndex == -1 && cbTriggerChannel.Items.Count != 0)
            {
                cbTriggerChannel.SelectedIndex = 0;
            }
        }

        private void btnRefreshTriggerChannel_Click(object sender, EventArgs e)
        {
            RefreshTriggerChannel();
        }

        private void txtMeasuringTime_LostFocus(object sender, EventArgs e)
        {
            try
            {
                _Slaver.MeasuringTime = double.Parse(txtMeasuringTime.Text);
            }
            catch
            {

            }
            txtMeasuringTime.Text = string.Format("{0:000.0000}", _Slaver.MeasuringTime);
        }
    }
}
