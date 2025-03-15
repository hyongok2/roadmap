using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Device;
using TemperatureMonitor.Modbus;

namespace TemperatureMonitor.Controller
{
    internal class ControllerCh7 : MonitorController
    {
        public ControllerCh7(string portName, int baudRate) : base(portName, baudRate, new DeviceCh7(1)) { }

        protected override void InitialModbusDataSet()
        {
            _requestList.Clear();

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                    _device!.ModbusDataDictionary[DeviceDataType.Temperature1],
                    _device!.ModbusDataDictionary[DeviceDataType.Temperature2],
                    _device!.ModbusDataDictionary[DeviceDataType.Temperature3],
                    _device!.ModbusDataDictionary[DeviceDataType.Temperature4],
                    _device!.ModbusDataDictionary[DeviceDataType.Temperature5]
                },
            _device.SlaveId));

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                    _device!.ModbusDataDictionary[DeviceDataType.Alarm1],
                    _device!.ModbusDataDictionary[DeviceDataType.Alarm2]
                },
            _device.SlaveId));

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                _device !.ModbusDataDictionary[DeviceDataType.Leak1],
                _device !.ModbusDataDictionary[DeviceDataType.Leak2]
            },
            _device.SlaveId));
        }
    }
}
