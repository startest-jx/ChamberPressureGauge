using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ChamberPressureGauge.Controls
{
    public partial class CountDown : UserControl
    {
        private double InitValue;
        public delegate void _delegate();
        public _delegate AfterDone { set; get; }
        public _delegate AfterCancel { set; get; }
        public _delegate BeforeStart { set; get; }
        private delegate void _ChangeValue(double value);


        public CountDown()
        {
            InitializeComponent();
        }

        public void Start(double second)
        {
            BeforeStart?.Invoke();
            InitValue = second;
            bwCountDown.RunWorkerAsync();
        }

        public void Cancel()
        {
            if (bwCountDown.IsBusy)
            {
                bwCountDown.CancelAsync();
            }
        }

        private void ChangeValue(double value)
        {
            txtCountDown.Text = string.Format("{0:F2}s", value);
        }

        private void bwCountDown_DoWork(object sender, DoWorkEventArgs e)
        {
            while (InitValue >= 0)
            {
                if (bwCountDown.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                if (InvokeRequired)
                {
                    _ChangeValue me = new _ChangeValue(ChangeValue);
                    object[] arg = new object[] { InitValue };
                    Invoke(me, arg);
                }
                else
                {
                    ChangeValue(InitValue);
                }
                //txtCountDown.Text = string.Format("{0:F2}s", InitValue);
                InitValue -= 0.01;
                Thread.Sleep(10);
            }
        }

        private void bwCountDown_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                AfterCancel?.Invoke();
            }
            else
            {
                AfterDone?.Invoke();
            }
        }
    }
}
