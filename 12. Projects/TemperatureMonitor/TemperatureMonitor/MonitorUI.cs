using System.IO.Ports;
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

            comboBox_Comport.Items.AddRange(SerialPort.GetPortNames());
            comboBox_Comport.SelectedIndex = 0;
        }

        bool _isStarting = false;
        private async void button_Start_Click(object sender, EventArgs e)
        {
            if (_isStarting) return;
            _isStarting = true;

            try
            {
                _controller = new MonitorController(comboBox_Comport.Text, int.Parse(comboBox_Baudrate.Text));
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
                textBox_Temperature1.Text = device.ModbusDataDictionary[DeviceDataType.Temperature1].Value.ToString(); ;
                textBox_Temperature2.Text = device.ModbusDataDictionary[DeviceDataType.Temperature2].Value.ToString(); ;
                textBox_Alarm1.Text = device.ModbusDataDictionary[DeviceDataType.Alarm1].Value.ToString(); ;
                textBox_Alarm2.Text = device.ModbusDataDictionary[DeviceDataType.Alarm2].Value.ToString(); ;
                textBox_Leak1.Text = device.ModbusDataDictionary[DeviceDataType.Leak1].Value.ToString(); ;
                textBox_Leak1.Text = device.ModbusDataDictionary[DeviceDataType.Leak2].Value.ToString(); ;
            }));
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            Task.Run(_controller!.Stop);
        }
    }
}