using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Modbus
{
    public class RequestDataSet
    {
        public byte SlaveId { get; }
        public ushort StartAddress { get; }
        public ushort DataSize { get; }
        public byte FunctionCode { get; }

        public List<ModbusData> DataList { get; }

        public RequestMessage RequestMessage { get; }

        public byte[] ReceivedBytes { get; set; } = Array.Empty<byte>();

        public RequestDataSet(List<ModbusData> dataList, byte slaveId)
        {
            DataList = dataList;
            StartAddress = DataList.First().Address;
            DataSize = (ushort)DataList!.Count;
            FunctionCode = DataList.First()!.FunctionCode;
            SlaveId = slaveId;

            RequestMessage = new RequestMessage(slaveId, FunctionCode, StartAddress, DataSize);
        }
    }
}
