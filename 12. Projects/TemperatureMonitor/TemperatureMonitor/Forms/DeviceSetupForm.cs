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

        public DeviceSetupForm(MonitorController controller)
        {
            _controller = controller;
            InitializeComponent();
            InitializeUi();
        }

        private void InitializeUi()
        {
            // TODO:추후 수정 필요
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
        }

        private async void button_ControllerId_Click(object sender, EventArgs e)
        {
            if (_controller == null) return;

            button_ControllerId.Enabled = false;

            try 
            {
                if (!short.TryParse(textBox_ControllerId.Text, out short controllerId))// TODO: 확인 후 수정 필요
                {
                    MessageBox.Show("유효한 숫자 ID를 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var idData = _controller.Device!.GetModbusData(DeviceDataType.ControllerIdSet);
                var idResult = await _controller.WriteAndVerifyAsync(idData, controllerId);

                if (idResult)
                    MessageBox.Show("설정이 성공적으로 완료되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("설정 실패. 컨트롤러 응답을 확인하세요.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "예외", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button_ControllerId.Enabled = true;
            }
        }

        private async void button_Baudrate_Click(object sender, EventArgs e)
        {
            if (_controller == null) return;

            button_Baudrate.Enabled = false;

            try
            {
                short baudValue = (short)(comboBox_Baudrate.SelectedIndex + 1); // 1~6 <- TODO: 방식 추후수정 필요

                var baudrate = _controller.Device!.GetModbusData(DeviceDataType.BaudrateSet);
                var idResult = await _controller.WriteAndVerifyAsync(baudrate, baudValue);

                if (idResult)
                    MessageBox.Show("설정이 성공적으로 완료되었습니다. 컨트롤러의 전원을 종료하고 재시작하세요.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("설정 실패. 컨트롤러 응답을 확인하세요.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "예외", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button_Baudrate.Enabled = true;
            }
        }
    }
}
