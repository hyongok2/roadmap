using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TemperatureMonitor.Device;

namespace TemperatureMonitor.Modbus
{
    public class ModbusData
    {
        public DeviceDataType Type { get;}

        public event Action? OnModbusDataChanged;
        public byte FunctionCode { get; set; }

        public ushort Address { get; set; }

        private short _value;
        public short Value
        {
            get
            {
                return _value;
            }
            set 
            {
                if (_value == value) return;
                _value = value;

                OnModbusDataChanged?.Invoke();
            }
        }

        public ModbusData(DeviceDataType type, byte functionCode, ushort address)
        {
            Type = type;
            FunctionCode = functionCode;
            Address = address;
        }
    }
}
