using System.IO.Ports;
using TemperatureMonitor.Controller;
using TemperatureMonitor.Device;

namespace TemperatureMonitor
{
    public partial class MonitorUI : Form
    {
        MonitorController? _controller;
        public MonitorUI()
        {
            InitializeComponent();

            SetUpComboBox();
        }

        private void SetUpComboBox()
        {
            comboBox_Baudrate.Items.AddRange(new object[]
            {
                57600,
                38400,
                19200,
                9600,
                4800,
                2400
            });

            comboBox_Baudrate.SelectedIndex = 3;

            string[] portNames = SerialPort.GetPortNames();

            if (portNames.Length > 0)
            {
                comboBox_Comport.Items.AddRange(portNames);
                comboBox_Comport.SelectedIndex = 0;
            }
        }

        bool _isStarting = false;
        private async void button_Start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_Comport.Text)) return;

            if (_isStarting) return;
            _isStarting = true;

            try
            {
                _controller = new ControllerCh3(comboBox_Comport.Text, int.Parse(comboBox_Baudrate.Text));
                _controller.OnTemperatureDeviceValueChanged += Controller_OnTemperatureDeviceValueChanged;

                var result = await Task.Run(_controller.Start);

                if (result == false)
                    MessageBox.Show("Start Fail..");
                else
                    MessageBox.Show("Start Success..");
            }
            catch (Exception)
            {

            }
            finally
            {
                _isStarting = false;
            }
        }

        private void Controller_OnTemperatureDeviceValueChanged(TemperatureDevice device)
        {
            this.Invoke(new Action(() =>
            {
                label_Temp1.Text = device.GetModbusData(DeviceDataType.Temperature1).Value.ToString();
                label_Temp2.Text = device.GetModbusData(DeviceDataType.Temperature2).Value.ToString();
                if (device.GetModbusData(DeviceDataType.Alarm1).Value == 1)
                {
                    label_Alarm1.ForeColor = Color.Red;
                }
                else
                {
                    label_Alarm1.ForeColor = Color.Gray;
                }
                if (device.GetModbusData(DeviceDataType.Alarm2).Value == 1)
                {
                    label_Alarm2.ForeColor = Color.Red;
                }
                else
                {
                    label_Alarm2.ForeColor = Color.Gray;
                }

                if (device.GetModbusData(DeviceDataType.Leak1).Value == 1)
                {
                    label_Leak1.ForeColor = Color.Red;
                }
                else
                {
                    label_Leak1.ForeColor = Color.Gray;
                }
                if (device.GetModbusData(DeviceDataType.Leak2).Value == 1)
                {
                    label_Leak2.ForeColor = Color.Red;
                }
                else
                {
                    label_Leak2.ForeColor = Color.Gray;
                }

            }));
        }

        private void button_Start_Click_1(object sender, EventArgs e)
        {

        }

        //private void button_Stop_Click(object sender, EventArgs e)
        //{
        //    Task.Run(_controller!.Stop);
        //}

    }
}