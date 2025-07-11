﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Modbus;

namespace TemperatureMonitor.Device
{
    internal class DeviceCh7 : TemperatureDevice
    {
        public DeviceCh7(byte slaveId) : base(slaveId) { }

        protected override void DeviceSetUp()
        {
            AddDeviceData(DeviceDataType.Temperature1, functionCode: 4, address: 0);
            AddDeviceData(DeviceDataType.Temperature2, functionCode: 4, address: 1);
            AddDeviceData(DeviceDataType.Temperature3, functionCode: 4, address: 2);
            AddDeviceData(DeviceDataType.Temperature4, functionCode: 4, address: 3);
            AddDeviceData(DeviceDataType.Temperature5, functionCode: 4, address: 4);
            AddDeviceData(DeviceDataType.Alarm1, functionCode: 2, address: 0);
            AddDeviceData(DeviceDataType.Alarm2, functionCode: 2, address: 1);
            AddDeviceData(DeviceDataType.Leak1, functionCode: 2, address: 4);
            AddDeviceData(DeviceDataType.Leak2, functionCode: 2, address: 5);
            AddDeviceData(DeviceDataType.ControllerIdSet, functionCode: 6, address: 10);// TODO:추후 수정
            AddDeviceData(DeviceDataType.BaudrateSet, functionCode: 6, address: 11);// TODO:추후 수정
        }
    }
}
