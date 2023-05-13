using ModernFlatUI.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernFlatUI.Forms
{
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
         }

        private void LoadTheme()
        {
            foreach( Control control in this.Controls )
            {
                if(control.GetType() == typeof(Button))
                {
                    Button btn = (Button) control;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }

            }

            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;

        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
