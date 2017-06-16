using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using Controls.Channel;

namespace Slaver.Channel
{
    public enum ChannelType  // 通道类型
    {
        Pressure,
        Digital,
        Speed,
    }
    public abstract class BaseChannel  // 通道对象
    {
        //public delegate void LogFun(string LogInfo);
        //public event SlaverDevice.LogFun Log;
        private readonly Mutex _healthLock = new Mutex();

        private readonly Mutex _existLock = new Mutex();

        private readonly Mutex _dataLock = new Mutex();

        private readonly Mutex _avgLock = new Mutex();

        public ChannelType Type { set; get; }
        public string Name { set; get; }
        private VarChannelControl _control;

        public VarChannelControl Control
        {
            set
            {
                _control = value;
                _control?.SetTitle(Name);
            }
            get => _control;
        }
        private bool _health;
        public bool Health
        {
            set
            {
                _healthLock.WaitOne();
                _health = value;
                _healthLock.ReleaseMutex();
                if (value)
                {
                    Control?.MarkHealth();
                }
                else
                {
                    Control?.MarkIll();
                }
            }
            get
            {
                _healthLock.WaitOne();
                var temp = _health;
                _healthLock.ReleaseMutex();
                return temp;
            }
        }
        private bool _deviceExist;
        public bool DeviceExist
        {
            set
            {
                _existLock.WaitOne();
                _deviceExist = value;
                _existLock.ReleaseMutex();
                if (value)
                {
                    Control?.Activate();
                }
                else
                {
                    Control?.Silenced();
                }
            }
            get
            {
                _existLock.WaitOne();
                var temp = _deviceExist;
                _existLock.ReleaseMutex();
                return temp;
            }
        }
        private int _currenData;
        public int CurrentData
        {
            set
            {
                _dataLock.WaitOne();
                _currenData = value;
                _dataLock.ReleaseMutex();
                //Control.OriginData = value;
            }
            get
            {
                _dataLock.WaitOne();
                var temp = _currenData;
                _dataLock.ReleaseMutex();
                return temp;
            }
        }
        private int _averageData;
        public int AverageData
        {
            set
            {
                _avgLock.WaitOne();
                _averageData = value;
                _avgLock.ReleaseMutex();
            }
            get
            {
                _avgLock.WaitOne();
                var temp = _averageData;
                _avgLock.ReleaseMutex();
                return temp;
            }
        }
        public abstract double ActualValue { get; }
        public bool IsTrigger { set; get; }
        public double TriggerIncrement { set; get; }
        public int TriggerGroupCount { set; get; }
        //public bool WaitTriggerSwitch { set; get; }
        public List<double> MeasuringData { set; get; }
        public Point[] PointData { set; get; }
        protected BaseChannel(string name)
        {
            Name = name;
            TriggerIncrement = 0.05;
            TriggerGroupCount = 32;
        }
        public abstract double Formula(int originData);
        public abstract void RefreshData();
        //public abstract bool WaitTrigger(ref BackgroundWorker sender, ref DoWorkEventArgs e);
        //static public double Formula(int OriginData, int Range, double Calibration)  // 压力通道公式
        //{
        //    return (Convert.ToDouble(OriginData) * Math.Pow(2, -20) * 25d - 0.25)
        //        * Range + Calibration;
        //}
        //static public double Formula(int OriginData, bool Smooth = false)  // 数字量/计时通道公式
        //{
        //    double FormulaData = Convert.ToDouble(OriginData) / 65536d * 5d;
        //    if (Smooth)
        //    {
        //        if (FormulaData >= 5d)
        //        {
        //            return 5d;
        //        }
        //        else
        //        {
        //            return 0d;
        //        }
        //    }
        //    else
        //    {
        //        return FormulaData;
        //    }
        //}
        //public double GetActualValue(DataPanel DataPanel, int MapIndex)
        //{
        //    int OriginData = DataPanel.CurrentData[MapIndex];
        //    return GetActualValue(OriginData);
        //}
        //public double GetActualValue(int OriginData)
        //{
        //    if (Type == ChannelType.Pressure)
        //    {
        //        int Range = ((PressureChannelControl)Control).Range;
        //        double Calibration = ((PressureChannelControl)Control).Calibration;
        //        return Formula(OriginData, Range, Calibration);
        //    }
        //    else if (Type == ChannelType.Digital)
        //    {
        //        return Formula(OriginData);
        //    }
        //    else
        //    {
        //        return OriginData;
        //    }
        //}
        //public void RefreshData()
        //{
        //    Control.RefreshData(GetActualValue(CurrentData));
        //}
        //public bool WaitTriggered(DataPanel DataPanel, int TriggerIndex, ref BackgroundWorker sender, ref DoWorkEventArgs e)
        //{
        //    double Increment = 0;
        //    int MapIndex = -1;
        //    if (TriggerIndex < 6)
        //    {
        //        MapIndex = TriggerIndex + 9;
        //    }
        //    else if (TriggerIndex >= 6 && TriggerIndex < 10)
        //    {
        //        MapIndex = TriggerIndex - 6;
        //    }
        //    //WaitTriggerSwitch = true;
        //    while (Increment < TriggerIncrement)
        //    {
        //        if (sender.CancellationPending)
        //        {
        //            e.Cancel = true;
        //            return false;
        //        }
        //        Increment = GetActualValue(DataPanel.CurAverageData[MapIndex]);
        //        Thread.Sleep(5);
        //    }
        //    return true;

        //}
        public void Smooth()  // 滤波
        {

        }
    }
}
