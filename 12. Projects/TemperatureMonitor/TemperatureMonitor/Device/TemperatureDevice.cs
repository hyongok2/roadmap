using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Modbus;

namespace TemperatureMonitor.Device
{
    public class TemperatureDevice
    {
        public event Action? OnValueChanged;
        public byte SlaveId { get; }

        public Dictionary<DeviceDataType, ModbusData> ModbusDataDictionary { get; } = new Dictionary<DeviceDataType, ModbusData>();

        public TemperatureDevice(byte slaveId)
        {
            SlaveId = slaveId;

            DeviceSetUp();
        }

        private void DeviceSetUp()
        {
            ModbusDataDictionary.Add(DeviceDataType.Temperature1, new ModbusData(DeviceDataType.Temperature1, functionCode: 4, address: 0));
            ModbusDataDictionary.Add(DeviceDataType.Temperature2, new ModbusData(DeviceDataType.Temperature2, functionCode: 4, address: 1));
            ModbusDataDictionary.Add(DeviceDataType.Alarm1, new ModbusData(DeviceDataType.Alarm1, functionCode: 2, address: 0));
            ModbusDataDictionary.Add(DeviceDataType.Alarm2, new ModbusData(DeviceDataType.Alarm2, functionCode: 2, address: 1));
            ModbusDataDictionary.Add(DeviceDataType.Leak1, new ModbusData(DeviceDataType.Leak1, functionCode: 2, address: 4));
            ModbusDataDictionary.Add(DeviceDataType.Leak2, new ModbusData(DeviceDataType.Leak2, functionCode: 2, address: 5));

            ModbusDataDictionary.Values.ToList().ForEach(x => x.OnModbusDataChanged += OnModbusDataChanged);
        }

        private void OnModbusDataChanged()
        {
            OnValueChanged?.Invoke();
        }
    }
}
