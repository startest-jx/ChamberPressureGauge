using System.Windows.Forms;
using System.Threading;

namespace Controls.Channel
{
    public partial class VarChannelControl : UserControl
    {
        private readonly Mutex _dataLock = new Mutex();
        private int _originData;
        public int OriginData {
            set
            {
                _dataLock.WaitOne();
                _originData = value;
                _dataLock.ReleaseMutex();
            }
            get
            {
                _dataLock.WaitOne();
                var temp = _originData;
                _dataLock.ReleaseMutex();
                return temp;
            }
        }

        public VarChannelControl()
        {
            InitializeComponent();
        }
        public virtual void SetTitle(string title)
        {

        }
        public virtual void RefreshData(double currentData)
        {

        }
        public virtual void Activate()
        {

        }
        public virtual void Silenced()
        {

        }
        public virtual void MarkHealth()
        {

        }
        public virtual void MarkIll()
        {

        }
    }
}
