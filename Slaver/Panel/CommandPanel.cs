using System;
using System.Collections.Generic;
using System.Text;
using Communication;
using Communication.Ethernet;
using Slaver.Channel;

namespace Slaver.Panel
{
    public class CommandPanel : Device, ICommand
    {
        public CommandPanel(string host, int port) : base (host, port)
        {

        }
        public bool StartRead()
        {
            return StartReading(16);
        }
        public string SendCmd(string send, bool rtExist = false, int TimeOut = -1)
        {
            string FormatSend = string.Format("#{0}\n", send);
            byte[] SendBytes = Encoding.Default.GetBytes(FormatSend);
            Send(SendBytes, SendBytes.Length, 0);
            string ReturnString = null;
            long PreSec = DateTime.Now.ToBinary();
            long CurSec = DateTime.Now.ToBinary();
            while (rtExist && ReturnString == null && (CurSec - PreSec <= TimeOut || TimeOut < 0))
            {
                ReturnString = ReadReceived();
            }
            return ReturnString;
        }
        public string ReadReceived()
        {
            BufferLock.WaitOne();
            if (ReveivedBuffer != null)
            {
                string str = Encoding.Default.GetString(ReveivedBuffer);
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
        public void SelfTest()
        {
            SendCmd("SELFTEST");
        }
        public void SelfTest(bool IsSuccess)
        {
            if (IsSuccess)
                SendCmd("TESTPASSED");
            else
                SendCmd("TESTFAILED");
        }
        public bool CheckChannelStatus(ref BaseChannel[] Channels)
        {
            //bool[] ChannelStatus = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false, };
            string ChannelStatusString = SendCmd("LINESTATUE", true, 500);
            if (ChannelStatusString != null)
            {
                for (int i = 0; i < ChannelStatusString.Length; i++)
                {
                    if (ChannelStatusString[i] == '0')
                    {
                        Channels[i].DeviceExist = true;
                    }
                    else
                    {
                        Channels[i].DeviceExist = false;
                    }
                }
                return true;
            }
            return false;
        }
        public bool CheckClockStatus()
        {
            string ClockStatus = SendCmd("CLOCKSTA", true);
            if (ClockStatus == "CLKSUCCEED")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            SendCmd("RESET");
        }
    }
}
