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
    public partial class MonitorCh3 : Form
    {
        #region 멤버 변수
        private MonitorController? _controller;

        private const string ModelName = "TML-R-D";
        private const string LoggingFilePath = @"C:\Temperature Log\";// 고정 경로로 지정함.

        private bool _isConnected = false;

        private bool _isLogging = false;

        private DateTime _loggingStartTime = DateTime.Now;

        private CancellationTokenSource cts = new();
        #endregion

        #region 생성자
        public MonitorCh3()
        {
            InitializeComponent();

            SetUpComboBox();

            InitialChartControl();

            timer_Display.Start();

            //timer_Chart.Start();//임시
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
                _controller = new ControllerCh3(comboBox_Comport.Text, int.Parse(comboBox_Baudrate.Text));
                _controller.OnTemperatureDeviceValueChanged += Controller_OnTemperatureDeviceValueChanged;

                var result = await Task.Run(_controller.Start);

                if (result == false)
                    MessageBox.Show("연결에 실패하였습니다.");
                else
                {
                    MessageBox.Show("정상적으로 연결되었습니다.");
                    _isConnected = true;
                    ChartDataClear();
                    _maxDataCount = GetMaxDataCount();
                    timer_Chart.Start();
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
                label_Temp2.Text = device.ModbusDataDictionary[DeviceDataType.Temperature2].Value.ToString();
                if (device.ModbusDataDictionary[DeviceDataType.Alarm1].Value == 1)
                {
                    label_Alarm1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label_Alarm1.ForeColor = System.Drawing.Color.Gray;
                }

                if (device.ModbusDataDictionary[DeviceDataType.Alarm2].Value == 1)
                {
                    label_Alarm2.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label_Alarm2.ForeColor = System.Drawing.Color.Gray;
                }

                if (device.ModbusDataDictionary[DeviceDataType.Leak1].Value == 1)
                {
                    label_Leak1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label_Leak1.ForeColor = System.Drawing.Color.Gray;
                }
            }));
        }

        private void timer_Display_Tick(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                label_Running1.ForeColor = System.Drawing.Color.Lime;
                label_Running2.ForeColor = System.Drawing.Color.Lime;
            }
            else
            {
                label_Running1.ForeColor = System.Drawing.Color.Gray;
                label_Running2.ForeColor = System.Drawing.Color.Gray;
            }
            if (_isLogging)
            {
                label_Status.Text = "측정 기록 중";
                if (DateTime.Now.Second % 2 == 0)
                    label_Status.ForeColor = System.Drawing.Color.Black;
                else
                    label_Status.ForeColor = System.Drawing.Color.White;

                textBox_ProgressHour.Text = (DateTime.Now - _loggingStartTime).Hours.ToString();
            }
            else
            {
                label_Status.Text = "측정 대기 중";
                label_Status.ForeColor = System.Drawing.Color.White;
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
            string loggingFileName = $"{ModelName}_{_loggingStartTime:yyyyMMddHHmmss}.log";
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
                File.AppendAllLines(loggingFile, strings, Encoding.UTF8);

                while (loggingEndTime > DateTime.Now)
                {
                    Task.Delay(1);
                    if (token.IsCancellationRequested) break;

                    DateTime current = DateTime.Now;

                    if (current.Second % samplingRateSecond != 0) continue;// 특정 주기에만 시행하도록 함.
                    if (lastWriteSecond == current.Second) continue;

                    lastWriteSecond = current.Second;

                    strings[0] = GetMeasuredDataString(current, modbusDataDictionary);

                    File.AppendAllLines(loggingFile, strings, Encoding.UTF8);
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
            return "Time,Motor Temperature,Bearing Temperature,Motor Alarm,Bearing Alarm,Leak";
        }

        private string GetMeasuredDataString(DateTime current, Dictionary<DeviceDataType, ModbusData> data)
        {
            return $"{current:yyyy-MM-dd HH:mm:ss},{data[DeviceDataType.Temperature1].Value},{data[DeviceDataType.Temperature2].Value},{data[DeviceDataType.Alarm1].Value},{data[DeviceDataType.Alarm2].Value},{data[DeviceDataType.Leak1].Value}";
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

        #region Chart 관련 함수

        private ScottPlot.Plottables.DataLogger _loggerTemperature1;
        private ScottPlot.Plottables.DataLogger _loggerTemperature2;
        private ScottPlot.Plottables.DataLogger _loggerLeak1;

        private List<int> _motorTemperature = new();
        private List<int> _bearingTemperature = new();
        private List<int> _leakData = new();
        private int _maxDataCount = 60;
        private void InitialChartControl()
        {
            formsPlot1.Plot.Title("Real Time Temperature Chart");
            //formsPlot1.Plot.YLabel("Temperature");

            _loggerTemperature1 = formsPlot1.Plot.Add.DataLogger();
            _loggerTemperature2 = formsPlot1.Plot.Add.DataLogger();

            _loggerTemperature1.LegendText = "Motor";
            _loggerTemperature1.LineColor = ScottPlot.Color.FromColor(System.Drawing.Color.Blue);

            _loggerTemperature2.LegendText = "Bearing";
            _loggerTemperature2.LineColor = ScottPlot.Color.FromColor(System.Drawing.Color.Green);

            _loggerTemperature1.LineWidth = 1.5f;
            _loggerTemperature2.LineWidth = 1.5f;

            formsPlot2.Plot.Title("Real Time Leak State Chart");

            _loggerLeak1 = formsPlot2.Plot.Add.DataLogger();

            _loggerLeak1.LegendText = "Leak";
            _loggerLeak1.LineColor = ScottPlot.Color.FromColor(System.Drawing.Color.Red);

            _loggerLeak1.LineWidth = 1.5f;

            formsPlot1.Plot.Legend.Alignment = ScottPlot.Alignment.UpperRight;
            formsPlot2.Plot.Legend.Alignment = ScottPlot.Alignment.UpperRight;

            formsPlot1.Plot.DataBackground.Color = ScottPlot.Color.FromHex("#F0F0F0");
            formsPlot2.Plot.DataBackground.Color = ScottPlot.Color.FromHex("#F0F0F0");
        }

        private void timer_Chart_Tick(object sender, EventArgs e)
        {
            if (_motorTemperature.Count == _maxDataCount) { _motorTemperature.RemoveAt(0); }
            if (_bearingTemperature.Count == _maxDataCount) { _bearingTemperature.RemoveAt(0); }
            if (_leakData.Count == _maxDataCount) { _leakData.RemoveAt(0); }

            _motorTemperature.Add(_controller!.Device!.ModbusDataDictionary[DeviceDataType.Temperature1].Value);
            _bearingTemperature.Add(_controller!.Device!.ModbusDataDictionary[DeviceDataType.Temperature2].Value);
            _leakData.Add(_controller!.Device!.ModbusDataDictionary[DeviceDataType.Leak1].Value);

            //_motorTemperature.Add(new Random().Next(50));//임시
            //_bearingTemperature.Add(new Random().Next(50));
            //_leakData.Add(new Random().Next(2));

            _loggerTemperature1.Clear();
            _loggerTemperature2.Clear();
            _loggerLeak1.Clear();

            for (int i = 0; i < _motorTemperature.Count; i++)
            {
                _loggerTemperature1.Add(i + 1, _motorTemperature[i]);
                _loggerTemperature2.Add(i + 1, _bearingTemperature[i]);
                _loggerLeak1.Add(i + 1, _leakData[i]);
            }

            formsPlot1.Plot.Axes.Margins(0, 0);
            formsPlot2.Plot.Axes.Margins(0, 0);

            formsPlot1.Plot.Axes.SetLimitsY(bottom: 0, top: 200);
            formsPlot2.Plot.Axes.SetLimitsY(bottom: 0, top: 2);

            formsPlot1.Refresh();
            formsPlot2.Refresh();
        }

        private void ChartDataClear()
        {
            _motorTemperature.Clear();
            _bearingTemperature.Clear();
            _leakData.Clear();
        }

        private int GetMaxDataCount()
        {
            if (radioButton_1min.Checked) return 60;
            if (radioButton_10min.Checked) return 600;
            /*if (radioButton_60min.Checked)*/
            return 3600;

        }
        #endregion

        private void MonitorCh3_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
        }
    }
}
