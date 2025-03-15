namespace TemperatureMonitor
{
    partial class MonitorUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorUI));
            button_Start = new Button();
            comboBox_Comport = new ComboBox();
            comboBox_Baudrate = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label_Temp1 = new Label();
            label_Temp2 = new Label();
            label_Alarm1 = new Label();
            label_Alarm2 = new Label();
            label_Leak1 = new Label();
            label_Leak2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button_Start
            // 
            button_Start.Location = new Point(557, 365);
            button_Start.Name = "button_Start";
            button_Start.Size = new Size(93, 29);
            button_Start.TabIndex = 2;
            button_Start.Text = "Start";
            button_Start.UseVisualStyleBackColor = true;
            button_Start.Click += button_Start_Click;
            // 
            // comboBox_Comport
            // 
            comboBox_Comport.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Comport.FormattingEnabled = true;
            comboBox_Comport.Location = new Point(120, 364);
            comboBox_Comport.Name = "comboBox_Comport";
            comboBox_Comport.Size = new Size(151, 28);
            comboBox_Comport.TabIndex = 3;
            // 
            // comboBox_Baudrate
            // 
            comboBox_Baudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Baudrate.FormattingEnabled = true;
            comboBox_Baudrate.Location = new Point(396, 364);
            comboBox_Baudrate.Name = "comboBox_Baudrate";
            comboBox_Baudrate.Size = new Size(151, 28);
            comboBox_Baudrate.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 369);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 5;
            label3.Text = "COMPORT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(297, 369);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 6;
            label4.Text = "BAUDRATE";
            // 
            // label_Temp1
            // 
            label_Temp1.BackColor = SystemColors.ActiveCaptionText;
            label_Temp1.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label_Temp1.ForeColor = Color.Red;
            label_Temp1.Location = new Point(224, 129);
            label_Temp1.Margin = new Padding(4, 0, 4, 0);
            label_Temp1.Name = "label_Temp1";
            label_Temp1.Size = new Size(145, 79);
            label_Temp1.TabIndex = 18;
            label_Temp1.Text = "38";
            label_Temp1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Temp2
            // 
            label_Temp2.BackColor = SystemColors.ActiveCaptionText;
            label_Temp2.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label_Temp2.ForeColor = Color.Red;
            label_Temp2.Location = new Point(450, 129);
            label_Temp2.Margin = new Padding(4, 0, 4, 0);
            label_Temp2.Name = "label_Temp2";
            label_Temp2.Size = new Size(145, 79);
            label_Temp2.TabIndex = 19;
            label_Temp2.Text = "38";
            label_Temp2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Alarm1
            // 
            label_Alarm1.AutoSize = true;
            label_Alarm1.BackColor = SystemColors.ControlDark;
            label_Alarm1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Alarm1.ForeColor = Color.Gray;
            label_Alarm1.Location = new Point(186, 171);
            label_Alarm1.Margin = new Padding(4, 0, 4, 0);
            label_Alarm1.Name = "label_Alarm1";
            label_Alarm1.Size = new Size(20, 20);
            label_Alarm1.TabIndex = 20;
            label_Alarm1.Text = "●";
            // 
            // label_Alarm2
            // 
            label_Alarm2.AutoSize = true;
            label_Alarm2.BackColor = SystemColors.ControlDark;
            label_Alarm2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Alarm2.ForeColor = Color.Gray;
            label_Alarm2.Location = new Point(412, 171);
            label_Alarm2.Margin = new Padding(4, 0, 4, 0);
            label_Alarm2.Name = "label_Alarm2";
            label_Alarm2.Size = new Size(20, 20);
            label_Alarm2.TabIndex = 21;
            label_Alarm2.Text = "●";
            // 
            // label_Leak1
            // 
            label_Leak1.AutoSize = true;
            label_Leak1.BackColor = SystemColors.ControlDark;
            label_Leak1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Leak1.ForeColor = Color.Gray;
            label_Leak1.Location = new Point(192, 251);
            label_Leak1.Margin = new Padding(4, 0, 4, 0);
            label_Leak1.Name = "label_Leak1";
            label_Leak1.Size = new Size(20, 20);
            label_Leak1.TabIndex = 25;
            label_Leak1.Text = "●";
            // 
            // label_Leak2
            // 
            label_Leak2.AutoSize = true;
            label_Leak2.BackColor = SystemColors.ControlDark;
            label_Leak2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label_Leak2.ForeColor = Color.Gray;
            label_Leak2.Location = new Point(192, 295);
            label_Leak2.Margin = new Padding(4, 0, 4, 0);
            label_Leak2.Name = "label_Leak2";
            label_Leak2.Size = new Size(20, 20);
            label_Leak2.TabIndex = 26;
            label_Leak2.Text = "●";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 16);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(634, 333);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDark;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(412, 120);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(20, 20);
            label1.TabIndex = 29;
            label1.Text = "●";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlDark;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(186, 120);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(20, 20);
            label2.TabIndex = 28;
            label2.Text = "●";
            // 
            // MonitorUI
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 405);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label_Leak2);
            Controls.Add(label_Leak1);
            Controls.Add(label_Alarm2);
            Controls.Add(label_Alarm1);
            Controls.Add(label_Temp2);
            Controls.Add(label_Temp1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox_Baudrate);
            Controls.Add(comboBox_Comport);
            Controls.Add(button_Start);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MonitorUI";
            Text = "Temperature Monitor";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button_Start;
        private ComboBox comboBox_Comport;
        private ComboBox comboBox_Baudrate;
        private Label label3;
        private Label label4;
        private Label label_Temp1;
        private Label label_Temp2;
        private Label label_Alarm1;
        private Label label_Alarm2;
        private Label label_Leak1;
        private Label label_Leak2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
    }
}