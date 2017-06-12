using System;

namespace Slaver.Channel
{
    public class DigitalChannel : BaseChannel
    {
        public override double ActualValue => Formula(CurrentData);

        public DigitalChannel(string name) : base (name)
        {
            Type = ChannelType.Digital;
            //Control = new DigitalChannelControl();
            //Control.SetTitle(Name);
        }
        public override double Formula(int originData)  // 数字量/计时通道公式
        {
            return Convert.ToDouble(originData) / 65536d * 5d;
        }
        public override void RefreshData()
        {
            Control.RefreshData(ActualValue);
        }
    }
}
