using System;
using System.Collections.Generic;
using System.Text;

namespace Communication.Base
{
    public enum DeviceType
    {
        Ethernet,
        SerialPort,
        USB,
    }
    public abstract class Device  // 通用抽象设备
    {
        public DeviceType Type { get; }
        public Device(DeviceType Type)
        {
            this.Type = Type;
        }

        public abstract bool Open();
        public abstract bool IsOpen();
        public abstract void Close();
        public abstract bool Send(byte[] send, int offSet, int count);
        protected abstract void Read(object bytes);
        public abstract bool StartReading(int bytes);
        public abstract bool StopReading();
    }
}
