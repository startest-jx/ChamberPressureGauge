using System;
using System.Drawing;
using System.Windows.Forms;
//using System.Windows;
//using System.Windows.Media;
using LiveCharts.Wpf;

namespace Controls.Channel
{
    public partial class SpeedChannelControl : VarChannelControl
    {
        // 控件属性
        //public ushort OriginData { set; get; }
        //public double Calibration { set; get; }
        //private int _Range;
        private Label _lblNoDevice;

        public SpeedChannelControl()
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

            agMain.FromValue = 0d;
            agMain.ToValue = 5d;

            agMain.Sections.Add(new AngularSection
            {
                Fill = System.Windows.Media.Brushes.White,
            });
            agMain.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 5d,
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
            ////if (InvokeRequired)
            ////{
            ////    Set me = new Set(Activate);
            ////    Invoke(me);
            ////    return;
            ////}
            //if (agMain.IsHandleCreated)
            //{
            //    agMain.Invoke(new Action(() =>
            //    {
            //        agMain.Show();
            //    }));
            //}
            //if (lblNoDevice.IsHandleCreated)
            //{
            //    lblNoDevice.Invoke(new Action(() =>
            //    {
            //        lblNoDevice.Hide();
            //    }));
            //}
            //try
            //{
            //    agMain.Show();
            //    lblNoDevice.Hide();
            //}
            //catch
            //{

            //}
            agMain.Show();
            _lblNoDevice.Hide();
        }
        public override void Silenced()
        {
            ////if (InvokeRequired)
            ////{
            ////    Set me = new Set(Silenced);
            ////    Invoke(me);
            ////    return;
            ////}
            //if (agMain.IsHandleCreated)
            //{
            //    agMain.Invoke(new Action(() =>
            //    {
            //        agMain.Hide();
            //    }));
            //}
            //if (lblNoDevice.IsHandleCreated)
            //{
            //    lblNoDevice.Invoke(new Action(() =>
            //    {
            //        lblNoDevice.Location = new Point((Width - lblNoDevice.Width) / 2, (Height - lblNoDevice.Height) / 2 + 5);
            //        lblNoDevice.Show();
            //    }));
            //}
            //try
            //{
            //    agMain.Hide();
            //    lblNoDevice.Location = new Point((Width - lblNoDevice.Width) / 2, (Height - lblNoDevice.Height) / 2 + 5);
            //    lblNoDevice.Show();
            //}
            //catch
            //{

            //}
            agMain.Hide();
            _lblNoDevice.Location = new Point((Width - _lblNoDevice.Width) / 2, (Height - _lblNoDevice.Height) / 2 + 5);
            _lblNoDevice.Show();
        }
        public override void MarkHealth()
        {
            //if (agMain.IsHandleCreated)
            //{
            //    agMain.Invoke(new Action(() =>
            //    {
            //        agMain.Sections[0].Fill = System.Windows.Media.Brushes.White;
            //    }));
            //}
            agMain.Sections[0].Fill = System.Windows.Media.Brushes.White;
        }
        public override void MarkIll()
        {
            //if (agMain.IsHandleCreated)
            //{
            //    agMain.Invoke(new Action(() =>
            //    {
            //        agMain.Sections[0].Fill = System.Windows.Media.Brushes.LightYellow;
            //    }));
            //}
            agMain.Sections[0].Fill = System.Windows.Media.Brushes.LightYellow;
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
                Text = "NO DEVICE"
            };
            //lblNoDevice.Location = new Point(194, 7);
            gbTitle.Controls.Add(_lblNoDevice);
        }
    }
}
