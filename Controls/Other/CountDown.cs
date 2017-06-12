using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System;

namespace Controls.Other
{
    public partial class CountDown : UserControl
    {
        private double _initValue;
        public event Action AfterDone;
        public event Action AfterCancel;
        public event Action BeforeStart;

        public CountDown()
        {
            InitializeComponent();
        }

        public void Start(double second)
        {
            BeforeStart?.Invoke();
            _initValue = second;
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
            txtCountDown.Text = $@"{value:F2}s";
        }

        private void bwCountDown_DoWork(object sender, DoWorkEventArgs e)
        {
            while (_initValue >= 0)
            {
                if (bwCountDown.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                Invoke(new Action(() => { ChangeValue(_initValue); }));
                //txtCountDown.Text = string.Format("{0:F2}s", InitValue);
                _initValue -= 0.01;
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
