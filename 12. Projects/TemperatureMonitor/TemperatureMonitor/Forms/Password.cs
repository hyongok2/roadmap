using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureMonitor.Forms
{
    public partial class Password : Form
    {
        private const string _password = "7182";

        public bool IsPasswordValid { get; set; } = false;

        public Password()
        {
            InitializeComponent();
        }

        private void textBox_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;

            CheckPassword();
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            CheckPassword();
        }

        private void CheckPassword()
        {
            if (textBox_Password.Text != _password)
            {
                MessageBox.Show("비밀번호를 확인하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IsPasswordValid = true;

            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
