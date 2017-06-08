using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Slaver.Channel
{
    public interface IChannel
    {
        double Formula(int OriginData);
        void RefreshData();
        //bool WaitTrigger(ref BackgroundWorker sender, ref DoWorkEventArgs e);
    }
}
