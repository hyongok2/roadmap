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

        private Dictionary<DeviceDataType, ModbusData> ModbusDataDictionary { get; } = new Dictionary<DeviceDataType, ModbusData>();

        public TemperatureDevice(byte slaveId)
        {
            SlaveId = slaveId;

            DeviceSetUp();

            ModbusDataDictionary.Values.ToList().ForEach(x => x.OnModbusDataChanged += OnModbusDataChanged);
        }

        protected abstract void DeviceSetUp();

        protected void AddDeviceData(DeviceDataType type, byte functionCode, ushort address)
        {
            ModbusDataDictionary.Add(type, new ModbusData(type, functionCode, address));
        }

        private void OnModbusDataChanged()
        {
            OnValueChanged?.Invoke();
        }

        public ModbusData GetModbusData(DeviceDataType type)
        {
            return ModbusDataDictionary.TryGetValue(type, out ModbusData? value) ? value : throw new Exception();
        }

        public Dictionary<DeviceDataType, ModbusData> GetAllModbusData()
        {
            return ModbusDataDictionary;
        }
    }
}
