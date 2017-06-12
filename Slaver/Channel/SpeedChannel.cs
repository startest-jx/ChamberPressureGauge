using System;

namespace Slaver.Channel
{
    public class SpeedChannel : BaseChannel
    {
        public override double ActualValue => Formula(CurrentData);

        public SpeedChannel(string name) : base (name)
        {
            Type = ChannelType.Speed;
            //Control = new SpeedChannelControl();
            //Control.SetTitle(Name);
        }
        public override double Formula(int originData)  // 速度通道公式
        {
            return Convert.ToDouble(originData) * 0.0505;
        }
        public override void RefreshData()
        {
            Control.RefreshData(ActualValue);
        }
    }
}
