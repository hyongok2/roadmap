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
    public partial class FormCustomers : Form
    {
        public FormCustomers()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(stylishProgressBar1.Value < stylishProgressBar1.Maximum)
                stylishProgressBar1.Value++;
            if (stylishProgressBar2.Value < stylishProgressBar2.Maximum)
                stylishProgressBar2.Value++;
            if (stylishProgressBar3.Value < stylishProgressBar3.Maximum)
                stylishProgressBar3.Value++;

            if(verticalProgressBar1.Value < verticalProgressBar1.Maximum)
                verticalProgressBar1.Value++;
            if (verticalProgressBar2.Value < verticalProgressBar2.Maximum)
                verticalProgressBar2.Value++;
            if (verticalProgressBar3.Value < verticalProgressBar3.Maximum)
                verticalProgressBar3.Value++;
        }
    }
}
