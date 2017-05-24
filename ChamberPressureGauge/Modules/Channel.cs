using System;
using System.Collections.Generic;
using System.Text;
using ChamberPressureGauge.Controls;
using System.Threading;

namespace ChamberPressureGauge.Modules
{
    public enum ChannelType  // 通道类型
    {
        Pressure,
        Digital,
    }
    public class Channel  // 通道对象
    {
        Mutex HealthLock = new Mutex(), 
            ExistLock = new Mutex(),
            DataLock = new Mutex();
        public ChannelType _Type { set; get; }
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
        //public int Range { set; get; }
        //public double Calibration { set; get; }
        private ushort _CurrenData;
        public ushort CurrentData {
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
        public VarChannel Control;
        public Channel(string Name, ChannelType Type)
        {
            this.Name = Name;
            _Type = Type;
            if (_Type == ChannelType.Pressure)
            {
                Control = new PressureChannel(Name);
            }
            else
            {
                Control = new PressureChannel(Name);
            }
        }
    }
}
