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
            this.button_Start = new System.Windows.Forms.Button();
            this.comboBox_Comport = new System.Windows.Forms.ComboBox();
            this.comboBox_Baudrate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Temp1 = new System.Windows.Forms.Label();
            this.label_Temp2 = new System.Windows.Forms.Label();
            this.label_Alarm1 = new System.Windows.Forms.Label();
            this.label_Alarm2 = new System.Windows.Forms.Label();
            this.label_Leak1 = new System.Windows.Forms.Label();
            this.label_Leak2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(433, 274);
            this.button_Start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(72, 22);
            this.button_Start.TabIndex = 2;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click_1);
            // 
            // comboBox_Comport
            // 
            this.comboBox_Comport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Comport.FormattingEnabled = true;
            this.comboBox_Comport.Location = new System.Drawing.Point(93, 273);
            this.comboBox_Comport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Comport.Name = "comboBox_Comport";
            this.comboBox_Comport.Size = new System.Drawing.Size(118, 23);
            this.comboBox_Comport.TabIndex = 3;
            // 
            // comboBox_Baudrate
            // 
            this.comboBox_Baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Baudrate.FormattingEnabled = true;
            this.comboBox_Baudrate.Location = new System.Drawing.Point(308, 273);
            this.comboBox_Baudrate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_Baudrate.Name = "comboBox_Baudrate";
            this.comboBox_Baudrate.Size = new System.Drawing.Size(118, 23);
            this.comboBox_Baudrate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "COMPORT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "BAUDRATE";
            // 
            // label_Temp1
            // 
            this.label_Temp1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_Temp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Temp1.ForeColor = System.Drawing.Color.Red;
            this.label_Temp1.Location = new System.Drawing.Point(174, 97);
            this.label_Temp1.Name = "label_Temp1";
            this.label_Temp1.Size = new System.Drawing.Size(113, 59);
            this.label_Temp1.TabIndex = 18;
            this.label_Temp1.Text = "38";
            this.label_Temp1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Temp2
            // 
            this.label_Temp2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_Temp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Temp2.ForeColor = System.Drawing.Color.Red;
            this.label_Temp2.Location = new System.Drawing.Point(350, 97);
            this.label_Temp2.Name = "label_Temp2";
            this.label_Temp2.Size = new System.Drawing.Size(113, 59);
            this.label_Temp2.TabIndex = 19;
            this.label_Temp2.Text = "38";
            this.label_Temp2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Alarm1
            // 
            this.label_Alarm1.AutoSize = true;
            this.label_Alarm1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_Alarm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Alarm1.ForeColor = System.Drawing.Color.Gray;
            this.label_Alarm1.Location = new System.Drawing.Point(145, 128);
            this.label_Alarm1.Name = "label_Alarm1";
            this.label_Alarm1.Size = new System.Drawing.Size(16, 16);
            this.label_Alarm1.TabIndex = 20;
            this.label_Alarm1.Text = "●";
            // 
            // label_Alarm2
            // 
            this.label_Alarm2.AutoSize = true;
            this.label_Alarm2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_Alarm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Alarm2.ForeColor = System.Drawing.Color.Gray;
            this.label_Alarm2.Location = new System.Drawing.Point(320, 128);
            this.label_Alarm2.Name = "label_Alarm2";
            this.label_Alarm2.Size = new System.Drawing.Size(16, 16);
            this.label_Alarm2.TabIndex = 21;
            this.label_Alarm2.Text = "●";
            // 
            // label_Leak1
            // 
            this.label_Leak1.AutoSize = true;
            this.label_Leak1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_Leak1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Leak1.ForeColor = System.Drawing.Color.Gray;
            this.label_Leak1.Location = new System.Drawing.Point(149, 188);
            this.label_Leak1.Name = "label_Leak1";
            this.label_Leak1.Size = new System.Drawing.Size(16, 16);
            this.label_Leak1.TabIndex = 25;
            this.label_Leak1.Text = "●";
            // 
            // label_Leak2
            // 
            this.label_Leak2.AutoSize = true;
            this.label_Leak2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label_Leak2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Leak2.ForeColor = System.Drawing.Color.Gray;
            this.label_Leak2.Location = new System.Drawing.Point(149, 221);
            this.label_Leak2.Name = "label_Leak2";
            this.label_Leak2.Size = new System.Drawing.Size(16, 16);
            this.label_Leak2.TabIndex = 26;
            this.label_Leak2.Text = "●";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(493, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(320, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "●";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(145, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "●";
            // 
            // MonitorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 304);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_Leak2);
            this.Controls.Add(this.label_Leak1);
            this.Controls.Add(this.label_Alarm2);
            this.Controls.Add(this.label_Alarm1);
            this.Controls.Add(this.label_Temp2);
            this.Controls.Add(this.label_Temp1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_Baudrate);
            this.Controls.Add(this.comboBox_Comport);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonitorUI";
            this.Text = "Temperature Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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