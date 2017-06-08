using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using Controls.Channel;
using Slaver.Panel;
using System.Windows.Forms;

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
        Mutex HealthLock = new Mutex(),
            ExistLock = new Mutex(),
            DataLock = new Mutex(),
            AvgLock = new Mutex();
        public ChannelType Type { set; get; }
        public string Name { set; get; }
        public VarChannelControl Control;
        private bool _Health;
        public bool Health
        {
            set
            {
                HealthLock.WaitOne();
                _Health = value;
                HealthLock.ReleaseMutex();
                if (value)
                {
                    Control.MarkHealth();
                }
                else
                {
                    Control.MarkIll();
                }
            }
            get
            {
                HealthLock.WaitOne();
                var temp = _Health;
                HealthLock.ReleaseMutex();
                return temp;
            }
        }
        private bool _DeviceExist;
        public bool DeviceExist
        {
            set
            {
                ExistLock.WaitOne();
                _DeviceExist = value;
                ExistLock.ReleaseMutex();
                if (value)
                {
                    Control.Activate();
                }
                else
                {
                    Control.Silenced();
                }
            }
            get
            {
                ExistLock.WaitOne();
                var temp = _DeviceExist;
                ExistLock.ReleaseMutex();
                return temp;
            }
        }
        private int _CurrenData;
        public int CurrentData
        {
            set
            {
                DataLock.WaitOne();
                _CurrenData = value;
                DataLock.ReleaseMutex();
                //Control.OriginData = value;
            }
            get
            {
                DataLock.WaitOne();
                var temp = _CurrenData;
                DataLock.ReleaseMutex();
                return temp;
            }
        }
        private int _AverageData;
        public int AverageData
        {
            set
            {
                AvgLock.WaitOne();
                _AverageData = value;
                AvgLock.ReleaseMutex();
            }
            get
            {
                AvgLock.WaitOne();
                var temp = _AverageData;
                AvgLock.ReleaseMutex();
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
        protected BaseChannel(string Name)
        {
            this.Name = Name;
            TriggerIncrement = 0.05;
            TriggerGroupCount = 32;
        }
        public abstract double Formula(int OriginData);
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
