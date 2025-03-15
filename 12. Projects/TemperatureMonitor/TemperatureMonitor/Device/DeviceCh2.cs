using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Modbus;

namespace TemperatureMonitor.Device
{
    internal class DeviceCh2 : TemperatureDevice
    {
        public DeviceCh2(byte slaveId) : base(slaveId) { }

        protected override void DeviceSetUp()
        {
            ModbusDataDictionary.Add(DeviceDataType.Temperature1, new ModbusData(DeviceDataType.Temperature1, functionCode: 4, address: 0));
            ModbusDataDictionary.Add(DeviceDataType.Alarm1, new ModbusData(DeviceDataType.Alarm1, functionCode: 2, address: 0));
            ModbusDataDictionary.Add(DeviceDataType.Leak1, new ModbusData(DeviceDataType.Leak1, functionCode: 2, address: 4));
        }
    }
}
