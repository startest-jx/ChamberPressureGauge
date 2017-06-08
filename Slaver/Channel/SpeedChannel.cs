using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controls.Channel;
using System.Threading;
using System.ComponentModel;

namespace Slaver.Channel
{
    public class SpeedChannel : BaseChannel
    {
        public override double ActualValue
        {
            get
            {
                return Formula(CurrentData);
            }
        }

        public SpeedChannel(string Name) : base (Name)
        {
            Type = ChannelType.Speed;
            Control = new SpeedChannelControl();
            Control.SetTitle(Name);
        }
        public override double Formula(int OriginData)  // 速度通道公式
        {
            return Convert.ToDouble(OriginData) * 0.0505;
        }
        public override void RefreshData()
        {
            Control.RefreshData(ActualValue);
        }
    }
}
