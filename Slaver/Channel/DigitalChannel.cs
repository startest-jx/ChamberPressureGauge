using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controls.Channel;
using System.Threading;
using System.ComponentModel;

namespace Slaver.Channel
{
    public class DigitalChannel : BaseChannel
    {
        public override double ActualValue
        {
            get
            {
                return Formula(CurrentData);
            }
        }

        public DigitalChannel(string Name) : base (Name)
        {
            Type = ChannelType.Digital;
            Control = new DigitalChannelControl();
            Control.SetTitle(Name);
        }
        public override double Formula(int OriginData)  // 数字量/计时通道公式
        {
            return Convert.ToDouble(OriginData) / 65536d * 5d;
        }
        public override void RefreshData()
        {
            Control.RefreshData(ActualValue);
        }
    }
}
