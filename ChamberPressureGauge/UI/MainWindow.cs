//using ChamberPressureGauge.Modules;
//using ChamberPressureGauge.Controls;
using Report.iTextSharp;
using Slaver;
using Slaver.Channel;
using Controls;
using ChamberPressureGauge.UI;
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

//using System.Windows.Media;
using LiveCharts.Geared;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;
using DColor = System.Drawing.Color;
using MColor = System.Windows.Media.Color;
using System.Windows.Media;
using LiveCharts;

//using LiveCharts;
//using LiveCharts.Defaults;
//using LiveCharts.Wpf;
//using LiveCharts; //Core of the library
//using LiveCharts.Wpf; //The WPF controls
//using LiveCharts.WinForms; //the WinForm wrappers

namespace ChamberPressureGauge.UI
{
    public partial class MainWindow : Form
    {
        DColor[] Colors = new DColor[10]
        {
                DColor.Black,
                DColor.Red,
                DColor.LightBlue,
                DColor.Green,
                DColor.Yellow,
                DColor.Purple,
                DColor.Brown,
                DColor.DarkBlue,
                DColor.Pink,
                DColor.Gray,
        };
        // 全局变量
        private delegate void _Log(string LogInfo);
        private delegate void _ChangeStatus(ConnectStatus Status);
        private delegate void NonParaFun();
        private delegate void _DrawLines(BaseChannel[] Channels);
        private delegate void _StartCountDown(double value);
        
        SlaverDevice _Slaver;  // 下位机
        bool ChannelUpdating = false;  // 通道检测Timer是否被占用
        //private Chart DataChart;
        //private double CountDownValue;  // 倒计时
        //private Thread tCountDown;
        //private CountDown CountDown;

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
                txtLog.AppendText(string.Format("{0} {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"), LogInfo) + Environment.NewLine);
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
                    tbStart.Image = Resources.toolbar_start_listening;

                    tbReset.Enabled = false;
                    tbReset.ToolTipText = "复位(需要先连接)";

                    tbChart.Enabled = false;
                    tbChart.ToolTipText = "查看图表(需要先连接)";

                    lblStatus.Text = "断开";

                    tcChannel.Show();
                    picLoading.Hide();
 
                    foreach (var Item in _Slaver.Channels)
                    {
                        Item.DeviceExist = false;
                    }
                    break;
                case ConnectStatus.Connecting:
                    Log("开始连接...");
                    tbConnet.Enabled = true;
                    tbConnet.ToolTipText = "取消";
                    tbConnet.Image = Resources.toolbar_cancel;

                    tbStart.Enabled = false;
                    tbStart.ToolTipText = "开始测量(需要先连接)";

                    tbReset.Enabled = false;
                    tbReset.ToolTipText = "复位(需要先连接)";

                    tbChart.Enabled = false;
                    tbChart.ToolTipText = "查看图表(需要先连接)";

                    lblStatus.Text = "正在连接...";

                    tcChannel.Show();
                    picLoading.Hide();

                    break;
                case ConnectStatus.Connected:
                    tbConnet.Enabled = true;
                    tbConnet.ToolTipText = "断开连接";
                    tbConnet.Image = Resources.toolbar_disconnect;

                    tbStart.Enabled = true;
                    tbStart.ToolTipText = "开始测量";
                    tbStart.Image = Resources.toolbar_start_listening;

                    tbReset.Enabled = true;
                    tbReset.ToolTipText = "复位";

                    tbChart.Enabled = true;
                    tbChart.ToolTipText = "查看图表";

                    lblStatus.Text = "已连接";

                    tcChannel.Show();
                    picLoading.Hide();

                    break;
                case ConnectStatus.Measuring:
                    tbConnet.Enabled = false;
                    tbConnet.ToolTipText = "断开连接";
                    tbConnet.Image = Resources.toolbar_disconnect;

                    tbStart.Enabled = true;
                    tbStart.ToolTipText = "停止测量";
                    tbStart.Image = Resources.toolbar_stop_listening;

                    tbReset.Enabled = false;
                    tbReset.ToolTipText = "复位";

                    tbChart.Enabled = false;
                    tbChart.ToolTipText = "查看图表";

