using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureMonitor.Communications
{
    public class SerialCommunication
    {
        private readonly SerialPort? _serialPort;

        public event Action<byte[]>? OnDataReceived;

        public SerialCommunication(string portName, int baudRate, int dataBit, Parity parity, StopBits stopBits)
        {
            _serialPort = new SerialPort
            {
                PortName = portName,
                BaudRate = baudRate,
                Parity = parity,
                StopBits = stopBits,
                DataBits = dataBit
            };

            _serialPort.DataReceived += SerialPort_DataReceived;
            _serialPort.WriteTimeout = 3000;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sender is not SerialPort port) return;

            if (port.BytesToRead == 0) return;

            byte[] buffer = new byte[port.BytesToRead];

            int bytesRead = port.Read(buffer, 0, buffer.Length);

            // 받은 정보를 이벤트로 외부로 전달.
            OnDataReceived?.Invoke(buffer);
        }

        public bool OpenPort()
        {
            try
            {
                _serialPort!.Open();
            }
            catch// (Exception ex) 로그 기능은 추후 필요 시 반영하도록 할 것
            {
                return false;
            }

            return _serialPort!.IsOpen;
        }

        public void ClosePort()
        {
            if (_serialPort!.IsOpen == false) return;

            try
            {
                _serialPort!.Close();
            }
            catch// (Exception ex) 로그 기능은 추후 필요 시 반영하도록 할 것
            {
            }
        }

        public void SendMessage(byte[] message)
        {
            if (_serialPort!.IsOpen == false) return;

            _serialPort!.Write(message, 0, message.Length);
        }

        internal bool IsOpened()
        {
            return _serialPort!.IsOpen;
        }
    }
}
