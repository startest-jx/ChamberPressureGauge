using System;
using System.Collections.Generic;
using System.Text;
using ChamberPressureGauge.Controls;
using System.Threading;
using System.Drawing;
using System.ComponentModel;

namespace ChamberPressureGauge.Modules
{
    public enum ChannelType  // 通道类型
    {
        Pressure,
        Digital,
    }
    public class Channel  // 通道对象
    {
        //public delegate void LogFun(string LogInfo);
        public event Slaver.LogFun Log;
        Mutex HealthLock = new Mutex(), 
            ExistLock = new Mutex(),
            DataLock = new Mutex();
        public ChannelType Type { set; get; }
        public string Name { set; get; }
        private bool _Health;
        public bool Health {
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
        public bool DeviceExist {
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
        public int CurrentData {
            set
            {
                DataLock.WaitOne();
                _CurrenData = value;
                DataLock.ReleaseMutex();
                Control.OriginData = value;
            }
            get
            {
                DataLock.WaitOne();
                var temp = _CurrenData;
                DataLock.ReleaseMutex();
                return temp;
            }
        }
        public bool IsTrigger { set; get; }
        public double TriggerIncrement { set; get; }
        public int TriggerGroupCount { set; get; }
        //public bool WaitTriggerSwitch { set; get; }
        public VarChannel Control;
        public List<double> MeasuringData { set; get; }
        public Point[] PointData { set; get; }
        public Channel(string Name, ChannelType Type, Slaver.LogFun Log)
        {
            this.Name = Name;
            this.Type = Type;
            if (Type == ChannelType.Pressure)
            {
                Control = new PressureChannel(Name);
            }
            else
            {
                Control = new PressureChannel(Name);
            }
            TriggerIncrement = 0.05;
            TriggerGroupCount = 32;
            this.Log = Log;
        }
        static public double PressureFormula(int OriginData, int Range, double Calibration)
        {
            return (Convert.ToDouble(OriginData) * Math.Pow(2, -20) * 25 - 0.25) 
                * Range + Calibration;
        }
        static public double DigitalFormula(int OriginData)
        {
            return Convert.ToDouble(OriginData) / 65536 * 5;
        }
        public double GetActualValue(DgtlPanel DgtlPanel, int MapIndex)
        {
            int OriginData = DgtlPanel.CurrentData[MapIndex];
            return GetActualValue(OriginData);
        }
        public double GetActualValue(int OriginData)
        {
            if (Type == ChannelType.Pressure)
            {
                int Range = ((PressureChannel)Control).Range;
                double Calibration = ((PressureChannel)Control).Calibration;
                return PressureFormula(OriginData, Range, Calibration);
            }
            else if (Type == ChannelType.Digital)
            {
                return DigitalFormula(OriginData);
            }
            else
            {
                return OriginData;
            }
        }
        public void RefreshData()
        {
            Control.RefreshData(CurrentData);
        }
        public bool WaitTriggered(DgtlPanel DgtlPanel, int TriggerIndex, ref BackgroundWorker sender, ref DoWorkEventArgs e)
        {
            double Increment = 0;
            int MapIndex = -1;
            if (TriggerIndex < 6)
            {
                MapIndex = TriggerIndex + 9;
            }
            else if (TriggerIndex >= 6 && TriggerIndex < 10)
            {
                MapIndex = TriggerIndex - 6;
            }
            //WaitTriggerSwitch = true;
            while (Increment < TriggerIncrement)
            {
                if (sender.CancellationPending)
                {
                    e.Cancel = true;
                    return false;
                }
                //Increment 
                //    = GetActualValue(DgtlPanel.CurAverageData[MapIndex]) 
                //    - GetActualValue(DgtlPanel.PreAverageData[MapIndex]);
                //Increment = GetActualValue(DgtlPanel.CurrentData[MapIndex]);
                Increment = GetActualValue(DgtlPanel.CurAverageData[MapIndex]);
                //if (Increment > 0.02)
                //{
                //    Log(string.Format("Data = {0}, delta = {1}", DgtlPanel.CurrentData[MapIndex], Increment));
                //    if (DgtlPanel.temp_lst == null)
                //        continue;
                    
                //    foreach (var Item in DgtlPanel.temp_lst)
                //    {
                //        string s = "";
                //        foreach (var ItemItem in Item)
                //        {
                //            s += string.Format("{0} ", ItemItem);
                //        }
                //        Log(s);
                //    }
                    
                //}

                Thread.Sleep(5);
            }
            return true;
            //if (WaitTriggerSwitch)
            //{
            //    WaitTriggerSwitch = false;
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        public void Smooth()
        {

        }
    }
}
