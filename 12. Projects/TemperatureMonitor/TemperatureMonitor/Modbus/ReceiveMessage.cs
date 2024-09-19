using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Modbus
{
    public class ReceiveMessage : ModbusCrc
    {
        public bool IsValid { get; private set; } = false;
        public short[] DataArray { get; private set; } = Array.Empty<short>();
        public byte SlaveId { get; private set; }
        public byte FunctionCode { get; private set; }
        public int DataCount { get; private set; } = 0;

        public ReceiveMessage(byte[] message)
        {
            if (message == null) return;

            if (message.Length < 5) return; // 최소 5개 이상이어야 함. Slave / Function Code / DataSize / Data array... / CRC Code

            if (ValidCheckCrc(message) == false) return;

            SlaveId = message[0];
            FunctionCode = message[1];
            byte dataSize = message[2];

            if (dataSize <= 0) return;

            IsValid = true;

            if(FunctionCode == 4)
            {
                DataCount = dataSize / 2;

                DataArray = new short[DataCount];

                for (int i = 0; i < dataSize; i += 2)
                {
                    DataArray[i / 2] = (short)(message[3 + i] << 8 | message[3 + i + 1]);
                }
            }

            if (FunctionCode == 2)
            {
                DataCount = dataSize * 8;//임시로 1바이트만 처리되는 것으로 하자. 나중에 다양하게 호환 가능하게 수정할 것
                DataArray = new short[DataCount];

                for (int i = 0; i < DataCount; i ++)
                {
                    DataArray[i] = (short)(message[3] >> i & 1);
                }
            }

        }

        private static bool ValidCheckCrc(byte[] message)
        {
            ushort checkCrc = GenerateCrc(message, message.Length - 2);

            ushort receivedCrc = (ushort)(message[^2] | message[^1] << 8);

            return receivedCrc == checkCrc;
        }
    }
}
