using System;
using System.Collections.Generic;
using System.Text;
using Communication;
using Communication.Ethernet;
using System.Threading;
using Slaver.Channel;

namespace Slaver.Panel
{
    public class DataPanel : Device, IData
    {
        private Mutex DataLock = new Mutex(),
            StockLock = new Mutex(),
            CurAvLock = new Mutex(),
            PreAvLock = new Mutex();
        public int[] CurrentData = new int[16];
        public List<int[]> DataStock { set; get; }
        private bool DataStoreSwitch = false;
        private long DataStoreCount = 0;
        //public List<int[]> temp_lst { set; get; }
        //public List<int[]> _temp_lst { set; get; }
        // 用于计算斜率
        private int[] _PreAverageData;
        public int[] PreAverageData
        {
            set
            {
                PreAvLock.WaitOne();
                _PreAverageData = value;
                PreAvLock.ReleaseMutex();
            }
            get
            {
                PreAvLock.WaitOne();
                var temp = _PreAverageData;
                PreAvLock.ReleaseMutex();
                return temp;
            }
        }
        private int[] _CurAverageData;
        public int[] CurAverageData
        {
            set
            {
                CurAvLock.WaitOne();
                _CurAverageData = value;
                CurAvLock.ReleaseMutex();
            }
            get
            {
                CurAvLock.WaitOne();
                var temp = _CurAverageData;
                CurAvLock.ReleaseMutex();
                return temp;
            }
        }
        public DataPanel(string host, int port) : base(host, port, true)
        {
            _PreAverageData = new int[16];
            _CurAverageData = new int[16];
            for (int i = 0; i < _CurAverageData.Length; i++)
            {
                _CurAverageData[i] = 0;
            }
            LengthSwitch = true;
        }
        public void DataUpdate(byte[] readBuffer, int offset, int length)  // 接收采集板发来的16进制数据，并将其转换成双字节数组
        {
            //temp_lst = new List<int[]>();
            //_temp_lst = new List<int[]>();
            int[] CurSumData = new int[16];
            for (int BufferIndex = 0; BufferIndex < length; BufferIndex += 32)
            {
                var DataArray = new int[16];
                for (int ArrayIndex = 0; ArrayIndex < 16; ArrayIndex++)
                {
                    DataArray[ArrayIndex] = (readBuffer[BufferIndex + 2 * ArrayIndex + 1] << 8) | readBuffer[BufferIndex + 2 * ArrayIndex];
                    CurSumData[ArrayIndex] += DataArray[ArrayIndex];
                }
                //_temp_lst.Add(DataArray);
                DataLock.WaitOne();
                CurrentData = DataArray;
                DataLock.ReleaseMutex();
                if (DataStock != null)
                {
                    if (DataStoreSwitch)
                    {
                        if (DataStoreCount == 0 || DataStock.Count < DataStoreCount)
                        {
                            StockLock.WaitOne();
                            DataStock.Add(DataArray);
                            StockLock.ReleaseMutex();
                        }
                        else
                        {
                            DataStoreSwitch = false;
                            DataStoreCount = 0;
                        }
                    }
                }
            }
            PreAvLock.WaitOne();
            CurAvLock.WaitOne();
            _PreAverageData = _CurAverageData;
            for (int i = 0; i < CurSumData.Length; i++)
            {
                _CurAverageData[i] = CurSumData[i] / 32;
                //DataLock.WaitOne();
                //CurrentData[i] = CurSumData[i] / 32;
                //DataLock.ReleaseMutex();
            }
            //DataLock.WaitOne();
            //if (CurrentData[10] > 30000)
            //{
            //    for (int i = 0; i < 16; i ++)
            //    {
            //        temp_lst = _temp_lst;
            //    }
            //}
            //DataLock.ReleaseMutex();

            CurAvLock.ReleaseMutex();
            PreAvLock.ReleaseMutex();
        }
        public List<int[]> DataStoreByTime(int RecordTime)
        {
            DataStock = new List<int[]>();
            DataStoreSwitch = true;
            Thread.Sleep(RecordTime);
            DataStoreSwitch = false;
            return DataStock;
        }
        public List<int[]> DataStoreByCount(long Count)
        {
            DataStock = new List<int[]>();
            DataStoreCount = Count;
            DataStoreSwitch = true;
            long StockLength = 0;
            while (StockLength < Count)
            {
                StockLock.WaitOne();
                StockLength = DataStock.Count;
                StockLock.ReleaseMutex();
                //Thread.Sleep(200);
            }
            //DataStoreCount = 0;
            return DataStock;
        }
        public bool StartReading()
        {
            return base.StartReading(1024);
        }
        public void Reset()
        {
            byte[] Bytes = { 0x00, 0x01, 0x02, 0x03 };
            Send(Bytes, 0, Bytes.Length);
            //DataLock.WaitOne();
            //DataStock.Clear();
            //DataLock.ReleaseMutex();
        }
        public void StartReceiving()
        {
            byte[] Bytes = { 0xFF, 0xFE, 0x00, 0x01, 0x01 };
            Send(Bytes, 0, Bytes.Length);
        }
        public void StopReceiving()
        {
            byte[] Bytes = { 0xFF, 0xFE, 0x00, 0x01, 0x00 };
            Send(Bytes, 0, Bytes.Length);
        }
        public void SetGroupCount()
        {
            byte[] Bytes = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x09, 0x01, 0x10, 0x00, 0x14, 0x00, 0x01, 0x02, 0x00, 0x20 };
            Send(Bytes, 0, Bytes.Length);
        }
        public void StartPicking()
        {
            byte[] Bytes = { 0xFF, 0xFD, 0x00, 0x01, 0x01 };
            Send(Bytes, 0, Bytes.Length);
        }
        public void CheckChannelStatus(ref Channel.BaseChannel[] Channels)
        {
            // 接收1秒钟的数据
            DataStoreByTime(1000);
            //long PreSec = DateTime.Now.ToBinary();
            //long CurSec = DateTime.Now.ToBinary();
            //while (CurSec - PreSec < 1000)
            //{
            //    if (IsNewData)
            //    {
            //        DataLock.WaitOne();
            //        DataStock.Add(CurrentData);
            //        IsNewData = false;
            //        DataLock.ReleaseMutex();
            //    }
            //    CurSec = DateTime.Now.ToBinary();
            //}
            long[] ChannelValueSum = new long[Channels.Length];
            for (int i = 0; i < Channels.Length; i++)
                ChannelValueSum[i] = 0;
            StockLock.WaitOne();
            var DataStockLength = DataStock.Count;
            foreach (var DataArray in DataStock)
            {
                ChannelValueSum[0] += DataArray[9];
                ChannelValueSum[1] += DataArray[10];
                ChannelValueSum[2] += DataArray[11];
                ChannelValueSum[3] += DataArray[12];
                ChannelValueSum[4] += DataArray[13];
                ChannelValueSum[5] += DataArray[14];
                ChannelValueSum[6] += DataArray[0];
                ChannelValueSum[7] += DataArray[1];
                ChannelValueSum[8] += DataArray[2];
                ChannelValueSum[9] += DataArray[3];
            }
            StockLock.ReleaseMutex();
            for (int i = 0; i < Channels.Length; i++)
            {
                if (ChannelValueSum[i] > 52000 * DataStockLength)
                {
                    Channels[i].Health = true;
                }
                else
                {
                    Channels[i].Health = false;
                }
            }
        }
        public void GetCurrentChannelData(ref BaseChannel[] Channels)
        {
            for (int i = 0; i < 6; i++)
            {
                DataLock.WaitOne();
                Channels[i].CurrentData = CurrentData[i + 9];
                DataLock.ReleaseMutex();
            }
        }
    }
}
