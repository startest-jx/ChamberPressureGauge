using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Controls.Channel
{
    public partial class VarChannelControl : UserControl
    {
        private Mutex DataLock = new Mutex();
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

        public VarChannelControl()
        {
            InitializeComponent();
        }
        public virtual void SetTitle(string Title)
        {

        }
        public virtual void RefreshData(double CurrentData)
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
