namespace Slaver.Channel
{
    public interface IChannel
    {
        double Formula(int originData);
        void RefreshData();
        //bool WaitTrigger(ref BackgroundWorker sender, ref DoWorkEventArgs e);
    }
}
