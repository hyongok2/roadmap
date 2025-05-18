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

        public bool IsWriteData { get; }
        public TaskCompletionSource<bool>? CompletionSource { get; set; } = null;

        public List<ModbusData>? DataList { get; }

        public IRequestMessage RequestMessage { get; }

        public byte[] ReceivedBytes { get; set; } = Array.Empty<byte>();

        public RequestDataSet(List<ModbusData> dataList, byte slaveId)
        {
            DataList = dataList;
            StartAddress = DataList.First().Address;
            DataSize = (ushort)DataList!.Count;
            FunctionCode = DataList.First()!.FunctionCode;
            SlaveId = slaveId;
            IsWriteData = false;
            RequestMessage = new ReadRequestMessage(slaveId, FunctionCode, StartAddress, DataSize);
        }

        public RequestDataSet(ModbusData data, byte slaveId, short value)
        {
            if (!data.IsWriteData || data.FunctionCode != 6)
                throw new InvalidOperationException("해당 데이터는 쓰기 요청이 아닙니다.");

            StartAddress = data.Address;
            DataSize = 1;
            FunctionCode = data.FunctionCode;
            SlaveId = slaveId;
            IsWriteData = true;
            RequestMessage = new WriteSingleRequestMessage(slaveId, data.Address, value);
        }
    }
}
