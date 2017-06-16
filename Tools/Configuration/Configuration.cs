using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Configuration
{
    internal class Configuration
    {
        public class ConnectionConfig
        {
            public int TimeOut { set; get; }

            public class CommandPanel
            {
                public string IpAddress { set; get; }
                public int Port { set; get; }
            }
            public CommandPanel MyCommandPanel { set; get; }
            public class DigitalPanel
            {
                public string IpAddress { set; get; }
                public int Port { set; get; }
            }
            public DigitalPanel MyDigitalPanel { set; get; }
        }
        public ConnectionConfig MyConnection { set; get; }

        public class MeasuringConfig
        {
            public enum MeasuringMode
            {
                Auto,
                Manual
            }
            public enum TriggerMode
            {
                Threshold,
                Increment
            }
            public MeasuringMode DefaultMeasuringMode { set; get; }
            public class AutoTrigger
            {
                public int DefaultTriggerChannel { set; get; }
                public TriggerMode TriggerMode { set; get; }
                public double TriggerValue { set; get; }
                public int MeasuringTime { set; get; }
            }
            public AutoTrigger MyAutoTrigger { set; get; }

            public class ManualTigger
            {
                public int MeasuringTime { set; get; }
            }
            public ManualTigger MyManualTigger { set; get; }
        }
        public MeasuringConfig MyMeasuring { set; get; }

        public class DataConfig
        {
            
        }
        public DataConfig MyData { set; get; }

        public class ReportConfig
        {
            public string Title { set; get; }
            public string Author { set; get; }
            public string Subject { set; get; }
            public string DateTime { set; get; }
            public string Path { set; get; }
            public bool AutoOpen { set; get; }
            public class Content
            {
                public bool Trigger{ set; get; }
                public bool Pressure { set; get; }
                public bool Digital { set; get; }
                public bool Chart { set; get; }
            }
            public Content MyContent { set; get; }
        }
        public ReportConfig MyReport { set; get; }

        public class ChartConfig
        {
            
        }
        public ChartConfig MyChart { set; get; }
    }
}
