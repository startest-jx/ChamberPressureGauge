using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ChamberPressureGauge.Controls
{
    public class ChannelData : TextBox
    {
        private delegate void _delegate();//声明代理  
        public ChannelData()
        {
            ReadOnly = true;
            TabStop = false;
            TextAlign = HorizontalAlignment.Right;
        }
        public void Activate()
        {
            Enabled = true;
            //Text = "- DEVICE FOUND -";
        }
        public void Silenced()
        {
            Enabled = false;
            if (InvokeRequired)
            {
                _delegate me = new _delegate(Silenced);
                Invoke(me);
            }
            else
            {
                Text = "- NO DEVICE -";
            }
        }
        public void MarkHealth()
        {
            if (InvokeRequired)
            {
                _delegate me = new _delegate(MarkHealth);
                Invoke(me);
            }
            else
            {
                BackColor = System.Drawing.Color.White;
            }
        }
        public void MarkIll()
        {
            if (InvokeRequired)
            {
                _delegate me = new _delegate(MarkIll);
                Invoke(me);
            }
            else
            {
                BackColor = System.Drawing.Color.Red;
            }
        }
    }
}
