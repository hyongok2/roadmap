using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Modbus
{
    public class WriteMultipleRequestMessage : ModbusCrc, IRequestMessage
    {
        public byte[] Message { get; }

        public WriteMultipleRequestMessage(byte slaveId, ushort startAddress, short[] values)
        {
            byte registerCount = (byte)values.Length;
            byte byteCount = (byte)(registerCount * 2);

            Message = new byte[9 + byteCount];
            Message[0] = slaveId;
            Message[1] = 16;
            Message[2] = (byte)(startAddress >> 8);
            Message[3] = (byte)(startAddress);
            Message[4] = (byte)(registerCount >> 8);
            Message[5] = (byte)(registerCount);
            Message[6] = byteCount;

            for (int i = 0; i < registerCount; i++)
            {
                Message[7 + i * 2] = (byte)(values[i] >> 8);
                Message[8 + i * 2] = (byte)(values[i]);
            }

            ushort crc = GenerateCrc(Message, 7 + byteCount);
            Message[^2] = (byte)crc;
            Message[^1] = (byte)(crc >> 8);
        }
    }

}
