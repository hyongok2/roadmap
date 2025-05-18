using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Modbus
{
    public class ReadRequestMessage : ModbusCrc, IRequestMessage
    {
        const int RequestMessageSize = 8;

        public byte[] Message { get; } = new byte[RequestMessageSize];
        public ReadRequestMessage(byte slaveId, byte functionCode, ushort startAddress, ushort dataSize)
        {
            Message[0] = slaveId;
            Message[1] = functionCode;
            Message[2] = (byte)(startAddress >> 8); ;
            Message[3] = (byte)startAddress;
            Message[4] = (byte)(dataSize >> 8);
            Message[5] = (byte)dataSize;

            ushort crc = GenerateCrc(Message, size: 6);

            Message[6] = (byte)crc;
            Message[7] = (byte)(crc >> 8);
        }
    }
}
