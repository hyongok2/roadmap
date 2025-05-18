using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Modbus
{
    public class WriteSingleRequestMessage : ModbusCrc, IRequestMessage
    {
        public byte[] Message { get; }

        public WriteSingleRequestMessage(byte slaveId, ushort address, short value)
        {
            Message = new byte[8];

            Message[0] = slaveId;
            Message[1] = 6;
            Message[2] = (byte)(address >> 8);
            Message[3] = (byte)(address);
            Message[4] = (byte)(value >> 8);
            Message[5] = (byte)(value);

            ushort crc = GenerateCrc(Message, 6);
            Message[6] = (byte)(crc);
            Message[7] = (byte)(crc >> 8);
        }
    }

}
