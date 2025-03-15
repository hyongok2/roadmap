using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Modbus;

namespace TemperatureMonitor.Device
{
    public abstract class TemperatureDevice
    {
        public event Action? OnValueChanged;
        public byte SlaveId { get; }

        public Dictionary<DeviceDataType, ModbusData> ModbusDataDictionary { get; } = new Dictionary<DeviceDataType, ModbusData>();

        public TemperatureDevice(byte slaveId)
        {
            SlaveId = slaveId;

            DeviceSetUp();

            ModbusDataDictionary.Values.ToList().ForEach(x => x.OnModbusDataChanged += OnModbusDataChanged);
        }

        protected abstract void DeviceSetUp();

        private void OnModbusDataChanged()
        {
            OnValueChanged?.Invoke();
        }
    }
}
