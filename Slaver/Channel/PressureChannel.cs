using System;
using Controls.Channel;

namespace Slaver.Channel
{
    public class PressureChannel : BaseChannel
    {
        public int Range => ((PressureChannelControl)Control).Range;

        public double Calibration => ((PressureChannelControl)Control).Calibration;

        public override double ActualValue => Formula(CurrentData);

        public PressureChannel(string name) : base (name)
        {
            Type = ChannelType.Pressure;
            //Control = new PressureChannelControl();
            //Control.SetTitle(Name);
        }
        public override double Formula(int originData)  // 压力通道公式
        {
            return (Convert.ToDouble(originData) * Math.Pow(2, -20) * 25d - 0.25)
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
