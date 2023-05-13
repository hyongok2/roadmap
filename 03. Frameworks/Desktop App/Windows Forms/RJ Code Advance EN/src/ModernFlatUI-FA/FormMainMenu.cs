using FontAwesome.Sharp;
using ModernFlatUI_FA.Forms;
using System.Runtime.InteropServices;

namespace ModernFlatUI_FA
{
    public partial class FormMainMenu : Form
    {

        private IconButton _currentBtn;
        private Panel _leftBorderBtn;
        private Form _currentChildForm;
        private struct RGBColors
        {
            public static List<Color> Colors= new List<Color>
            {
                Color.FromArgb(172,126,241),
                Color.FromArgb(249,118,176),
                Color.FromArgb(253,138,114),
                Color.FromArgb(95,77,221),
                Color.FromArgb(249,88,155),
                Color.FromArgb(24,161,251)
            };    
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public FormMainMenu()
        {
            InitializeComponent();
            _leftBorderBtn = new Panel();
            _leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(_leftBorderBtn);
            Text = string.Empty;
            ControlBox = false;
            DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            FormBorderStyle = FormBorderStyle.Sizable;

            timerCurrentTimedisplay.Start();

            stylishDropdownMenu1.IsMainMenu = true;
            stylishDropdownMenu1.PrimaryColor = Color.Orange;
            stylishDropdownMenu1.MenuItemTextColor= Color.Orange;
        }

        private void ActiveButton(object senderBtn, Color color)
        {
            if (senderBtn == null) return;
            DisableButton();

            _currentBtn = (IconButton)senderBtn;
            _currentBtn.BackColor = Color.FromArgb(37, 36, 81);
            _currentBtn.ForeColor = color;
            _currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            _currentBtn.IconColor = color;
            _currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            _currentBtn.ImageAlign = ContentAlignment.MiddleRight;

            _leftBorderBtn.BackColor = color;
            _leftBorderBtn.Location = new Point(0,_currentBtn.Location.Y);
            _leftBorderBtn.Visible = true;
            _leftBorderBtn.BringToFront();  

            iconCurrentChildForm.IconChar= _currentBtn.IconChar;
            iconCurrentChildForm.IconColor= color;
        }

        private void DisableButton()
        {
            if (_currentBtn == null) return;
            _currentBtn.BackColor = Color.FromArgb(31, 30, 68);
            _currentBtn.ForeColor = Color.Gainsboro;
            _currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            _currentBtn.IconColor = Color.Gainsboro;
            _currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            _currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void OpenChildForm(Form childForm)
        {
            if(_currentChildForm != null)
            {
                if(_currentChildForm != dashBoardForm)
                    _currentChildForm.Close();
                else
                    _currentChildForm.Hide();
            }

            _currentChildForm= childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle= FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag= childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitleChildForm.Text = childForm.Text;
        }

        FormDashoboard dashBoardForm;

        private void icbtnDashboard_Click(object sender, EventArgs e)
        {
            if(dashBoardForm == null) dashBoardForm = new FormDashoboard();

            ActiveButton(sender, RGBColors.Colors[0]);
            OpenChildForm(dashBoardForm);
        }

        private void icbtnOrders_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.Colors[1]);
            OpenChildForm(new FormOrders());
        }

        private void icbtnProducts_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.Colors[2]);
            OpenChildForm(new FormProducts());
        }

        private void icbtnCustomers_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.Colors[3]);
            OpenChildForm(new FormCustomers());
        }

        private void icbtnMarketing_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.Colors[4]);
            OpenChildForm(new FormMarketing());
        }

        private void icbtnSetting_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.Colors[5]);
            OpenChildForm(new FormSetting());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (_currentChildForm != dashBoardForm)
                _currentChildForm?.Close();
            else
                _currentChildForm?.Hide();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            _leftBorderBtn.Visible= false;
            iconCurrentChildForm.IconChar = IconChar.HomeLg;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            labelTitleChildForm.Text = "Home";
        }

        private void panelTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconBtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconBtnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void iconBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerCurrentTimedisplay_Tick(object sender, EventArgs e)
        {
            labelCurrentTime.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);    
            labelCurrentDate.Text = string.Format("{0:dddd, MMMM d, yyyy}",DateTime.Now);
        }

        private void iconButtonDropDown_Click(object sender, EventArgs e)
        {
            stylishDropdownMenu1.Show(iconButtonDropDown, iconButtonDropDown.Width, 0);
        }
    }
}