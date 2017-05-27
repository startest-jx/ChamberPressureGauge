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
        private delegate void _RefreshData();
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
            txtChannelData.Text = string.Format("{0:000.0000}", 0);
            Range = 10;
            Calibration = 0;
            txtCalibration.Text = string.Format("{0:000.0000}", Calibration);
        }
        public override void Activate()
        {
            txtChannelData.Activate();
        }
        public override void Silenced()
        {
            txtChannelData.Silenced();
        }
        public override void MarkHealth()
        {
            txtChannelData.MarkHealth();
        }
        public override void MarkIll()
        {
            txtChannelData.MarkIll();
        }
        public override void RefreshData(int CurrentData)  // 刷新数据
        {
            // 更新Range
            RangeLock.WaitOne();
            _Range = int.Parse(System.Text.RegularExpressions.Regex.Replace(cbRange.SelectedItem.ToString(), @"[^0-9]+", ""));
            RangeLock.ReleaseMutex();

            // 更新Calibration
            var temp = Calibration;
            try
            {
                temp = double.Parse(txtCalibration.Text);
            }
            catch
            {

            }
            Calibration = temp;


            //RangeLock.WaitOne();
            //temp = _Range;
            //RangeLock.ReleaseMutex();
            //double Data = (Convert.ToDouble(OriginData) * Math.Pow(2, -20) * 25 - 0.25) * temp + Calibration;
            double Data = Channel.PressureFormula(CurrentData, Range, Calibration);
            txtChannelData.Text = string.Format("{0:000.0000}", Data);
        }
        private void cbRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RangeLock.WaitOne();
            //_Range = int.Parse(System.Text.RegularExpressions.Regex.Replace(cbRange.SelectedItem.ToString(), @"[^0-9]+", ""));
            //RangeLock.ReleaseMutex();
        }

        private void txtCalibration_LostFocus(object sender, EventArgs e)
        {
            txtCalibration.Text = string.Format("{0:000.0000}", Calibration);
        }

        private void Increase(object sender, EventArgs e)
        {
            Calibration += 0.0001;
            txtCalibration.Text = string.Format("{0:000.0000}", Calibration);
        }

        private void Decrease(object sender, EventArgs e)
        {
            Calibration -= 0.0001;
            txtCalibration.Text = string.Format("{0:000.0000}", Calibration);
        }
    }
}
