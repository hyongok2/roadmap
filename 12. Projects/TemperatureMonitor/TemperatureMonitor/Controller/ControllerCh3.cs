using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureMonitor.Device;
using TemperatureMonitor.Modbus;

namespace TemperatureMonitor.Controller
{
    internal class ControllerCh3 : MonitorController
    {
        public ControllerCh3(string portName, int baudRate) : base(portName, baudRate, new DeviceCh3(1)) { }

        protected override void InitialModbusDataSet()
        {
            _requestList.Clear();

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                    Device!.GetModbusData(DeviceDataType.Temperature1),
                    Device!.GetModbusData(DeviceDataType.Temperature2)
                },
            Device.SlaveId));

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                    Device!.GetModbusData(DeviceDataType.Alarm1),
                    Device!.GetModbusData(DeviceDataType.Alarm2)
                },
            Device.SlaveId));

            _requestList.Add(new RequestDataSet(new List<ModbusData>
                {
                Device!.GetModbusData(DeviceDataType.Leak1)
            },
            Device.SlaveId));
        }
    }
}
