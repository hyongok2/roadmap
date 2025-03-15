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
    public partial class SelectDeviceType : Form
    {
        public SelectDeviceType()
        {
            InitializeComponent();
        }

        private void button_Ch2_Click(object sender, EventArgs e)
        {
            MonitorCh2 ui = new MonitorCh2();
            ui.StartPosition = FormStartPosition.CenterScreen;
            ui.Show();
        }

        private void button_Ch3_Click(object sender, EventArgs e)
        {
            MonitorCh3 ui = new MonitorCh3();
            ui.StartPosition = FormStartPosition.CenterScreen;
            ui.Show();
        }

        private void button_Ch7_Click(object sender, EventArgs e)
        {
            MonitorCh7 ui = new MonitorCh7();
            ui.StartPosition = FormStartPosition.CenterScreen;
            ui.Show();
        }
    }
}
