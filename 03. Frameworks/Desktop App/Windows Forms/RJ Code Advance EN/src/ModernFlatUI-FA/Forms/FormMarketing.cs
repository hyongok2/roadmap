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
    public partial class FormMarketing : Form
    {
        public FormMarketing()
        {
            InitializeComponent();
        }

        private void stylishTextbox2__TextChanged(object sender, EventArgs e)
        {
            stylishTextbox1.Texts= stylishTextbox2.Texts;
        }
    }
}
