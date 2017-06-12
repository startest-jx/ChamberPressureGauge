namespace Communication.Base
{
    public enum DeviceType
    {
        Ethernet,
        SerialPort,
        UniversalSerialBus,
    }
    public abstract class Device  // 通用抽象设备
    {
        public DeviceType Type { get; }

        protected Device(DeviceType type)
        {
            Type = type;
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
