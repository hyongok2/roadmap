using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Device;
using TemperatureMonitor.Modbus;

namespace TemperatureMonitor.Controller
{
    internal class ControllerCh2 : MonitorController
    {
        public ControllerCh2(string portName, int baudRate) : base(portName, baudRate, new DeviceCh2(1)) { }

        protected override void InitialModbusDataSet()
        {
            _requestList.Clear();

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                    _device!.ModbusDataDictionary[DeviceDataType.Temperature1]
                },
            _device.SlaveId));

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                    _device!.ModbusDataDictionary[DeviceDataType.Alarm1]
                },
            _device.SlaveId));

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                { 
                _device !.ModbusDataDictionary[DeviceDataType.Leak1]
            },
            _device.SlaveId));
        }
    }
}
