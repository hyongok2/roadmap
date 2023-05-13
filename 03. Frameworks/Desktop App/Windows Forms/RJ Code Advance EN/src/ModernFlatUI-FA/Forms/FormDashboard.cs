using ModernFlatUI_FA.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernFlatUI_FA.Forms
{
    public partial class FormDashoboard : Form
    {
        public FormDashoboard()
        {
            InitializeComponent();
        }

        private void toggleButtonDarkTheme_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = (sender as CheckBox)!.Checked;

            if (isChecked)
            {
                BackColor = Color.DimGray;
                label1.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                BackColor = Color.WhiteSmoke;
                label1.ForeColor = Color.DimGray;
            }

        }

        private void stylishComboBox4_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show((sender as ComboBox).Text);
        }
    }
}
