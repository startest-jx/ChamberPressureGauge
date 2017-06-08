using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controls.Channel;
using System.Threading;
using System.ComponentModel;

namespace Slaver.Channel
{
    public class PressureChannel : BaseChannel
    {
        public int Range
        {
            get
            {
                return ((PressureChannelControl)Control).Range;
            }
        }
        public double Calibration
        {
            get
            {
                return ((PressureChannelControl)Control).Calibration;
            }
        }
        public override double ActualValue
        {
            get
            {
                return Formula(CurrentData);
            }
        }

        public PressureChannel(string Name) : base (Name)
        {
            Type = ChannelType.Pressure;
            Control = new PressureChannelControl();
            Control.SetTitle(Name);
        }
        public override double Formula(int OriginData)  // 压力通道公式
        {
            return (Convert.ToDouble(OriginData) * Math.Pow(2, -20) * 25d - 0.25)
                * Range + Calibration;
        }
        public override void RefreshData()
        {
            Control.RefreshData(ActualValue);
        }
        //public override bool WaitTrigger(ref BackgroundWorker sender, ref DoWorkEventArgs e)
        //{
        //    double Increment = 0;
        //    while (Increment < TriggerIncrement)
        //    {
        //        if (sender.CancellationPending)
        //        {
        //            e.Cancel = true;
        //            return false;
        //        }
        //        Increment = AverageData;
        //        Thread.Sleep(5);
        //    }
        //    return true;
        //}
    }
}
