using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureMonitor.Controller;
using TemperatureMonitor.Device;
using TemperatureMonitor.Modbus;

namespace TemperatureMonitor.Forms
{
    public partial class MonitorCh2 : Form
    {
        #region 멤버 변수
        private MonitorController? _controller;

        private const string ModelName = "TML-R";
        private const string LoggingFilePath = @"C:\Temperature Log\";// 고정 경로로 지정함.

        private bool _isConnected = false;

        private bool _isLogging = false;

        private DateTime _loggingStartTime = DateTime.Now;

        private CancellationTokenSource cts = new();
        #endregion

        #region 생성자
        public MonitorCh2()
        {
            InitializeComponent();

            SetUpComboBox();
        }
        #endregion

        #region 초기 셋업 함수
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
        private void textBox_SettingHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자 또는 제어 키(백스페이스, 탭 등)만 허용
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)  // 8은 백스페이스 키
            {
                e.Handled = true;  // 숫자가 아닌 키는 무시
            }
        }
        #endregion

        #region 통신 연결 부
        bool _isStarting = false;

        private async void button_Connect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox_Comport.Text)) return;
            if (_isConnected) return;

            if (_isStarting) return;
            _isStarting = true;

            try
            {
                _controller = new ControllerCh2(comboBox_Comport.Text, int.Parse(comboBox_Baudrate.Text));
                _controller.OnTemperatureDeviceValueChanged += Controller_OnTemperatureDeviceValueChanged;

                var result = await Task.Run(_controller.Start);

                if (result == false)
                    MessageBox.Show("연결에 실패하였습니다.");
                else
                {
                    MessageBox.Show("정상적으로 연결되었습니다.");
                    _isConnected = true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                _isStarting = false;
            }
        }
        #endregion

        #region 화면 표시 처리

        private void Controller_OnTemperatureDeviceValueChanged(TemperatureDevice device)
        {
            this.Invoke(new Action(() =>
            {
                label_Temp1.Text = device.ModbusDataDictionary[DeviceDataType.Temperature1].Value.ToString();
                if (device.ModbusDataDictionary[DeviceDataType.Alarm1].Value == 1)
                {
                    label_Alarm1.ForeColor = Color.Red;
                }
                else
                {
                    label_Alarm1.ForeColor = Color.Gray;
                }
                if (device.ModbusDataDictionary[DeviceDataType.Leak1].Value == 1)
                {
                    label_Leak1.ForeColor = Color.Red;
                }
                else
                {
                    label_Leak1.ForeColor = Color.Gray;
                }
            }));
        }

        private void timer_Display_Tick(object sender, EventArgs e)
        {
            if (_isConnected) label_Running.ForeColor = Color.Lime;
            else label_Running.ForeColor = Color.Gray;

            if (_isLogging)
            {
                label_Status.Text = "측정 기록 중";
                if (DateTime.Now.Second % 2 == 0)
                    label_Status.ForeColor = Color.Black;
                else
                    label_Status.ForeColor = Color.White;

                textBox_ProgressHour.Text = (DateTime.Now - _loggingStartTime).Hours.ToString();
            }
            else
            {
                label_Status.Text = "측정 대기 중";
                label_Status.ForeColor = Color.White;
            }
        }
        #endregion

        #region Logging 공통 함수
        private async void button_LoggingStart_Click(object sender, EventArgs e)
        {
            #region 사전 조건  Check
            if (_isConnected == false) return;
            if (_isLogging) return;

            if (int.TryParse(textBox_SettingHours.Text, out int settingHours) == false) return;
            if (settingHours < 1) return;
            #endregion

            #region 설정 정보 확인 및 화면 표시
            int samplingRateSecond = GetSamplingRate();
            DateTime _loggingStartTime = DateTime.Now;
            string loggingFileName = $"{ModelName}_{_loggingStartTime:yyyyMMddHHmmss}.csv";
            DateTime loggingEndTime = _loggingStartTime + TimeSpan.FromHours(settingHours);

            textBox_StartTime.Text = _loggingStartTime.ToString("yyyy-MM-dd HH:mm:ss");
            textBox_SetHour.Text = textBox_SettingHours.Text;
            textBox_SamplingRate.Text = samplingRateSecond.ToString();
            textBox_FileName.Text = loggingFileName;
            #endregion

            _isLogging = true;

            cts = new CancellationTokenSource();
            try
            {
                var result = await Task.Run(() =>
                LoggingFunction(
                    LoggingFilePath,
                    loggingFileName,
                    loggingEndTime,
                    samplingRateSecond,
                    _controller!.Device!.ModbusDataDictionary,
                    cts.Token
                    ));

                if (result == false)
                    MessageBox.Show("에러가 발생하였습니다. 측정 기록을 중단합니다.");
            }
            catch (Exception)
            {

            }
            finally
            {
                _isLogging = false;
            }
        }

        private void button_LoggingStop_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }

        private bool LoggingFunction(
            string loggingFilePath,
            string loggingFileName,
            DateTime loggingEndTime,
            int samplingRateSecond,
            Dictionary<DeviceDataType, ModbusData> modbusDataDictionary,
            CancellationToken token)
        {
            if (Directory.Exists(loggingFilePath) == false) Directory.CreateDirectory(loggingFilePath);
            string loggingFile = loggingFilePath + loggingFileName;

            try
            {
                int lastWriteSecond = int.MinValue;

                string[] strings = new string[1];

                strings[0] = GetHeaderString();
                File.AppendAllLines(loggingFile, strings, Encoding.Default);

                while (loggingEndTime < DateTime.Now)
                {
                    Task.Delay(1);
                    if (token.IsCancellationRequested) break;

                    DateTime current = DateTime.Now;

                    if (current.Second % samplingRateSecond != 0) continue;// 특정 주기에만 시행하도록 함.
                    if (lastWriteSecond == current.Second) continue;

                    lastWriteSecond = current.Second;

                    strings[0] = GetMeasuredDataString(current, modbusDataDictionary);

                    File.AppendAllLines(loggingFile, strings, Encoding.Default);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Model별 Logging 상세
        private string GetHeaderString()
        {
            return "시간,모터온도,알람,누수";
        }

        private string GetMeasuredDataString(DateTime current, Dictionary<DeviceDataType, ModbusData> data)
        {
            return $"{current:yyyy-MM-dd HH:mm:ss},{data[DeviceDataType.Temperature1].Value},{data[DeviceDataType.Alarm1].Value},{data[DeviceDataType.Leak1].Value}";
        }
        #endregion

        #region 기타 지원 함수
        private int GetSamplingRate()
        {
            if (radioButton_1sec.Checked) return 1;
            if (radioButton_5sec.Checked) return 5;
            /*if (radioButton_10sec.Checked)*/
            return 10;
        }

        private void button_OpenFileFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(LoggingFilePath))
                Process.Start("explorer.exe", LoggingFilePath);
        }

        #endregion
    }
}
