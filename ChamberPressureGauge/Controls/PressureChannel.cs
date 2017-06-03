using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ChamberPressureGauge.Modules;

namespace ChamberPressureGauge.Controls
{
    public partial class PressureChannel : VarChannel
    {
        // 控件属性
        //public ushort OriginData { set; get; }
        //public double Calibration { set; get; }
        //private int _Range;
        private delegate void Set();
        private Mutex RangeLock = new Mutex();
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


        public PressureChannel(string Name)
        {
            InitializeComponent();
            this.Name = Name;
            gbTitle.Text = this.Name;
            OriginData = 0;
            Range = 1;
            Calibration = 0;
            txtCalibration.Text = string.Format("{0:000.0000}", Calibration);
        }
        public override void Activate()
        {
            if (InvokeRequired)
            {
                Set me = new Set(Activate);
                Invoke(me);
                return;
            }
            sgData.Show();
            cbRange.Show();
            txtCalibration.Show();
            lblNoDevice.Hide();
        }
        public override void Silenced()
        {
            if (InvokeRequired)
            {
                Set me = new Set(Silenced);
                Invoke(me);
                return;
            }
            sgData.Hide();
            cbRange.Hide();
            txtCalibration.Hide();
            lblNoDevice.Location = new Point((Width - lblNoDevice.Width) / 2, (Height - lblNoDevice.Height) / 2 + 5);
            lblNoDevice.Show();

        }
        public override void MarkHealth()
        {
            if (sgData.IsHandleCreated)
            {
                sgData.Invoke(new Action(() =>
                {
                    sgData.FromColor = System.Windows.Media.Color.FromArgb(0xFF, 0x64, 0xB4, 0xF5);
                    sgData.ToColor = System.Windows.Media.Color.FromArgb(0xFF, 0x15, 0x65, 0xBF);
                }));
            }
        }
        public override void MarkIll()
        {
            if (sgData.IsHandleCreated)
            {
                sgData.Invoke(new Action(() =>
                {
                    sgData.FromColor = System.Windows.Media.Color.FromArgb(0xFF, 0xFF, 0xB4, 0xF5);
                    sgData.ToColor = System.Windows.Media.Color.FromArgb(0xFF, 0xFF, 0x65, 0xBF);
                }));
            }
        }
        public override void RefreshData(int CurrentData)  // 刷新数据
        {
            // 更新Range
            RangeLock.WaitOne();
            _Range = int.Parse(System.Text.RegularExpressions.Regex.Replace(cbRange.SelectedItem.ToString(), @"[^0-9]+", ""));
            RangeLock.ReleaseMutex();

            // 更新Calibration
            var temp = double.Parse(txtCalibration.Text);
            Calibration = temp;


            //RangeLock.WaitOne();
            //temp = _Range;
            //RangeLock.ReleaseMutex();
            //double Data = (Convert.ToDouble(OriginData) * Math.Pow(2, -20) * 25 - 0.25) * temp + Calibration;
            double Data = Channel.PressureFormula(CurrentData, Range, Calibration);
            //txtChannelData.Text = string.Format("{0:000.0000}", Data);
            sgData.Value = Math.Round(Data, 3); ;
        }
        private void cbRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            sgData.From = -Range;
            sgData.To = Range;
        }
    }
}
