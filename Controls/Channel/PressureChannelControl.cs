using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
//using System.Windows;
//using System.Windows.Media;
using LiveCharts.Wpf;

namespace Controls.Channel
{
    public partial class PressureChannelControl : VarChannelControl
    {
        // 控件属性
        //public ushort OriginData { set; get; }
        //public double Calibration { set; get; }
        //private int _Range;
        private Label _lblNoDevice;
        private readonly Mutex _rangeLock = new Mutex();

        private readonly Mutex _calLock = new Mutex();

        private int _range;
        public int Range
        {
            set
            {
                _rangeLock.WaitOne();
                _range = value;
                _rangeLock.ReleaseMutex();
                cbRange.SelectedItem = $"{value} MPa";
            }
            get
            {
                _rangeLock.WaitOne();
                var temp = _range;
                _rangeLock.ReleaseMutex();
                return temp;
            }
        }
        private double _calibration;
        public double Calibration
        {
            set
            {
                _calLock.WaitOne();
                _calibration = value;
                _calLock.ReleaseMutex();
            }
            get
            {
                _calLock.WaitOne();
                var temp = _calibration;
                _calLock.ReleaseMutex();
                return temp;
            }
        }

        public PressureChannelControl()
        {
            InitializeComponent();

            agMain.LabelFormatter = value => value == 0 ? "0" : $"{value:F1}";
            agMain.LabelsEffect = null;
            agMain.NeedleFill = System.Windows.Media.Brushes.DarkRed;
            agMain.TicksForeground = System.Windows.Media.Brushes.Black;
            agMain.Base.Foreground = System.Windows.Media.Brushes.Black;

            agMain.Base.FontSize = 9;
            agMain.SectionsInnerRadius = 0.85;
            agMain.Wedge = 135;
            agMain.TicksStrokeThickness = 1;

            agMain.Sections.Add(new AngularSection
            {
                Fill = System.Windows.Media.Brushes.White,
            });
            agMain.Sections.Add(new AngularSection
            {
                FromValue = 0.05,
                Fill = System.Windows.Media.Brushes.DodgerBlue,
            });

            OriginData = 0;
            Range = 1;
            Calibration = 0;
            txtCalibration.Text = $"{Calibration:F4}";
            NoDeviceLabelInit();
            Activate();
        }
        public override void SetTitle(string title)
        {
            gbTitle.Text = title;
        }
        public sealed override void Activate()
        {
            agMain.Show();
            cbRange.Show();
            txtCalibration.Show();
            _lblNoDevice.Hide();
        }
        public override void Silenced()
        {
            agMain.Hide();
            cbRange.Hide();
            txtCalibration.Hide();
            _lblNoDevice.Location = new Point((Width - _lblNoDevice.Width) / 2, (Height - _lblNoDevice.Height) / 2 + 5);
            _lblNoDevice.Show();
        }
        public override void MarkHealth()
        {
            agMain.Sections[1].Fill = System.Windows.Media.Brushes.DodgerBlue;
        }
        public override void MarkIll()
        {
            agMain.Sections[1].Fill = System.Windows.Media.Brushes.Yellow;
        }
        public override void RefreshData(double currentData)  // 刷新数据
        {

            // 更新Calibration
            var temp = double.Parse(txtCalibration.Text);
            Calibration = temp;
            agMain.Value = Math.Round(currentData, 3);
            agMain.Base.ToolTip = agMain.Value;
        }
        private void cbRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 更新Range
            _rangeLock.WaitOne();
            _range = int.Parse(System.Text.RegularExpressions.Regex.Replace(cbRange.SelectedItem.ToString(), @"[^0-9]+", ""));
            _rangeLock.ReleaseMutex();

            agMain.FromValue = agMain.Sections[0].FromValue = - Range;
            agMain.ToValue = agMain.Sections[0].ToValue = agMain.Sections[1].ToValue = Range;
            agMain.LabelsStep = Range / 2d;
            agMain.TickStep = Range / 20d;
            //agMain.Sections[0].Fill = System.Windows.Media.Brushes.White;

            txtCalibration.Minimum = -Range;
            txtCalibration.Maximum = Range;
        }

        private void NoDeviceLabelInit()
        {
            _lblNoDevice = new Label
            {
                AutoSize = true,
                Font = new Font("Cambria", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.DodgerBlue,
                Name = "lblNoDevice",
                Size = new Size(203, 43),
                TabIndex = 5,
                Text = "NO DEVICE"
            };
            //lblNoDevice.Location = new Point(194, 7);
            gbTitle.Controls.Add(_lblNoDevice);
        }
    }
}
