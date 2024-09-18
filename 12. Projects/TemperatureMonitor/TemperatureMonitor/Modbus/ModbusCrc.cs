using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TemperatureMonitor.Modbus
{
    public class ModbusCrc
    {
        protected static ushort GenerateCrc(byte[] message, int size)
        {
            ushort crc = 0xFFFF; // 초기 값 0xFFFF
            for (int i = 0; i < size; i++)
            {
                crc ^= message[i]; // 데이터와 CRC를 XOR

                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x0001) != 0) // LSB(가장 오른쪽 비트)가 1이면
                    {
                        crc >>= 1;
                        crc ^= 0xA001; // 0xA001 다항식 적용
                    }
                    else
                    {
                        crc >>= 1; // 비트 우측으로 시프트
                    }
                }
            }

            return crc; // 최종 CRC 값 반환
        }
    }
}
