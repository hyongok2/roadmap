namespace ModernFlatUI_FA.Forms
{
    partial class FormDashoboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDashoboard));
            this.toggleButton1 = new ModernFlatUI_FA.Controls.ToggleButton();
            this.toggleButton2 = new ModernFlatUI_FA.Controls.ToggleButton();
            this.toggleButtonDarkTheme = new ModernFlatUI_FA.Controls.ToggleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.stylishComboBox1 = new ModernFlatUI_FA.Controls.StylishComboBox();
            this.stylishComboBox2 = new ModernFlatUI_FA.Controls.StylishComboBox();
            this.stylishComboBox3 = new ModernFlatUI_FA.Controls.StylishComboBox();
            this.stylishComboBox4 = new ModernFlatUI_FA.Controls.StylishComboBox();
            this.circularPictureBox1 = new ModernFlatUI_FA.Controls.CircularPictureBox();
            this.circularPictureBox2 = new ModernFlatUI_FA.Controls.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // toggleButton1
            // 
            this.toggleButton1.Location = new System.Drawing.Point(211, 61);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton1.OnBackColor = System.Drawing.Color.CornflowerBlue;
            this.toggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton1.Size = new System.Drawing.Size(85, 40);
            this.toggleButton1.TabIndex = 0;
            this.toggleButton1.Text = "toggleButton1";
            this.toggleButton1.UseVisualStyleBackColor = true;
            // 
            // toggleButton2
            // 
            this.toggleButton2.Location = new System.Drawing.Point(211, 15);
            this.toggleButton2.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButton2.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton2.OnBackColor = System.Drawing.Color.DarkGreen;
            this.toggleButton2.OnToggleColor = System.Drawing.Color.YellowGreen;
            this.toggleButton2.Size = new System.Drawing.Size(85, 40);
            this.toggleButton2.SolidStyle = false;
            this.toggleButton2.TabIndex = 1;
            this.toggleButton2.Text = "toggleButton2";
            this.toggleButton2.UseVisualStyleBackColor = true;
            // 
            // toggleButtonDarkTheme
            // 
            this.toggleButtonDarkTheme.Location = new System.Drawing.Point(484, 31);
            this.toggleButtonDarkTheme.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButtonDarkTheme.Name = "toggleButtonDarkTheme";
            this.toggleButtonDarkTheme.OffBackColor = System.Drawing.Color.Gray;
            this.toggleButtonDarkTheme.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButtonDarkTheme.OnBackColor = System.Drawing.Color.SkyBlue;
            this.toggleButtonDarkTheme.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButtonDarkTheme.Size = new System.Drawing.Size(65, 29);
            this.toggleButtonDarkTheme.TabIndex = 2;
            this.toggleButtonDarkTheme.Text = "toggleButton3";
            this.toggleButtonDarkTheme.UseVisualStyleBackColor = true;
            this.toggleButtonDarkTheme.CheckedChanged += new System.EventHandler(this.toggleButtonDarkTheme_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(376, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dark Theme";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "보성",
            "광주",
            "구미",
            "파주",
            "천안"});
            this.comboBox1.Location = new System.Drawing.Point(712, 268);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Select";
            // 
            // stylishComboBox1
            // 
            this.stylishComboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.stylishComboBox1.BorderColor = System.Drawing.Color.Lavender;
            this.stylishComboBox1.BorderSize = 3;
            this.stylishComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.stylishComboBox1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stylishComboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.stylishComboBox1.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.stylishComboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.stylishComboBox1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.stylishComboBox1.ListTextColor = System.Drawing.Color.DimGray;
            this.stylishComboBox1.Location = new System.Drawing.Point(712, 84);
            this.stylishComboBox1.MinimumSize = new System.Drawing.Size(200, 32);
            this.stylishComboBox1.Name = "stylishComboBox1";
            this.stylishComboBox1.Padding = new System.Windows.Forms.Padding(3);
            this.stylishComboBox1.Size = new System.Drawing.Size(200, 50);
            this.stylishComboBox1.TabIndex = 5;
            this.stylishComboBox1.Texts = "";
            // 
            // stylishComboBox2
            // 
            this.stylishComboBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.stylishComboBox2.BorderColor = System.Drawing.Color.GhostWhite;
            this.stylishComboBox2.BorderSize = 3;
            this.stylishComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.stylishComboBox2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stylishComboBox2.ForeColor = System.Drawing.Color.DimGray;
            this.stylishComboBox2.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.stylishComboBox2.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i"});
            this.stylishComboBox2.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.stylishComboBox2.ListTextColor = System.Drawing.Color.DimGray;
            this.stylishComboBox2.Location = new System.Drawing.Point(712, 145);
            this.stylishComboBox2.MinimumSize = new System.Drawing.Size(200, 32);
            this.stylishComboBox2.Name = "stylishComboBox2";
            this.stylishComboBox2.Padding = new System.Windows.Forms.Padding(3);
            this.stylishComboBox2.Size = new System.Drawing.Size(200, 51);
            this.stylishComboBox2.TabIndex = 6;
            this.stylishComboBox2.Texts = "";
            // 
            // stylishComboBox3
            // 
            this.stylishComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.stylishComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.stylishComboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.stylishComboBox3.BorderColor = System.Drawing.Color.SaddleBrown;
            this.stylishComboBox3.BorderSize = 3;
            this.stylishComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.stylishComboBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stylishComboBox3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.stylishComboBox3.IconColor = System.Drawing.Color.SaddleBrown;
            this.stylishComboBox3.Items.AddRange(new object[] {
            "asd",
            "qwe",
            "dfg",
            "fgh",
            "xdv",
            "wef"});
            this.stylishComboBox3.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.stylishComboBox3.ListTextColor = System.Drawing.Color.DimGray;
            this.stylishComboBox3.Location = new System.Drawing.Point(712, 31);
            this.stylishComboBox3.MinimumSize = new System.Drawing.Size(200, 32);
            this.stylishComboBox3.Name = "stylishComboBox3";
            this.stylishComboBox3.Padding = new System.Windows.Forms.Padding(3);
            this.stylishComboBox3.Size = new System.Drawing.Size(200, 47);
            this.stylishComboBox3.TabIndex = 7;
            this.stylishComboBox3.Texts = "";
            // 
            // stylishComboBox4
            // 
            this.stylishComboBox4.BackColor = System.Drawing.Color.LightGray;
            this.stylishComboBox4.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.stylishComboBox4.BorderSize = 0;
            this.stylishComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stylishComboBox4.ForeColor = System.Drawing.Color.DimGray;
            this.stylishComboBox4.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.stylishComboBox4.Items.AddRange(new object[] {
            "asdlkhj;sc",
            "as;ldkja;sdj",
            "aklsdjnaslkcjba"});
            this.stylishComboBox4.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.stylishComboBox4.ListTextColor = System.Drawing.Color.White;
            this.stylishComboBox4.Location = new System.Drawing.Point(712, 214);
            this.stylishComboBox4.MinimumSize = new System.Drawing.Size(200, 32);
            this.stylishComboBox4.Name = "stylishComboBox4";
            this.stylishComboBox4.Size = new System.Drawing.Size(200, 32);
            this.stylishComboBox4.TabIndex = 8;
            this.stylishComboBox4.Texts = "";
            this.stylishComboBox4.OnSelectedIndexChanged += new System.EventHandler(this.stylishComboBox4_OnSelectedIndexChanged);
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.circularPictureBox1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.circularPictureBox1.BorderColor2 = System.Drawing.Color.HotPink;
            this.circularPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.circularPictureBox1.BorderSize = 5;
            this.circularPictureBox1.GradientAngle = 50F;
            this.circularPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("circularPictureBox1.Image")));
            this.circularPictureBox1.Location = new System.Drawing.Point(12, 12);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(164, 164);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.circularPictureBox1.TabIndex = 9;
            this.circularPictureBox1.TabStop = false;
            // 
            // circularPictureBox2
            // 
            this.circularPictureBox2.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Round;
            this.circularPictureBox2.BorderColor = System.Drawing.Color.RoyalBlue;
            this.circularPictureBox2.BorderColor2 = System.Drawing.Color.HotPink;
            this.circularPictureBox2.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.circularPictureBox2.BorderSize = 0;
            this.circularPictureBox2.GradientAngle = 50F;
            this.circularPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("circularPictureBox2.Image")));
            this.circularPictureBox2.Location = new System.Drawing.Point(291, 126);
            this.circularPictureBox2.Name = "circularPictureBox2";
            this.circularPictureBox2.Size = new System.Drawing.Size(269, 269);
            this.circularPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.circularPictureBox2.TabIndex = 10;
            this.circularPictureBox2.TabStop = false;
            // 
            // FormDashoboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 457);
            this.Controls.Add(this.circularPictureBox2);
            this.Controls.Add(this.circularPictureBox1);
            this.Controls.Add(this.stylishComboBox4);
            this.Controls.Add(this.stylishComboBox3);
            this.Controls.Add(this.stylishComboBox2);
            this.Controls.Add(this.stylishComboBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toggleButtonDarkTheme);
            this.Controls.Add(this.toggleButton2);
            this.Controls.Add(this.toggleButton1);
            this.Name = "FormDashoboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ToggleButton toggleButton1;
        private Controls.ToggleButton toggleButton2;
        private Controls.ToggleButton toggleButtonDarkTheme;
        private Label label1;
        private ComboBox comboBox1;
        private Controls.StylishComboBox stylishComboBox1;
        private Controls.StylishComboBox stylishComboBox2;
        private Controls.StylishComboBox stylishComboBox3;
        private Controls.StylishComboBox stylishComboBox4;
        private Controls.CircularPictureBox circularPictureBox1;
        private Controls.CircularPictureBox circularPictureBox2;
    }
}