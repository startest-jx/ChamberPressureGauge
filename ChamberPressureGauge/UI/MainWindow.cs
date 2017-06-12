//using ChamberPressureGauge.Modules;
//using ChamberPressureGauge.Controls;
using Report.iTextSharp;
using Slaver.Slaver;
using Slaver.Channel;
using Tools.Log;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using ChamberPressureGauge.Properties;

//using System.Windows.Media;
using LiveCharts.Geared;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;
using DColor = System.Drawing.Color;
using MColor = System.Windows.Media.Color;
using LiveCharts;
using Controls.Other;

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
        //DColor[] Colors = new DColor[10]
        //{
        //        DColor.Black,
        //        DColor.Red,
        //        DColor.LightBlue,
        //        DColor.Green,
        //        DColor.Yellow,
        //        DColor.Purple,
        //        DColor.Brown,
        //        DColor.DarkBlue,
        //        DColor.Pink,
        //        DColor.Gray,
        //};
        // 全局变量
        private LoadWindow _loadWindow;
        private Log _log;  // 日志对象
        private SlaverDevice _slaver;  // 下位机
        private bool _channelUpdating;  // 通道检测Timer是否被占用

        private Thread _loadingThread;
        //private Chart DataChart;
        //private double CountDownValue;  // 倒计时
        //private Thread tCountDown;
        //private CountDown CountDown;

        public void LogPrint(string logInfo)  // 日志输出
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { LogPrint(logInfo); }));
                return;
            }
            txtLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss:ffff} {logInfo}" + Environment.NewLine);
        }

        private void ShowLoadWindow()
        {
            _log.ShowLogFun += _loadWindow.Message;
            _loadWindow.TopMost = true;
            _loadWindow.StartPosition = FormStartPosition.CenterParent;
            _loadWindow.ShowDialog();
            //_loadingThread = new Thread(() => { _loadWindow.ShowDialog(); });
            //_loadingThread.Start();
        }

        private void CloseLoadWindow()
        {
            _log.ShowLogFun -= _loadWindow.Message;
            _loadWindow.Hide();
        }

        public void ChangeStatus(ConnectStatus status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ChangeStatus(status); }));
                return;
            }
            switch (status)
            {
                case ConnectStatus.Disconnected:
                    tbConnet.Enabled = true;
                    tbConnet.ToolTipText = @"连接";
                    tbConnet.Image = Resources.toolbar_connect;

                    tbStart.Enabled = false;
                    tbStart.ToolTipText = @"开始测量(需要先连接)";
                    tbStart.Image = Resources.toolbar_start_listening;

                    tbReset.Enabled = false;
                    tbReset.ToolTipText = @"复位(需要先连接)";

                    tbChart.Enabled = false;
                    tbChart.ToolTipText = @"查看图表(需要先连接)";

                    lblStatus.Text = @"断开";

                    lblDisconnected.Show();
                    tcChannel.Hide();
                    picLoading.Hide();
 
                    //foreach (var Item in _Slaver.Channels)
                    //{
                    //    Item.DeviceExist = false;
                    //}
                    break;
                case ConnectStatus.Connecting:
                    _log.Show("开始连接...");
                    tbConnet.Enabled = true;
                    tbConnet.ToolTipText = @"取消";
                    tbConnet.Image = Resources.toolbar_cancel;

                    tbStart.Enabled = false;
                    tbStart.ToolTipText = @"开始测量(需要先连接)";

                    tbReset.Enabled = false;
                    tbReset.ToolTipText = @"复位(需要先连接)";

                    tbChart.Enabled = false;
                    tbChart.ToolTipText = @"查看图表(需要先连接)";

                    lblStatus.Text = @"正在连接...";

                    lblDisconnected.Hide();
                    tcChannel.Hide();
                    picLoading.Show();

                    break;
                case ConnectStatus.Connected:
                    tbConnet.Enabled = true;
                    tbConnet.ToolTipText = @"断开连接";
                    tbConnet.Image = Resources.toolbar_disconnect;

                    tbStart.Enabled = true;
                    tbStart.ToolTipText = @"开始测量";
                    tbStart.Image = Resources.toolbar_start_listening;

                    tbReset.Enabled = true;
                    tbReset.ToolTipText = @"复位";

                    tbChart.Enabled = true;
                    tbChart.ToolTipText = @"查看图表";

                    lblStatus.Text = @"已连接";

                    lblDisconnected.Hide();
                    tcChannel.Show();
                    picLoading.Hide();

                    break;
                case ConnectStatus.Measuring:
                    tbConnet.Enabled = false;
                    tbConnet.ToolTipText = @"断开连接";
                    tbConnet.Image = Resources.toolbar_disconnect;

                    tbStart.Enabled = true;
                    tbStart.ToolTipText = @"停止测量";
                    tbStart.Image = Resources.toolbar_stop_listening;

                    tbReset.Enabled = false;
                    tbReset.ToolTipText = @"复位";

                    tbChart.Enabled = false;
                    tbChart.ToolTipText = @"查看图表";

                    lblStatus.Text = @"正在测量...";

                    lblDisconnected.Hide();
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
            if(!_slaver.Connect())
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
            _slaver.Reset();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // 自检
            _slaver.CheckClockStatus();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            _slaver.SelfTest();
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
            _slaver.StartReceiving();
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
            //Invoke(new Action(() => { _slaver.UpdateChannelHealth(); }));
            Invoke(new Action(_slaver.UpdateChannelHealth));
            //_slaver.UpdateChannelHealth();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            _slaver.SelfTest(true);
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            _slaver.Reset();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            Invoke(new Action(() => { _slaver.UpdateChannelExist(); }));
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            // 通道检测
            _log.Print("打开通道检测线程.");
            timChannelUpdate.Start();
            if (bwConnect.CancellationPending)
            {
                e.Cancel = true;
            }
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
        private void TimChannelUpdate_Tick(object sender, EventArgs e)
        {
            if (_channelUpdating)
                return;
            _channelUpdating = true;
            ChannelCheck();
            _channelUpdating = false;
        }
        public void ChannelCheck()
        {
            if (_slaver.Status == ConnectStatus.Connected || _slaver.Status == ConnectStatus.Measuring)
            {
                if (!_slaver.UpdateChannelExist())
                {
                    return;
                }
                _slaver.UpdateChannelData();
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
                LabelFormatter = value => $"{value:F2}",
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
                LabelFormatter = value => $"{value:F5}"
            });
        }

        private void CountDownInit()
        {
            //CountDown = new CountDown();
            //gbTotalChannel.Controls.Add(CountDown);
            CountDown.Location = new Point((gbTotalChannel.Width - CountDown.Width) / 2, (gbTotalChannel.Height - CountDown.Height) / 2);
            CountDown.AfterDone += CountDownAfterDone;
            CountDown.AfterCancel += CountDownAfterDone;
            CountDown.BeforeStart += CountDownBeforeStart;
            CountDown.Hide();
        }
        private void CountDownAfterDone()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(CountDownAfterDone));
                return;
            }
            picLoading.Show();
            CountDown.Hide();
        }
        private void CountDownBeforeStart()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(CountDownBeforeStart));
                return;
            }
            picLoading.Hide();
            CountDown.Show();
        }
        private void WinLoad(object sender, EventArgs e)
        {
            // 注册日志对象
            _log = new Log();
            _log.ShowLogFun += LogPrint;

            _log.Print("程序初始化...");
            CountDownInit();
            _slaver = new SlaverDevice(_log, ChangeStatus, DrawLines, CountDown.Start);  // 主对象
            // 控件注册
            _loadWindow = new LoadWindow();
            
            _slaver.Channels[0].Control = pcc1;
            _slaver.Channels[1].Control = pcc2;
            _slaver.Channels[2].Control = pcc3;
            _slaver.Channels[3].Control = pcc4;
            _slaver.Channels[4].Control = pcc5;
            _slaver.Channels[5].Control = pcc6;

            _slaver.Channels[6].Control = dcc1;
            _slaver.Channels[7].Control = dcc2;
            _slaver.Channels[8].Control = dcc3;
            _slaver.Channels[9].Control = dcc4;

            _slaver.Channels[10].Control = scc;
            _slaver.Channels[11].Control = ecc;
           
            //for (int i = 0; i < 6; i ++)
            //{

            //tpPressure.Controls.Add(_Slaver.Channels[i].Control);
            //_Slaver.Channels[i].Control.Location = 
            //    new System.Drawing.Point(i % 2 == 0 ? 10 : _Slaver.Channels[i].Control.Width + 20,
            //    10 + i / 2 * (_Slaver.Channels[i].Control.Height + 10));
            ////_Slaver.Channels[i].Control.Size = new Size(220, 100);
            //_Slaver.Channels[i].Control.TabIndex = i;
            //_Slaver.Channels[i].Control.TabStop = false;
            //}

            ChartInit();


            _slaver.Status = ConnectStatus.Disconnected;
            cbTriggerMode.SelectedIndex = 0;
            timClock.Start();
            _log.Print("初始化完成.");
        }
        private void WinClosing(object sender, FormClosingEventArgs e)
        {
            if (_slaver.Status == ConnectStatus.Measuring)
            {
                Start(null, null);
                Thread.Sleep(1000);
            }
            if (_slaver.Status == ConnectStatus.Connected)
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
            _slaver.Reset();
            ChartInit();
        }
        private void Connect(object sender, EventArgs e)
        {
            switch (_slaver.Status)
            {
                case ConnectStatus.Disconnected:
                    _log.Print("正在准备连接...");
                    Thread.Sleep(500);
                    bwConnect.RunWorkerAsync();
                    break;
                case ConnectStatus.Connected:
                    timChannelUpdate.Stop();
                    if (bwConnect.IsBusy)
                    {
                        _log.Print("正在取消...");
                        bwConnect.CancelAsync();
                    }
                    //_Connect.Abort();
                    _slaver.Status = ConnectStatus.Disconnected;
                    // 关闭连接
                    _slaver.Close();
                    break;
                case ConnectStatus.Connecting:
                    _log.Print("正在取消...");
                    bwConnect.CancelAsync();
                    break;
            }
            ShowLoadWindow();
        }
        private void Measure(ref BackgroundWorker sender, ref DoWorkEventArgs e)
        {
            _slaver.Status = ConnectStatus.Measuring;
            _log.Print("关闭通道检测线程.");
            timChannelUpdate.Stop();
            _log.Print("正在准备测量...");
            _slaver.StartMeasuring(ref sender, ref e);
            //Log("10秒后重新打开通道检测线程.");
            //Thread.Sleep(10000);
            _log.Print("打开通道检测线程.");
            timChannelUpdate.Start();
            _slaver.Status = ConnectStatus.Connected;
        }
        private void Start(object sender, EventArgs e)
        {
            switch (_slaver.Status)
            {
                case ConnectStatus.Connected:
                    //txtMeasuringTime_LostFocus(null, null);
                    _slaver.MeasuringTime = int.Parse(txtMeasuringTime.Text.Replace(" ", ""));
                    _log.Print("打开测量线程.");
                    bwMeasure.RunWorkerAsync();
                    //_Measure = new Thread(new ThreadStart(Measure));
                    //_Measure.Start();
                    break;
                case ConnectStatus.Measuring:
                    //_Slaver.Status = ConnectStatus.Connected;
                    _log.Print("正在取消...");
                    CountDown.Cancel();
                    bwMeasure.CancelAsync();
                    //tCountDown.Abort();
                    //_Slaver.StopMeasuring();
                    //Log("测量已取消...");
                    break;
            }
        }

        public void DrawLines(BaseChannel[] channels)  // 根据channels绘制曲线
        {

            if (InvokeRequired)
            {
                Invoke(new Action(() => { DrawLines(channels); }));
                return;
            }

            var pointCount = int.Parse(txtPointCount.Text.Replace(" ", ""));
            foreach (var t in channels)
            {
                if (!t.DeviceExist)
                {
                    continue;
                }
                // LiveChart
                object lineSeries = null;
                //var Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint>();
                var values = new GearedValues<LiveCharts.Defaults.ObservablePoint> {Quality = Quality.Low};
                switch (t.Type)
                {
                    case ChannelType.Pressure:
                        lineSeries = new GLineSeries
                        {
                            Fill = Brushes.Transparent,
                            //StrokeThickness = 0.5,
                            Values = values,
                            PointGeometry = null,
                            LineSmoothness = 1,
                            Title = t.Name,
                            AreaLimit = 0,
                        };
                        break;
                    case ChannelType.Digital:
                        lineSeries = new GStepLineSeries()
                        {
                            Fill = Brushes.Transparent,
                            //StrokeThickness = 0.5,
                            Values = values,
                            PointGeometry = null,
                            Title = t.Name,
                        };
                        break;
                    case ChannelType.Speed:
                        break;
                    default:
                        lineSeries = new GLineSeries();
                        break;
                }
                //var Series = new Series();
                //Series.ChartType = SeriesChartType.Spline;
                //Series.BorderWidth = 2;
                //Series.Color = Colors[i];
                //Series.LegendText = Channels[i].Name;
                var x = 0;
                int avgX;
                if (pointCount == 0)
                {
                    avgX = t.MeasuringData.Count;
                }
                else
                {
                    avgX = t.MeasuringData.Count / pointCount;
                }
                foreach (var y in t.MeasuringData)
                {
                    if (x % avgX == 0)
                    {
                        var secX = (x - avgX / 2d) / (2000d * 3.2d);
                        var avgY = y;
                        //Series.Points.AddXY(SecX, AvgY);
                        values.Add(new LiveCharts.Defaults.ObservablePoint(secX, avgY));
                    }
                    x += 1;
                }
                //DataChart.Series.Add(Series);

                lvChart.Series.Add((LiveCharts.Definitions.Series.ISeriesView)lineSeries);
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
            _slaver.TriggerMode = (TriggerMode)cbTriggerMode.SelectedIndex;
            AutoTrigger(cbTriggerMode.SelectedIndex == 0);
        }
        private void cbTriggerChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTriggerChannel.SelectedIndex == -1)
            {
                return;
            }
            _slaver.SetTriggerChannel(int.Parse(System.Text.RegularExpressions.Regex.Replace(cbTriggerChannel.SelectedItem.ToString(), @"[^0-9]+", "")) - 1);
        }

        private void AutoTrigger(bool enable)
        {
            lblTriggerChannel.Enabled = enable;
            cbTriggerChannel.Enabled = enable;
            btnRefreshTriggerChannel.Enabled = enable;
            if (enable)
                RefreshTriggerChannel();
        }
        private void RefreshTriggerChannel()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshTriggerChannel));
                return;
            }
            cbTriggerChannel.Items.Clear();
            for (var i = 0; i < 6; i++)
            {
                if (_slaver.Channels[i].DeviceExist)
                {
                    cbTriggerChannel.Items.Add(_slaver.Channels[i].Name);
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
            _slaver.Status = ConnectStatus.Connecting;
            ConnectControl(ref e);
        }

        private void bwConnect_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bwConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                _log.Print("连接失败.");
                _slaver.Status = ConnectStatus.Disconnected;
                timChannelUpdate.Close();
                _slaver.Close();
            }
            else
            {
                _log.Print("已连接.");
                _slaver.Status = ConnectStatus.Connected;
                RefreshTriggerChannel();
            }
        }

        private void bwMeasure_DoWork(object sender, DoWorkEventArgs e)
        {
            _slaver.Status = ConnectStatus.Measuring;
            Measure(ref bwMeasure, ref e);
        }

        private void bwMeasure_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _log.Print(e.Cancelled ? "测量失败." : "测量完成.");
            _slaver.Status = ConnectStatus.Connected;
        }

        private void ShowConfigWindow(object sender, EventArgs e)
        {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.ShowDialog();
        }

        private void lvChart_DataHover(object sender, ChartPoint chartPoint)
        {
            txtX.Text = $@"{chartPoint.X:F3} s";
            txtY.Text = $@"{chartPoint.Y:F4} MPa";
            //e.Text = string.Format("压力: {1}" + Environment.NewLine + "时间: {0}", txtX.Text, txtY.Text);
        }

        private void Report(object sender, EventArgs e)
        {
            tbReport.Enabled = false;
            bwBuildReport.RunWorkerAsync();
        }

        private void bwBuildReport_DoWork(object sender, DoWorkEventArgs e)
        {
            _log.Print("正在导出报告...");
            var chartBitmap = new Bitmap(lvChart.Width, lvChart.Height);
            Invoke(new Action(() =>
            {
                lvChart.DrawToBitmap(chartBitmap, new Rectangle(0, 0, lvChart.Width, lvChart.Height));
            }));
            //lvChart.DrawToBitmap(ChartBitmap, new Rectangle(0, 0, lvChart.Width, lvChart.Height));
            chartBitmap.Save(Application.StartupPath + "/report/img.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            var report = new PdfReport
            {
                FilePath =
                    $"{Application.StartupPath}/report/{DateTime.Now:yyyyMMddHHmmss}.pdf"
            };
            report.AddTitle("测量报告");
            report.AddEmptyLine();
            report.AddText($"测量日期: {DateTime.Now}");
            report.AddText($"测量时间: {_slaver.MeasuringTime} 毫秒");
            switch (_slaver.TriggerMode)
            {
                case TriggerMode.Auto:
                    var triggerChannel = _slaver.Channels[_slaver.GetTriggerChannel(ChannelType.Pressure)];
                    report.AddText("触发方式: 自动触发");
                    report.AddText($"触发通道: {triggerChannel.Name}");
                    report.AddText($"触发值: {triggerChannel.TriggerIncrement} MPa");
                    break;
                case TriggerMode.Manual:
                    report.AddText("触发方式: 手动触发");
                    break;
                case TriggerMode.External:
                    report.AddText("触发方式: 外触发");
                    break;
                default:
                    report.AddText("触发方式: 异常");
                    break;
            }
            report.AddEmptyLine();
            report.AddText("测量结果:");
            report.AddImage(chartBitmap);
            report.Print();
            //var waterMarkPdfPath = $"report/Report{DateTime.Now:yyyyMMddHHmmss}.pdf";
            _log.Print("导出报告完成，正在打开...");
            report.Open();
        }

        private void bwBuildReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tbReport.Enabled = true;
        }
    }
}
