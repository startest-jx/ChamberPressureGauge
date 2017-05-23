using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ChamberPressureGauge.Modules
{
    public enum ChannelType
    {
        Pressure,
        Digital,
    }
    public class Channel
    {
        public ChannelType _Type { set; get; }
        public string Name { set; get; }
        public bool Health { set; get; }
        public bool DeviceExist { set; get; }
        public int Range { set; get; }
        public double Calibration { set; get; }
        public double CurrentData { set; get; }
        public Channel(string Name, ChannelType Type, bool IsHealthy)
        {
            this.Name = Name;
            _Type = Type;
            Health = IsHealthy;
        }
    }
    public class ChnLED : TextBox
    {
        public ChnLED()
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
            Text = "- NO DEVICE -";
        }
        public void MarkHealth()
        {
            BackColor = System.Drawing.Color.White;
        }
        public void MarkIll()
        {
            BackColor = System.Drawing.Color.Red;
        }
    }
}
