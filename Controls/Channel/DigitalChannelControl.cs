using System;
using System.Drawing;
using System.Windows.Forms;
//using System.Windows;
//using System.Windows.Media;
using LiveCharts.Wpf;

namespace Controls.Channel
{
    public partial class DigitalChannelControl : VarChannelControl
    {
        // 控件属性
        //public ushort OriginData { set; get; }
        //public double Calibration { set; get; }
        //private int _Range;
        private Label _lblNoDevice;

        public DigitalChannelControl()
        {
            InitializeComponent();

            agMain.LabelFormatter = value => value == 0 ? "0" : $"{value:F0}";
            agMain.LabelsEffect = null;
            agMain.NeedleFill = System.Windows.Media.Brushes.DarkRed;
            agMain.TicksForeground = System.Windows.Media.Brushes.Black;
            agMain.Base.Foreground = System.Windows.Media.Brushes.Black;

            agMain.Base.FontSize = 9;
            agMain.SectionsInnerRadius = 0.85;
            agMain.Wedge = 135;
            agMain.TicksStrokeThickness = 1;

            agMain.FromValue = 0;
            agMain.ToValue = 5;
            agMain.LabelsStep = 1;
            agMain.TickStep = 0.2;

            agMain.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5,
                Fill = System.Windows.Media.Brushes.DodgerBlue,
            });

            OriginData = 0;
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
            _lblNoDevice.Hide();
        }
        public override void Silenced()
        {
            agMain.Hide();
            _lblNoDevice.Location = new Point((Width - _lblNoDevice.Width) / 2, (Height - _lblNoDevice.Height) / 2 + 5);
            _lblNoDevice.Show();
        }
        public override void MarkHealth()
        {
            agMain.Sections[0].Fill = System.Windows.Media.Brushes.DodgerBlue;
        }
        public override void MarkIll()
        {
            agMain.Sections[0].Fill = System.Windows.Media.Brushes.Yellow;
        }
        public override void RefreshData(double currentData)  // 刷新数据
        {
            agMain.Value = Math.Round(currentData, 3);
            agMain.Base.ToolTip = agMain.Value;
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
                Text = @"NO DEVICE"
            };
            //lblNoDevice.Location = new Point(194, 7);
            gbTitle.Controls.Add(_lblNoDevice);
        }
    }
}
