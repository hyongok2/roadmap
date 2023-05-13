using CustomMessageBox;
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
    public partial class FormOrders : Form
    {
        public FormOrders()
        {
            InitializeComponent();
        }

        private void stylishButton5_Click(object sender, EventArgs e)
        {
            RJMessageBox.Show("This is for test!","Test",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
        }
    }
}
