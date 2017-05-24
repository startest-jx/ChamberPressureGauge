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
    public abstract partial class VarChannel : UserControl
    {
        private Mutex DataLock = new Mutex(), 
            CalLock = new Mutex();
        private ushort _OriginData;
        public ushort OriginData {
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
        public abstract void RefreshData();
        public abstract void Activate();
        public abstract void Silenced();
        public abstract void MarkHealth();
        public abstract void MarkIll();
    }
}
