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
                    Device!.ModbusDataDictionary[DeviceDataType.Temperature1],
                    Device!.ModbusDataDictionary[DeviceDataType.Temperature2],
                    Device!.ModbusDataDictionary[DeviceDataType.Temperature3],
                    Device!.ModbusDataDictionary[DeviceDataType.Temperature4],
                    Device!.ModbusDataDictionary[DeviceDataType.Temperature5]
                },
            Device.SlaveId));

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                    Device!.ModbusDataDictionary[DeviceDataType.Alarm1],
                    Device!.ModbusDataDictionary[DeviceDataType.Alarm2]
                },
            Device.SlaveId));

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                Device !.ModbusDataDictionary[DeviceDataType.Leak1],
                Device !.ModbusDataDictionary[DeviceDataType.Leak2]
            },
            Device.SlaveId));
        }
    }
}
