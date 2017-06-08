using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
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
        private Mutex RangeLock = new Mutex(),
            CalLock = new Mutex();
        private int _Range;
        public int Range
        {
            set
            {
                RangeLock.WaitOne();
                _Range = value;
                RangeLock.ReleaseMutex();
                cbRange.SelectedItem = string.Format("{0} MPa", value);
            }
            get
            {
                RangeLock.WaitOne();
                var temp = _Range;
                RangeLock.ReleaseMutex();
                return temp;
            }
        }
        private double _Calibration;
        public double Calibration
        {
            set
            {
                CalLock.WaitOne();
                _Calibration = value;
                CalLock.ReleaseMutex();
            }
            get
            {
                CalLock.WaitOne();
                var temp = _Calibration;
                CalLock.ReleaseMutex();
                return temp;
            }
        }

        public PressureChannelControl()
        {
            InitializeComponent();

            agMain.LabelFormatter = value => value == 0 ? "0" : string.Format("{0:F1}", value);
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
            txtCalibration.Text = string.Format("{0:000.0000}", Calibration);
        }
        public override void SetTitle(string Title)
        {
            gbTitle.Text = Title;
        }
        public override void Activate()
        {
            //if (InvokeRequired)
            //{
            //    Set me = new Set(Activate);
            //    Invoke(me);
            //    return;
            //}
            if (agMain.IsHandleCreated)
            {
                agMain.Invoke(new Action(() =>
                {
                    agMain.Show();
                }));
            }
            if (cbRange.IsHandleCreated)
            {
                cbRange.Invoke(new Action(() =>
                {
                    cbRange.Show();
                }));
            }
            if (txtCalibration.IsHandleCreated)
            {
                txtCalibration.Invoke(new Action(() =>
                {
                    txtCalibration.Show();
                }));
            }
            if (lblNoDevice.IsHandleCreated)
            {
                lblNoDevice.Invoke(new Action(() =>
                {
                    lblNoDevice.Hide();
                }));
            }
            //agMain.Show();
            //cbRange.Show();
            //txtCalibration.Show();
            //lblNoDevice.Hide();
        }
        public override void Silenced()
        {
            //if (InvokeRequired)
            //{
            //    Set me = new Set(Silenced);
            //    Invoke(me);
            //    return;
            //}
            if (agMain.IsHandleCreated)
            {
                agMain.Invoke(new Action(() =>
                {
                    agMain.Hide();
                }));
            }
            if (cbRange.IsHandleCreated)
            {
                cbRange.Invoke(new Action(() =>
                {
                    cbRange.Hide();
                }));
            }
            if (txtCalibration.IsHandleCreated)
            {
                txtCalibration.Invoke(new Action(() =>
                {
                    txtCalibration.Hide();
                }));
            }
            if (lblNoDevice.IsHandleCreated)
            {
                lblNoDevice.Invoke(new Action(() =>
                {
                    lblNoDevice.Location = new Point((Width - lblNoDevice.Width) / 2, (Height - lblNoDevice.Height) / 2 + 5);
                    lblNoDevice.Show();
                }));
            }
            //agMain.Hide();
            //cbRange.Hide();
            //txtCalibration.Hide();
            //lblNoDevice.Location = new Point((Width - lblNoDevice.Width) / 2, (Height - lblNoDevice.Height) / 2 + 5);
            //lblNoDevice.Show();
        }
        public override void MarkHealth()
        {
            if (agMain.IsHandleCreated)
            {
                agMain.Invoke(new Action(() =>
                {
                    agMain.Sections[0].Fill = System.Windows.Media.Brushes.White;
                }));
            }
        }
        public override void MarkIll()
        {
            if (agMain.IsHandleCreated)
            {
                agMain.Invoke(new Action(() =>
                {
                    agMain.Sections[0].Fill = System.Windows.Media.Brushes.LightYellow;
                }));
            }
        }
        public override void RefreshData(double CurrentData)  // 刷新数据
        {

            // 更新Calibration
            var temp = double.Parse(txtCalibration.Text);
            Calibration = temp;
            agMain.Value = Math.Round(CurrentData, 3);
            agMain.Base.ToolTip = agMain.Value;
        }
        private void cbRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 更新Range
            RangeLock.WaitOne();
            _Range = int.Parse(System.Text.RegularExpressions.Regex.Replace(cbRange.SelectedItem.ToString(), @"[^0-9]+", ""));
            RangeLock.ReleaseMutex();

            agMain.FromValue = agMain.Sections[0].FromValue = - Range;
            agMain.ToValue = agMain.Sections[0].ToValue = agMain.Sections[1].ToValue = Range;
            agMain.LabelsStep = Range / 2d;
            agMain.TickStep = Range / 20d;
            //agMain.Sections[0].Fill = System.Windows.Media.Brushes.White;

            txtCalibration.Minimum = -Range;
            txtCalibration.Maximum = Range;
        }
    }
}
