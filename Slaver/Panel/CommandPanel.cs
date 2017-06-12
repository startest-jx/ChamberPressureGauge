using System;
using System.Text;
using Communication.Base;
using Slaver.Channel;
using Device = Communication.Ethernet.Device;

namespace Slaver.Panel
{
    public class CommandPanel : Device, ICommand
    {
        public CommandPanel(string host, int port) : base (host, port)
        {
            ReceiveTimeOut = 500;
            ReceiveBufferSize = 1024;
        }
        public bool StartReading() => base.StartReading(16);
        public string SendCmd(string send, bool rtExist = false, int timeOut = -1)
        {
            var formatSend = $"#{send}\n";
            var sendBytes = Encoding.Default.GetBytes(formatSend);
            Send(sendBytes, sendBytes.Length, 0);
            string returnString = null;
            var preSec = DateTime.Now.ToBinary();
            var curSec = DateTime.Now.ToBinary();
            while (rtExist && returnString == null && (curSec - preSec <= timeOut || timeOut < 0))
            {
                returnString = ReadReceived();
            }
            return returnString;
        }
        public string ReadReceived()
        {
            BufferLock.WaitOne();
            if (ReveivedBuffer != null)
            {
                var str = Encoding.Default.GetString(ReveivedBuffer);
                if (str[0] == 0x23 && str[str.Length - 1] == 0x0A)
                {
                    ReveivedBuffer = null;  // 清除原有接收数据
                    BufferLock.ReleaseMutex();
                    return str.Substring(1, str.Length - 2);
                }
            }
            BufferLock.ReleaseMutex();
            return null;
        }
        public void SelfTest() => SendCmd("SELFTEST");
        public void SelfTest(bool isSuccess) => SendCmd(isSuccess ? "TESTPASSED" : "TESTFAILED");
        public bool CheckChannelStatus(ref BaseChannel[] channels)
        {
            //bool[] ChannelStatus = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false, };
            var channelStatusString = SendCmd("LINESTATUE", true, 500);
            if (channelStatusString == null)
                return false;
            for (var i = 0; i < channelStatusString.Length; i++)
            {
                channels[i].DeviceExist = channelStatusString[i] == '0';
            }
            return true;
        }
        public bool CheckClockStatus() => SendCmd("CLOCKSTA", true) == "CLKSUCCEED";
        public void Reset() => SendCmd("RESET");
    }
}
