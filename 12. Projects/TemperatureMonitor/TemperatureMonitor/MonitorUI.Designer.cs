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
            button_Start = new Button();
            comboBox_Comport = new ComboBox();
            comboBox_Baudrate = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            button_Stop = new Button();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBox_Temperature1 = new TextBox();
            textBox_Temperature2 = new TextBox();
            textBox_Alarm1 = new TextBox();
            textBox_Alarm2 = new TextBox();
            textBox_Leak2 = new TextBox();
            textBox_Leak1 = new TextBox();
            SuspendLayout();
            // 
            // button_Start
            // 
            button_Start.Location = new Point(338, 21);
            button_Start.Name = "button_Start";
            button_Start.Size = new Size(249, 29);
            button_Start.TabIndex = 2;
            button_Start.Text = "Start";
            button_Start.UseVisualStyleBackColor = true;
            button_Start.Click += button_Start_Click;
            // 
            // comboBox_Comport
            // 
            comboBox_Comport.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Comport.FormattingEnabled = true;
            comboBox_Comport.Location = new Point(142, 21);
            comboBox_Comport.Name = "comboBox_Comport";
            comboBox_Comport.Size = new Size(151, 28);
            comboBox_Comport.TabIndex = 3;
            // 
            // comboBox_Baudrate
            // 
            comboBox_Baudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Baudrate.FormattingEnabled = true;
            comboBox_Baudrate.Location = new Point(142, 65);
            comboBox_Baudrate.Name = "comboBox_Baudrate";
            comboBox_Baudrate.Size = new Size(151, 28);
            comboBox_Baudrate.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 24);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 5;
            label3.Text = "COMPORT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 68);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 6;
            label4.Text = "BAUDRATE";
            // 
            // button_Stop
            // 
            button_Stop.Location = new Point(338, 64);
            button_Stop.Name = "button_Stop";
            button_Stop.Size = new Size(249, 29);
            button_Stop.TabIndex = 7;
            button_Stop.Text = "Stop";
            button_Stop.UseVisualStyleBackColor = true;
            button_Stop.Click += button_Stop_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 146);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 8;
            label1.Text = "TEMPERATURE1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 184);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 9;
            label2.Text = "TEMPERATURE2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(183, 260);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 11;
            label5.Text = "ALARM2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(183, 222);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 10;
            label6.Text = "ALARM1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(199, 298);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(51, 20);
            label7.TabIndex = 10;
            label7.Text = "LEAK1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(199, 336);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(51, 20);
            label8.TabIndex = 11;
            label8.Text = "LEAK2";
            // 
            // textBox_Temperature1
            // 
            textBox_Temperature1.Location = new Point(287, 143);
            textBox_Temperature1.Name = "textBox_Temperature1";
            textBox_Temperature1.Size = new Size(167, 27);
            textBox_Temperature1.TabIndex = 12;
            // 
            // textBox_Temperature2
            // 
            textBox_Temperature2.Location = new Point(287, 181);
            textBox_Temperature2.Name = "textBox_Temperature2";
            textBox_Temperature2.Size = new Size(167, 27);
            textBox_Temperature2.TabIndex = 13;
            // 
            // textBox_Alarm1
            // 
            textBox_Alarm1.Location = new Point(287, 219);
            textBox_Alarm1.Name = "textBox_Alarm1";
            textBox_Alarm1.Size = new Size(167, 27);
            textBox_Alarm1.TabIndex = 12;
            // 
            // textBox_Alarm2
            // 
            textBox_Alarm2.Location = new Point(287, 257);
            textBox_Alarm2.Name = "textBox_Alarm2";
            textBox_Alarm2.Size = new Size(167, 27);
            textBox_Alarm2.TabIndex = 13;
            // 
            // textBox_Leak2
            // 
            textBox_Leak2.Location = new Point(287, 333);
            textBox_Leak2.Name = "textBox_Leak2";
            textBox_Leak2.Size = new Size(167, 27);
            textBox_Leak2.TabIndex = 15;
            // 
            // textBox_Leak1
            // 
            textBox_Leak1.Location = new Point(287, 295);
            textBox_Leak1.Name = "textBox_Leak1";
            textBox_Leak1.Size = new Size(167, 27);
            textBox_Leak1.TabIndex = 14;
            // 
            // MonitorUI
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 388);
            Controls.Add(textBox_Leak2);
            Controls.Add(textBox_Leak1);
            Controls.Add(textBox_Alarm2);
            Controls.Add(textBox_Alarm1);
            Controls.Add(textBox_Temperature2);
            Controls.Add(textBox_Temperature1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_Stop);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox_Baudrate);
            Controls.Add(comboBox_Comport);
            Controls.Add(button_Start);
            Margin = new Padding(4);
            Name = "MonitorUI";
            Text = "Temperature Monitor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button_Start;
        private ComboBox comboBox_Comport;
        private ComboBox comboBox_Baudrate;
        private Label label3;
        private Label label4;
        private Button button_Stop;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox_Temperature1;
        private TextBox textBox_Temperature2;
        private TextBox textBox_Alarm1;
        private TextBox textBox_Alarm2;
        private TextBox textBox_Leak2;
        private TextBox textBox_Leak1;
    }
}