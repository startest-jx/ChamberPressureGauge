using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ChamberPressureGauge.Controls
{
    public partial class VarChannel : UserControl
    {
        private Mutex DataLock = new Mutex(), 
            CalLock = new Mutex();
        private int _OriginData;
        public int OriginData {
            set
            {
                DataLock.WaitOne();
                System.Diagnostics.Debug.WriteLine("set-in");
                _OriginData = value;
                DataLock.ReleaseMutex();
                System.Diagnostics.Debug.WriteLine("set-out");
            }
            get
            {
                DataLock.WaitOne();
                System.Diagnostics.Debug.WriteLine("get-in");
                var temp = _OriginData;
                DataLock.ReleaseMutex();
                System.Diagnostics.Debug.WriteLine("get-out");
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
        public VarChannel()
        {
            InitializeComponent();
        }
        public virtual void RefreshData(int CurrentData)
        {

        }
        public virtual void Activate()
        {

        }
        public virtual void Silenced()
        {

        }
        public virtual void MarkHealth()
        {

        }
        public virtual void MarkIll()
        {

        }
    }
}
