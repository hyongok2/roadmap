namespace TemperatureMonitor.Forms
{
    partial class DeviceSetupForm
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
            textBox_ControllerId = new TextBox();
            label10 = new Label();
            button_Baudrate = new Button();
            label1 = new Label();
            comboBox_Baudrate = new ComboBox();
            button_ControllerId = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_ControllerId
            // 
            textBox_ControllerId.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox_ControllerId.Location = new Point(170, 60);
            textBox_ControllerId.MaxLength = 8;
            textBox_ControllerId.Name = "textBox_ControllerId";
            textBox_ControllerId.Size = new Size(149, 33);
            textBox_ControllerId.TabIndex = 53;
            textBox_ControllerId.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(32, 63);
            label10.Name = "label10";
            label10.Size = new Size(128, 25);
            label10.TabIndex = 50;
            label10.Text = "Controller ID";
            // 
            // button_Baudrate
            // 
            button_Baudrate.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            button_Baudrate.Location = new Point(343, 105);
            button_Baudrate.Name = "button_Baudrate";
            button_Baudrate.Size = new Size(93, 34);
            button_Baudrate.TabIndex = 54;
            button_Baudrate.Text = "Write";
            button_Baudrate.UseVisualStyleBackColor = true;
            button_Baudrate.Click += button_Baudrate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 109);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 55;
            label1.Text = "Baudrate";
            // 
            // comboBox_Baudrate
            // 
            comboBox_Baudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Baudrate.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox_Baudrate.FormattingEnabled = true;
            comboBox_Baudrate.Location = new Point(169, 106);
            comboBox_Baudrate.Margin = new Padding(2);
            comboBox_Baudrate.Name = "comboBox_Baudrate";
            comboBox_Baudrate.Size = new Size(150, 33);
            comboBox_Baudrate.TabIndex = 57;
            // 
            // button_ControllerId
            // 
            button_ControllerId.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            button_ControllerId.Location = new Point(343, 59);
            button_ControllerId.Name = "button_ControllerId";
            button_ControllerId.Size = new Size(93, 34);
            button_ControllerId.TabIndex = 58;
            button_ControllerId.Text = "Write";
            button_ControllerId.UseVisualStyleBackColor = true;
            button_ControllerId.Click += button_ControllerId_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(54, 8);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 59;
            label2.Text = "항목";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(199, 8);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 60;
            label3.Text = "설정값";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(351, 8);
            label4.Name = "label4";
            label4.Size = new Size(50, 25);
            label4.TabIndex = 61;
            label4.Text = "설정";
            // 
            // button1
            // 
            button1.BackColor = Color.DimGray;
            button1.Enabled = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(16, 52);
            button1.Name = "button1";
            button1.Size = new Size(437, 2);
            button1.TabIndex = 62;
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.DimGray;
            button2.Enabled = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(16, 99);
            button2.Name = "button2";
            button2.Size = new Size(437, 2);
            button2.TabIndex = 63;
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DimGray;
            button3.Enabled = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(16, 145);
            button3.Name = "button3";
            button3.Size = new Size(437, 2);
            button3.TabIndex = 64;
            button3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(16, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(437, 40);
            panel1.TabIndex = 65;
            // 
            // DeviceSetupForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(470, 159);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button_ControllerId);
            Controls.Add(comboBox_Baudrate);
            Controls.Add(label1);
            Controls.Add(button_Baudrate);
            Controls.Add(textBox_ControllerId);
            Controls.Add(label10);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(41, 19, 41, 19);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeviceSetupForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "파라미터 설정";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_ControllerId;
        private Label label10;
        private Button button_Baudrate;
        private Label label1;
        private ComboBox comboBox_Baudrate;
        private Button button_ControllerId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel1;
    }
}