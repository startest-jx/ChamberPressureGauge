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
    public partial class DigitalChannelControl : VarChannelControl
    {
        // 控件属性
        //public ushort OriginData { set; get; }
        //public double Calibration { set; get; }
        //private int _Range;

        public DigitalChannelControl()
        {
            InitializeComponent();

            agMain.LabelFormatter = value => value == 0 ? "0" : string.Format("{0:F0}", value);
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
            agMain.Value = Math.Round(CurrentData, 3);
            agMain.Base.ToolTip = agMain.Value;
        }
    }
}