                    lblStatus.Text = "正在测量...";

                    tcChannel.Hide();
                    picLoading.Show();

                    break;
            }
        }
        public void ConnectControl(ref DoWorkEventArgs e)
        {
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // 连接
            if(!_Slaver.Connect())
            {
                bwConnect.CancelAsync();
                //_Slaver.Close();
                //return;
            }
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // 复位
            _Slaver.Reset();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // 自检
            _Slaver.CheckClockStatus();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            _Slaver.SelfTest();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(1000);
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // 开始接收
            _Slaver.StartReceiving();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Thread.Sleep(1000);
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // 检查通道是否正常
            _Slaver.UpdateChannelHealth();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            _Slaver.SelfTest(true);
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            _Slaver.Reset();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            _Slaver.UpdateChannelExist();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // 通道检测
            Log("打开通道检测线程.");
            timChannelUpdate.Start();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            //Thread.Sleep(2000);
            //if (bwConnect.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}
        }
        //public bool ConnectCtrl()
        //{
        //    if (_Slaver.CPOpen("192.168.1.178", 4001))
        //    {
        //        Log("主控板连接成功.");
        //        return true;
        //    }
        //    else
        //    {
        //        Log("主控板连接失败.");
        //        return false;
        //    }
        //}
        //public bool ConnectDgtl()
        //{
        //    if (_Slaver.DPOpen("192.168.1.126", 8000))
        //    {
        //        Log("数位板连接成功.");
        //        return true;
        //    }
        //    else
        //    {
        //        Log("数位板连接失败.");
        //        return false;
        //    }
        //}
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
        private void ChartInit()
        {
            lvChart.Series = new SeriesCollection();
            lvChart.LegendLocation = LegendLocation.Top;
            lvChart.Zoom = ZoomingOptions.X;
            lvChart.DisableAnimations = true;
            lvChart.Hoverable = false;
            //lvChart.ScrollMode = ScrollMode.XY;
            //lvChart.ScrollBarFill = new SolidColorBrush(MColor.FromArgb(37, 48, 48, 48));
            lvChart.AxisX.Clear();
            lvChart.AxisX.Add(new Axis()
            {
                Title = "时间/s",
                MinValue = 0,
                LabelFormatter = value => string.Format("{0:F2}", value),
                Separator = new Separator
                {
                    Step = 1d,
                    IsEnabled = false,
                }
            });
            lvChart.AxisY.Clear();
            lvChart.AxisY.Add(new Axis()
            {
                Title = "压力/MPa",
                LabelFormatter = value => string.Format("{0:F5}", value)
            });
        }

        private void CountDownInit()
        {
            //CountDown = new CountDown();
            //gbTotalChannel.Controls.Add(CountDown);
            CountDown.Location = new System.Drawing.Point((gbTotalChannel.Width - CountDown.Width) / 2, (gbTotalChannel.Height - CountDown.Height) / 2);
            CountDown.AfterDone = CountDownAfterDone;
            CountDown.AfterCancel = CountDownAfterDone;
            CountDown.BeforeStart = CountDownBeforeStart;
            CountDown.Hide();
        }
        private void CountDownAfterDone()
        {
            if (InvokeRequired)
            {
                NonParaFun me = new NonParaFun(CountDownAfterDone);
                Invoke(me);
                return;
            }
            picLoading.Show();
            CountDown.Hide();
        }
        private void CountDownBeforeStart()
        {
            if (InvokeRequired)
            {
                NonParaFun me = new NonParaFun(CountDownBeforeStart);
                Invoke(me);
                return;
            }
            picLoading.Hide();
            CountDown.Show();
        }
        private void WinLoad(object sender, EventArgs e)
        {
            Log("程序初始化...");
            CountDownInit();
            _Slaver = new SlaverDevice(Log, ChangeStatus, DrawLines, CountDown.Start);  // 主对象
            // 控件放置
            for (int i = 0; i < 6; i ++)
            {
                tpPressure.Controls.Add(_Slaver.Channels[i].Control);
                _Slaver.Channels[i].Control.Location = 
                    new System.Drawing.Point(i % 2 == 0 ? 10 : _Slaver.Channels[i].Control.Width + 20,
                    10 + i / 2 * (_Slaver.Channels[i].Control.Height + 10));
                //_Slaver.Channels[i].Control.Size = new Size(220, 100);
                _Slaver.Channels[i].Control.TabIndex = i;
                _Slaver.Channels[i].Control.TabStop = false;
            }

            ChartInit();


            _Slaver.Status = ConnectStatus.Disconnected;
            cbTriggerMode.SelectedIndex = 0;
            timClock.Start();
            Log("初始化完成.");
        }
        private void WinClosing(object sender, FormClosingEventArgs e)
        {
            if (_Slaver.Status == ConnectStatus.Measuring)
            {
                Start(null, null);
                Thread.Sleep(1000);
            }
            if (_Slaver.Status == ConnectStatus.Connected)
            {
                Connect(null, null);
            }
            try
            {
                Environment.Exit(Environment.ExitCode);
            }
            finally
            {
                Close();
            }
        }
        private void WinClosing(object sender, EventArgs e)
        {
            WinClosing(null, null);
        }
        private void EventConfig(object sender, EventArgs e)
        {

        }
        private void timClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void Reset(object sender, EventArgs e)
        {
            _Slaver.Reset();
            ChartInit();
        }
        private void Connect(object sender, EventArgs e)
        {
            if (_Slaver.Status == ConnectStatus.Disconnected)
            {
                Log("正在准备连接...");
                Thread.Sleep(500);
                bwConnect.RunWorkerAsync();
            }
            else if (_Slaver.Status == ConnectStatus.Connected)
            {
                timChannelUpdate.Stop();
                if (bwConnect.IsBusy)
                {
                    Log("正在取消...");
                    bwConnect.CancelAsync();
                }
                //_Connect.Abort();
                _Slaver.Status = ConnectStatus.Disconnected;
                // 关闭连接
                _Slaver.Close();
            }
            else if (_Slaver.Status == ConnectStatus.Connecting)
            {
                Log("正在取消...");
                bwConnect.CancelAsync();
            }
        }
        private void Measure(ref BackgroundWorker sender, ref DoWorkEventArgs e)
        {
            _Slaver.Status = ConnectStatus.Measuring;
            Log("关闭通道检测线程.");
            timChannelUpdate.Stop();
            Log("正在准备测量...");
            _Slaver.StartMeasuring(ref sender, ref e);
            //Log("10秒后重新打开通道检测线程.");
            //Thread.Sleep(10000);
            Log("打开通道检测线程.");
            timChannelUpdate.Start();
            _Slaver.Status = ConnectStatus.Connected;
        }
        private void Start(object sender, EventArgs e)
        {
            if (_Slaver.Status == ConnectStatus.Connected)
            {
                //txtMeasuringTime_LostFocus(null, null);
                _Slaver.MeasuringTime = int.Parse(txtMeasuringTime.Text.Replace(" ", ""));
                Log("打开测量线程.");
                bwMeasure.RunWorkerAsync();
                //_Measure = new Thread(new ThreadStart(Measure));
                //_Measure.Start();
            }
            else if (_Slaver.Status == ConnectStatus.Measuring)
            {
                //_Slaver.Status = ConnectStatus.Connected;
                Log("正在取消...");
                CountDown.Cancel();
                bwMeasure.CancelAsync();
                //tCountDown.Abort();
                //_Slaver.StopMeasuring();
                //Log("测量已取消...");
            }
        }

        public void DrawLines(BaseChannel[] Channels)  // 根据channels绘制曲线
        {
            
            if (InvokeRequired)
            {
                _DrawLines me = new _DrawLines(DrawLines);
                object[] arg = new object[] { Channels };
                Invoke(me, arg);
                return;
            }
            

            int PointCount = int.Parse(txtPointCount.Text.Replace(" ", ""));
            for (int i = 0; i < Channels.Length; i++)
            {
                if (!Channels[i].DeviceExist)
                {
                    continue;
                }
                // LiveChart
                object LineSeries;
                //var Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint>();
                var Values = new GearedValues<LiveCharts.Defaults.ObservablePoint>();
                Values.Quality = Quality.Low;
                if (Channels[i].Type == ChannelType.Pressure)
                {
                    LineSeries = new GLineSeries()
                    {
                        Fill = Brushes.Transparent,
                        //StrokeThickness = 0.5,
                        Values = Values,
                        PointGeometry = null,
                        LineSmoothness = 1,
                        Title = Channels[i].Name,
                        AreaLimit = 0,
                    };
                }
                else if (Channels[i].Type == ChannelType.Digital)
                {
                    LineSeries = new GStepLineSeries()
                    {
                        Fill = Brushes.Transparent,
                        //StrokeThickness = 0.5,
                        Values = Values,
                        PointGeometry = null,
                        Title = Channels[i].Name,
                    };
                }
                else
                {
                    LineSeries = new GLineSeries();
                }
                //var Series = new Series();
                //Series.ChartType = SeriesChartType.Spline;
                //Series.BorderWidth = 2;
                //Series.Color = Colors[i];
                //Series.LegendText = Channels[i].Name;
                int x = 0;
                int AvgX;
                if (PointCount == 0)
                {
                    AvgX = Channels[i].MeasuringData.Count;
                }
                else
                {
                    AvgX = Channels[i].MeasuringData.Count / PointCount;
                }
                foreach (var y in Channels[i].MeasuringData)
                {
                    if (x % AvgX == 0)
                    {
                        double SecX = (double)(x - AvgX / 2d) / (2000d * 3.2d);
                        double AvgY = y;
                        //Series.Points.AddXY(SecX, AvgY);
                        Values.Add(new LiveCharts.Defaults.ObservablePoint(SecX, AvgY));
                    }
                    x += 1;
                }
                //DataChart.Series.Add(Series);

                lvChart.Series.Add((LiveCharts.Definitions.Series.ISeriesView)LineSeries);
            }

            //ChartArea.AxisX.ScrollBar = new AxisScrollBar();
            //ChartArea.AxisY.ScrollBar = new AxisScrollBar();
        }

        //private void StartCountDown(double value)
        //{
        //    CountDownValue = value;

        //    tCountDown = new Thread(new ThreadStart(CountDown));
        //    tCountDown.Start();
        //}

        //private void CountDown()
        //{
        //    //if (InvokeRequired)
        //    //{
        //    //    _NonParaFun me = new _NonParaFun(CountDown);
        //    //    Invoke(me);
        //    //    return;
        //    //}
        //    picLoading.Hide();
        //    lblCountDown.Show();
        //    while (CountDownValue >= 0)
        //    {
        //        try
        //        {
        //            lblCountDown.Text = string.Format("{0:F2}s", CountDownValue);
        //            CountDownValue -= 0.01;
        //            Thread.Sleep(10);
        //        }
        //        catch (ThreadAbortException)
        //        {
        //            lblCountDown.Hide();
        //            picLoading.Show();
        //            return;
        //        }
        //    }
        //    lblCountDown.Hide();
        //    picLoading.Show();
        //}

        //private void ShowPointTooltip(object sender, ToolTipEventArgs e)
        //{
        //    if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
        //    {
        //        Cursor = Cursors.Cross;
        //        int i = e.HitTestResult.PointIndex;
        //        DataPoint dp = e.HitTestResult.Series.Points[i];
        //        txtX.Text = string.Format("{0:F3} s", dp.XValue);
        //        txtY.Text = string.Format("{0:F4} MPa", dp.YValues[0]);
        //        e.Text = string.Format("压力: {1}" + Environment.NewLine + "时间: {0}", txtX.Text, txtY.Text);

        //    }
        //    else
        //    {
        //        Cursor = Cursors.Default;
        //    }
        //}

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
            _Slaver.SetTriggerChannel(int.Parse(System.Text.RegularExpressions.Regex.Replace(cbTriggerChannel.SelectedItem.ToString(), @"[^0-9]+", "")) - 1);
        }

        private void AutoTrigger(bool IsOrNot)
        {
            lblTriggerChannel.Enabled = IsOrNot;
            cbTriggerChannel.Enabled = IsOrNot;
            btnRefreshTriggerChannel.Enabled = IsOrNot;
            if (IsOrNot)
                RefreshTriggerChannel();
        }
        private void RefreshTriggerChannel()
        {
            if (InvokeRequired)
            {
                NonParaFun me = new NonParaFun(RefreshTriggerChannel);
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

        private void bwConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            _Slaver.Status = ConnectStatus.Connecting;
            ConnectControl(ref e);
        }

        private void bwConnect_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bwConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Log("连接失败.");
                _Slaver.Status = ConnectStatus.Disconnected;
                timChannelUpdate.Close();
                _Slaver.Close();
            }
            else
            {
                Log("已连接.");
                _Slaver.Status = ConnectStatus.Connected;
                RefreshTriggerChannel();
            }
        }

        private void bwMeasure_DoWork(object sender, DoWorkEventArgs e)
        {
            _Slaver.Status = ConnectStatus.Measuring;
            Measure(ref bwMeasure, ref e);
        }

        private void bwMeasure_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Log("测量失败.");
            }
            else
            {
                Log("测量完成.");
            }
            _Slaver.Status = ConnectStatus.Connected;
        }

        private void ShowConfigWindow(object sender, EventArgs e)
        {
            ConfigWindow ConfigWindow = new ConfigWindow();
            ConfigWindow.ShowDialog();
        }

        private void lvChart_DataHover(object sender, LiveCharts.ChartPoint chartPoint)
        {
            txtX.Text = string.Format("{0:F3} s", chartPoint.X);
            txtY.Text = string.Format("{0:F4} MPa", chartPoint.Y);
            //e.Text = string.Format("压力: {1}" + Environment.NewLine + "时间: {0}", txtX.Text, txtY.Text);
        }

        private void Report(object sender, EventArgs e)
        {
            tbReport.Enabled = false;
            bwBuildReport.RunWorkerAsync();
        }

        private void bwBuildReport_DoWork(object sender, DoWorkEventArgs e)
        {
            Log("正在导出报告...");
            Bitmap ChartBitmap = new Bitmap(lvChart.Width, lvChart.Height);
            lvChart.Invoke(new Action(() =>
            {
                lvChart.DrawToBitmap(ChartBitmap, new Rectangle(0, 0, lvChart.Width, lvChart.Height));
            }));
            //lvChart.DrawToBitmap(ChartBitmap, new Rectangle(0, 0, lvChart.Width, lvChart.Height));
            ChartBitmap.Save(System.Windows.Forms.Application.StartupPath + "/report/img.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            PDFReport Report = new PDFReport();
            Report.FilePath = string.Format("{0}/report/{1}.pdf", System.Windows.Forms.Application.StartupPath, DateTime.Now.ToString("yyyyMMddHHmmss"));
            Report.AddTitle("测量报告");
            Report.AddEmptyLine();
            Report.AddText(string.Format("测量日期: {0}", DateTime.Now));
            Report.AddText(string.Format("测量时间: {0} 毫秒", _Slaver.MeasuringTime));
            if (_Slaver.TriggerMode == TriggerMode.Auto)
            {
                BaseChannel TriggerChannel = _Slaver.Channels[_Slaver.GetTriggerChannel(ChannelType.Pressure)];
                Report.AddText("触发方式: 自动触发");
                Report.AddText(string.Format("触发通道: {0}", TriggerChannel.Name));
                Report.AddText(string.Format("触发值: {0} MPa", TriggerChannel.TriggerIncrement));
            }
            else if (_Slaver.TriggerMode == TriggerMode.manual)
            {
                Report.AddText("触发方式: 手动触发");
            }
            else if (_Slaver.TriggerMode == TriggerMode.External)
            {
                Report.AddText("触发方式: 外触发");
            }
            Report.AddEmptyLine();
            Report.AddText("测量结果:");
            Report.AddImage(ChartBitmap);
            Report.Print();
            string WaterMarkPDFPath = string.Format("report/Report{0}.pdf", DateTime.Now.ToString("yyyyMMddHHmmss"));
            Log("导出报告完成，正在打开...");
            Report.Open();
        }

        private void bwBuildReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tbReport.Enabled = true; ;
        }
    }
}
