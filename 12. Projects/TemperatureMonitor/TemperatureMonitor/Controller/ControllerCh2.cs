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
                Device!.GetModbusData(DeviceDataType.Temperature1)
            },
            Device.SlaveId));

            _requestList.Add(new RequestDataSet(new List<ModbusData>
            {
                Device!.GetModbusData(DeviceDataType.Alarm1)
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
