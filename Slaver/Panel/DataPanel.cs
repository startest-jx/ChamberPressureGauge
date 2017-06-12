using System.Collections.Generic;
using System.Threading;
using Communication.Base;
using Slaver.Channel;
using Device = Communication.Ethernet.Device;

namespace Slaver.Panel
{
    public class DataPanel : Device, IData
    {
        private readonly Mutex _dataLock = new Mutex();

        private readonly Mutex _stockLock = new Mutex();

        private readonly Mutex _curAvLock = new Mutex();

        private readonly Mutex _preAvLock = new Mutex();

        public int[] CurrentData = new int[16];
        public List<int[]> DataStock { set; get; }
        private bool _dataStoreSwitch;
        private long _dataStoreCount;
        //public List<int[]> temp_lst { set; get; }
        //public List<int[]> _temp_lst { set; get; }
        // 用于计算斜率
        private int[] _preAverageData;
        public int[] PreAverageData
        {
            set
            {
                _preAvLock.WaitOne();
                _preAverageData = value;
                _preAvLock.ReleaseMutex();
            }
            get
            {
                _preAvLock.WaitOne();
                var temp = _preAverageData;
                _preAvLock.ReleaseMutex();
                return temp;
            }
        }
        private int[] _curAverageData;
        public int[] CurAverageData
        {
            set
            {
                _curAvLock.WaitOne();
                _curAverageData = value;
                _curAvLock.ReleaseMutex();
            }
            get
            {
                _curAvLock.WaitOne();
                var temp = _curAverageData;
                _curAvLock.ReleaseMutex();
                return temp;
            }
        }
        public DataPanel(string host, int port) : base(host, port)
        {
            _preAverageData = new int[16];
            _curAverageData = new int[16];
            for (var i = 0; i < _curAverageData.Length; i++)
            {
                _curAverageData[i] = 0;
            }
            LengthSwitch = true;
            ReceiveTimeOut = 500;
            ReceiveBufferSize = 1024;
            _dataStoreSwitch = false;
            _dataStoreCount = 0;
        }
        public void DataUpdate(byte[] readBuffer, int offset, int length)  // 接收采集板发来的16进制数据，并将其转换成双字节数组
        {
            //temp_lst = new List<int[]>();
            //_temp_lst = new List<int[]>();
            var curSumData = new int[16];
            for (var bufferIndex = 0; bufferIndex < length; bufferIndex += 32)
            {
                var dataArray = new int[16];
                for (var arrayIndex = 0; arrayIndex < 16; arrayIndex++)
                {
                    dataArray[arrayIndex] = (readBuffer[bufferIndex + 2 * arrayIndex + 1] << 8) | readBuffer[bufferIndex + 2 * arrayIndex];
                    curSumData[arrayIndex] += dataArray[arrayIndex];
                }
                //_temp_lst.Add(DataArray);
                _dataLock.WaitOne();
                CurrentData = dataArray;
                _dataLock.ReleaseMutex();
                if (DataStock == null) continue;
                if (!_dataStoreSwitch) continue;
                if (_dataStoreCount == 0 || DataStock.Count < _dataStoreCount)
                {
                    _stockLock.WaitOne();
                    DataStock.Add(dataArray);
                    _stockLock.ReleaseMutex();
                }
                else
                {
                    _dataStoreSwitch = false;
                    _dataStoreCount = 0;
                }
            }
            _preAvLock.WaitOne();
            _curAvLock.WaitOne();
            _preAverageData = _curAverageData;
            for (var i = 0; i < curSumData.Length; i++)
            {
                _curAverageData[i] = curSumData[i] / 32;
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

            _curAvLock.ReleaseMutex();
            _preAvLock.ReleaseMutex();
        }
        public List<int[]> DataStoreByTime(int recordTime)
        {
            DataStock = new List<int[]>();
            _dataStoreSwitch = true;
            Thread.Sleep(recordTime);
            _dataStoreSwitch = false;
            return DataStock;
        }
        public List<int[]> DataStoreByCount(long count)
        {
            DataStock = new List<int[]>();
            _dataStoreCount = count;
            _dataStoreSwitch = true;
            long stockLength = 0;
            while (stockLength < count)
            {
                _stockLock.WaitOne();
                stockLength = DataStock.Count;
                _stockLock.ReleaseMutex();
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
            byte[] bytes = { 0x00, 0x01, 0x02, 0x03 };
            Send(bytes, 0, bytes.Length);
            //DataLock.WaitOne();
            //DataStock.Clear();
            //DataLock.ReleaseMutex();
        }
        public void StartReceiving()
        {
            byte[] bytes = { 0xFF, 0xFE, 0x00, 0x01, 0x01 };
            Send(bytes, 0, bytes.Length);
        }
        public void StopReceiving()
        {
            byte[] bytes = { 0xFF, 0xFE, 0x00, 0x01, 0x00 };
            Send(bytes, 0, bytes.Length);
        }
        public void SetGroupCount()
        {
            byte[] bytes = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x09, 0x01, 0x10, 0x00, 0x14, 0x00, 0x01, 0x02, 0x00, 0x20 };
            Send(bytes, 0, bytes.Length);
        }
        public void StartPicking()
        {
            byte[] bytes = { 0xFF, 0xFD, 0x00, 0x01, 0x01 };
            Send(bytes, 0, bytes.Length);
        }
        public void CheckChannelStatus(ref BaseChannel[] channels)
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
            var channelValueSum = new long[channels.Length];
            for (var i = 0; i < channels.Length; i++)
                channelValueSum[i] = 0;
            _stockLock.WaitOne();
            var dataStockLength = DataStock.Count;
            foreach (var t in DataStock)
            {
                channelValueSum[0] += t[9];
                channelValueSum[1] += t[10];
                channelValueSum[2] += t[11];
                channelValueSum[3] += t[12];
                channelValueSum[4] += t[13];
                channelValueSum[5] += t[14];
                channelValueSum[6] += t[0];
                channelValueSum[7] += t[1];
                channelValueSum[8] += t[2];
                channelValueSum[9] += t[3];
            }
            _stockLock.ReleaseMutex();
            for (var i = 0; i < channels.Length; i++)
            {
                channels[i].Health = channelValueSum[i] > 52000 * dataStockLength;
            }
        }
        public void GetCurrentChannelData(ref BaseChannel[] channels)
        {
            for (var i = 0; i < 12; i++)
            {
                int mapIndex;
                if (i < 6)
                {
                    mapIndex = i + 9;
                }
                else if (i >= 6 && i < 10)
                {
                    mapIndex = i - 6;
                }
                else if (i == 10)
                {
                    mapIndex = 15;
                }
                else
                {

                    continue;
                }
                _dataLock.WaitOne();
                channels[i].CurrentData = CurrentData[mapIndex];
                _dataLock.ReleaseMutex();
            }
        }
    }
}
