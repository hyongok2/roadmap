using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemperatureMonitor.Controller;
using TemperatureMonitor.Device;

namespace TemperatureMonitor.Forms
{
    public partial class DeviceSetupForm : Form
    {
        private readonly MonitorController _controller;
        private TextBox _textBoxId;
        private ComboBox _comboBaud;
        private Button _buttonSend;

        public DeviceSetupForm(MonitorController controller)
        {
            _controller = controller;
            InitializeComponent();
            InitializeUi();
        }

        private void InitializeUi()
        {
            this.Text = "설정";
            this.Width = 350;
            this.Height = 200;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            var labelId = new Label { Text = "Controller ID:", Left = 20, Top = 20, Width = 120 };
            _textBoxId = new TextBox { Left = 160, Top = 18, Width = 120 };

            var labelBaud = new Label { Text = "Baudrate:", Left = 20, Top = 60, Width = 120 };
            _comboBaud = new ComboBox
            {
                Left = 160,
                Top = 58,
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // TODO:추후 수정 필요
            _comboBaud.Items.AddRange(new object[]
            {
                57600,
                38400,
                19200,
                9600,
                4800,
                2400
            });
            _comboBaud.SelectedIndex = 3;

            _buttonSend = new Button
            {
                Text = "설정 전송",
                Left = 160,
                Top = 100,
                Width = 120,
                Height = 35,
            };
            _buttonSend.Click += ButtonSend_Click!;

            this.Controls.Add(labelId);
            this.Controls.Add(_textBoxId);
            this.Controls.Add(labelBaud);
            this.Controls.Add(_comboBaud);
            this.Controls.Add(_buttonSend);
        }

        private async void ButtonSend_Click(object sender, EventArgs e)
        {
            if (_controller == null) return;
            _buttonSend.Enabled = false;

            try
            {
                if (!short.TryParse(_textBoxId.Text, out short controllerId))// TODO: 확인 후 수정 필요
                    {
                    MessageBox.Show("유효한 숫자 ID를 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                short baudValue = (short)(_comboBaud.SelectedIndex + 1); // 1~6 <- TODO: 방식 추후수정 필요

                var idData = _controller.Device!.GetModbusData(DeviceDataType.ControllerIdSet);
                var baudData = _controller.Device.GetModbusData(DeviceDataType.BaudrateSet);

                var idResult = await _controller.WriteAndVerifyAsync(idData, controllerId);
                var baudResult = await _controller.WriteAndVerifyAsync(baudData, baudValue);

                if (idResult && baudResult)
                    MessageBox.Show("설정이 성공적으로 완료되었습니다. 컨트롤러의 전원을 종료하고 재시작하세요.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("설정 실패. 컨트롤러 응답을 확인하세요.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "예외", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _buttonSend.Enabled = true;
            }
        }
    }
}
