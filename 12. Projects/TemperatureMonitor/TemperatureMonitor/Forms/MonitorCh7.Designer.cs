namespace TemperatureMonitor.Forms
{
    partial class MonitorCh7
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorCh7));
            pictureBox1 = new PictureBox();
            label_Running1 = new Label();
            label_Running2 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            button_Connect = new Button();
            comboBox_Baudrate = new ComboBox();
            label4 = new Label();
            comboBox_Comport = new ComboBox();
            panel5 = new Panel();
            radioButton_60min = new RadioButton();
            radioButton_10min = new RadioButton();
            radioButton_1min = new RadioButton();
            label5 = new Label();
            panel4 = new Panel();
            label14 = new Label();
            textBox_SamplingRate = new TextBox();
            label15 = new Label();
            label_Status = new Label();
            label12 = new Label();
            textBox_ProgressHour = new TextBox();
            label13 = new Label();
            button_OpenFileFolder = new Button();
            textBox_FileName = new TextBox();
            label11 = new Label();
            textBox_SetHour = new TextBox();
            textBox_StartTime = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            button_LoggingStop = new Button();
            button_LoggingStart = new Button();
            panel3 = new Panel();
            label6 = new Label();
            textBox_SettingHours = new TextBox();
            label16 = new Label();
            panel2 = new Panel();
            radioButton_10sec = new RadioButton();
            radioButton_5sec = new RadioButton();
            radioButton_1sec = new RadioButton();
            label17 = new Label();
            panel7 = new Panel();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            panel6 = new Panel();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            label_Temp1 = new Label();
            label_Alarm1 = new Label();
            label_Alarm2 = new Label();
            label_Leak1 = new Label();
            timer_Display = new System.Windows.Forms.Timer(components);
            timer_Chart = new System.Windows.Forms.Timer(components);
            label_Temp2 = new Label();
            label_Temp3 = new Label();
            label_Temp4 = new Label();
            label_Temp5 = new Label();
            label_Leak2 = new Label();
            label1 = new Label();
            label2 = new Label();
            button_SetUp = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(18, 18);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(686, 339);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label_Running1
            // 
            label_Running1.AutoSize = true;
            label_Running1.BackColor = Color.DarkGray;
            label_Running1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Running1.ForeColor = Color.Gray;
            label_Running1.Location = new Point(178, 80);
            label_Running1.Margin = new Padding(0);
            label_Running1.Name = "label_Running1";
            label_Running1.Size = new Size(29, 29);
            label_Running1.TabIndex = 30;
            label_Running1.Text = "●";
            // 
            // label_Running2
            // 
            label_Running2.AutoSize = true;
            label_Running2.BackColor = Color.DarkGray;
            label_Running2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Running2.ForeColor = Color.Gray;
            label_Running2.Location = new Point(178, 165);
            label_Running2.Margin = new Padding(0);
            label_Running2.Name = "label_Running2";
            label_Running2.Size = new Size(29, 29);
            label_Running2.TabIndex = 31;
            label_Running2.Text = "●";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button_Connect);
            panel1.Controls.Add(comboBox_Baudrate);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboBox_Comport);
            panel1.Location = new Point(18, 372);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(686, 56);
            panel1.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(26, 16);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 31;
            label3.Text = "컴포트";
            // 
            // button_Connect
            // 
            button_Connect.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button_Connect.Location = new Point(561, 10);
            button_Connect.Name = "button_Connect";
            button_Connect.Size = new Size(108, 33);
            button_Connect.TabIndex = 32;
            button_Connect.Text = "통신 연결";
            button_Connect.UseVisualStyleBackColor = true;
            button_Connect.Click += button_Connect_Click;
            // 
            // comboBox_Baudrate
            // 
            comboBox_Baudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Baudrate.FormattingEnabled = true;
            comboBox_Baudrate.Location = new Point(382, 10);
            comboBox_Baudrate.Name = "comboBox_Baudrate";
            comboBox_Baudrate.Size = new Size(154, 33);
            comboBox_Baudrate.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(296, 16);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(84, 25);
            label4.TabIndex = 34;
            label4.Text = "통신속도";
            // 
            // comboBox_Comport
            // 
            comboBox_Comport.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Comport.FormattingEnabled = true;
            comboBox_Comport.Location = new Point(94, 10);
            comboBox_Comport.Name = "comboBox_Comport";
            comboBox_Comport.Size = new Size(154, 33);
            comboBox_Comport.TabIndex = 30;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkGray;
            panel5.Controls.Add(radioButton_60min);
            panel5.Controls.Add(radioButton_10min);
            panel5.Controls.Add(radioButton_1min);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(726, 228);
            panel5.Margin = new Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new Size(213, 200);
            panel5.TabIndex = 43;
            // 
            // radioButton_60min
            // 
            radioButton_60min.AutoSize = true;
            radioButton_60min.Font = new Font("Segoe UI", 11.25F);
            radioButton_60min.Location = new Point(27, 142);
            radioButton_60min.Margin = new Padding(4);
            radioButton_60min.Name = "radioButton_60min";
            radioButton_60min.Size = new Size(92, 35);
            radioButton_60min.TabIndex = 35;
            radioButton_60min.Text = "60 분";
            radioButton_60min.UseVisualStyleBackColor = true;
            // 
            // radioButton_10min
            // 
            radioButton_10min.AutoSize = true;
            radioButton_10min.Font = new Font("Segoe UI", 11.25F);
            radioButton_10min.Location = new Point(27, 102);
            radioButton_10min.Margin = new Padding(4);
            radioButton_10min.Name = "radioButton_10min";
            radioButton_10min.Size = new Size(92, 35);
            radioButton_10min.TabIndex = 34;
            radioButton_10min.Text = "10 분";
            radioButton_10min.UseVisualStyleBackColor = true;
            // 
            // radioButton_1min
            // 
            radioButton_1min.AutoSize = true;
            radioButton_1min.Checked = true;
            radioButton_1min.Font = new Font("Segoe UI", 11.25F);
            radioButton_1min.Location = new Point(27, 62);
            radioButton_1min.Margin = new Padding(4);
            radioButton_1min.Name = "radioButton_1min";
            radioButton_1min.Size = new Size(80, 35);
            radioButton_1min.TabIndex = 33;
            radioButton_1min.TabStop = true;
            radioButton_1min.Text = "1 분";
            radioButton_1min.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(22, 14);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(172, 32);
            label5.TabIndex = 32;
            label5.Text = "차트 표시 범위";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gainsboro;
            panel4.Controls.Add(label14);
            panel4.Controls.Add(textBox_SamplingRate);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(label_Status);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(textBox_ProgressHour);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(button_OpenFileFolder);
            panel4.Controls.Add(textBox_FileName);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(textBox_SetHour);
            panel4.Controls.Add(textBox_StartTime);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label7);
            panel4.Location = new Point(1262, 18);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(495, 410);
            panel4.TabIndex = 47;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F);
            label14.Location = new Point(412, 238);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(38, 32);
            label14.TabIndex = 53;
            label14.Text = "초";
            // 
            // textBox_SamplingRate
            // 
            textBox_SamplingRate.Enabled = false;
            textBox_SamplingRate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox_SamplingRate.Location = new Point(165, 232);
            textBox_SamplingRate.Margin = new Padding(4);
            textBox_SamplingRate.MaxLength = 6;
            textBox_SamplingRate.Name = "textBox_SamplingRate";
            textBox_SamplingRate.Size = new Size(241, 39);
            textBox_SamplingRate.TabIndex = 52;
            textBox_SamplingRate.Text = "1";
            textBox_SamplingRate.TextAlign = HorizontalAlignment.Center;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 11.25F);
            label15.Location = new Point(30, 238);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(112, 31);
            label15.TabIndex = 51;
            label15.Text = "측정 주기";
            // 
            // label_Status
            // 
            label_Status.AutoSize = true;
            label_Status.BackColor = Color.Gainsboro;
            label_Status.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label_Status.ForeColor = Color.White;
            label_Status.Location = new Point(290, 10);
            label_Status.Margin = new Padding(4, 0, 4, 0);
            label_Status.Name = "label_Status";
            label_Status.Size = new Size(198, 45);
            label_Status.TabIndex = 42;
            label_Status.Text = "측정 대기 중";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(411, 186);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(62, 32);
            label12.TabIndex = 50;
            label12.Text = "시간";
            // 
            // textBox_ProgressHour
            // 
            textBox_ProgressHour.Enabled = false;
            textBox_ProgressHour.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox_ProgressHour.Location = new Point(164, 180);
            textBox_ProgressHour.Margin = new Padding(4);
            textBox_ProgressHour.MaxLength = 6;
            textBox_ProgressHour.Name = "textBox_ProgressHour";
            textBox_ProgressHour.Size = new Size(241, 39);
            textBox_ProgressHour.TabIndex = 49;
            textBox_ProgressHour.Text = "1";
            textBox_ProgressHour.TextAlign = HorizontalAlignment.Center;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 11.25F);
            label13.Location = new Point(28, 186);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(112, 31);
            label13.TabIndex = 48;
            label13.Text = "경과 시간";
            // 
            // button_OpenFileFolder
            // 
            button_OpenFileFolder.FlatStyle = FlatStyle.Flat;
            button_OpenFileFolder.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button_OpenFileFolder.Image = (Image)resources.GetObject("button_OpenFileFolder.Image");
            button_OpenFileFolder.ImageAlign = ContentAlignment.MiddleLeft;
            button_OpenFileFolder.Location = new Point(27, 335);
            button_OpenFileFolder.Margin = new Padding(4);
            button_OpenFileFolder.Name = "button_OpenFileFolder";
            button_OpenFileFolder.Padding = new Padding(50, 0, 0, 0);
            button_OpenFileFolder.Size = new Size(448, 64);
            button_OpenFileFolder.TabIndex = 42;
            button_OpenFileFolder.Text = "파일 경로 열기";
            button_OpenFileFolder.UseVisualStyleBackColor = true;
            button_OpenFileFolder.Click += button_OpenFileFolder_Click;
            // 
            // textBox_FileName
            // 
            textBox_FileName.Enabled = false;
            textBox_FileName.Font = new Font("Segoe UI", 12F);
            textBox_FileName.Location = new Point(118, 285);
            textBox_FileName.Margin = new Padding(4);
            textBox_FileName.MaxLength = 25;
            textBox_FileName.Name = "textBox_FileName";
            textBox_FileName.Size = new Size(355, 39);
            textBox_FileName.TabIndex = 47;
            textBox_FileName.Text = "TML-T_20250315170000.log";
            textBox_FileName.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(411, 134);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(62, 32);
            label11.TabIndex = 46;
            label11.Text = "시간";
            // 
            // textBox_SetHour
            // 
            textBox_SetHour.Enabled = false;
            textBox_SetHour.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox_SetHour.Location = new Point(164, 128);
            textBox_SetHour.Margin = new Padding(4);
            textBox_SetHour.MaxLength = 6;
            textBox_SetHour.Name = "textBox_SetHour";
            textBox_SetHour.Size = new Size(241, 39);
            textBox_SetHour.TabIndex = 45;
            textBox_SetHour.Text = "1";
            textBox_SetHour.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_StartTime
            // 
            textBox_StartTime.Enabled = false;
            textBox_StartTime.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox_StartTime.Location = new Point(164, 75);
            textBox_StartTime.Margin = new Padding(4);
            textBox_StartTime.MaxLength = 25;
            textBox_StartTime.Name = "textBox_StartTime";
            textBox_StartTime.Size = new Size(310, 39);
            textBox_StartTime.TabIndex = 44;
            textBox_StartTime.Text = "2000-01-01 00:00:00";
            textBox_StartTime.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F);
            label10.Location = new Point(28, 134);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(112, 31);
            label10.TabIndex = 43;
            label10.Text = "설정 시간";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F);
            label9.Location = new Point(28, 291);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(83, 31);
            label9.TabIndex = 42;
            label9.Text = "파일명";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F);
            label8.Location = new Point(28, 81);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(112, 31);
            label8.TabIndex = 41;
            label8.Text = "시작 시간";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(22, 14);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(172, 32);
            label7.TabIndex = 40;
            label7.Text = "측정 기록 정보";
            // 
            // button_LoggingStop
            // 
            button_LoggingStop.FlatStyle = FlatStyle.Flat;
            button_LoggingStop.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            button_LoggingStop.Image = (Image)resources.GetObject("button_LoggingStop.Image");
            button_LoggingStop.ImageAlign = ContentAlignment.MiddleLeft;
            button_LoggingStop.Location = new Point(968, 262);
            button_LoggingStop.Margin = new Padding(4);
            button_LoggingStop.Name = "button_LoggingStop";
            button_LoggingStop.Padding = new Padding(20, 0, 0, 0);
            button_LoggingStop.Size = new Size(272, 68);
            button_LoggingStop.TabIndex = 46;
            button_LoggingStop.Text = "종료";
            button_LoggingStop.UseVisualStyleBackColor = true;
            button_LoggingStop.Click += button_LoggingStop_Click;
            // 
            // button_LoggingStart
            // 
            button_LoggingStart.FlatStyle = FlatStyle.Flat;
            button_LoggingStart.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            button_LoggingStart.Image = (Image)resources.GetObject("button_LoggingStart.Image");
            button_LoggingStart.ImageAlign = ContentAlignment.MiddleLeft;
            button_LoggingStart.Location = new Point(968, 186);
            button_LoggingStart.Margin = new Padding(4);
            button_LoggingStart.Name = "button_LoggingStart";
            button_LoggingStart.Padding = new Padding(20, 0, 0, 0);
            button_LoggingStart.Size = new Size(272, 68);
            button_LoggingStart.TabIndex = 45;
            button_LoggingStart.Text = "시작";
            button_LoggingStart.UseVisualStyleBackColor = true;
            button_LoggingStart.Click += button_LoggingStart_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gainsboro;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(textBox_SettingHours);
            panel3.Controls.Add(label16);
            panel3.Location = new Point(966, 18);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(270, 159);
            panel3.TabIndex = 44;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(182, 84);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(62, 32);
            label6.TabIndex = 34;
            label6.Text = "시간";
            // 
            // textBox_SettingHours
            // 
            textBox_SettingHours.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox_SettingHours.Location = new Point(22, 75);
            textBox_SettingHours.Margin = new Padding(4);
            textBox_SettingHours.MaxLength = 6;
            textBox_SettingHours.Name = "textBox_SettingHours";
            textBox_SettingHours.Size = new Size(148, 39);
            textBox_SettingHours.TabIndex = 33;
            textBox_SettingHours.Text = "1";
            textBox_SettingHours.TextAlign = HorizontalAlignment.Center;
            textBox_SettingHours.KeyPress += textBox_SettingHours_KeyPress;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label16.Location = new Point(46, 14);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(172, 32);
            label16.TabIndex = 32;
            label16.Text = "측정 시간 설정";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.Controls.Add(radioButton_10sec);
            panel2.Controls.Add(radioButton_5sec);
            panel2.Controls.Add(radioButton_1sec);
            panel2.Controls.Add(label17);
            panel2.Location = new Point(726, 18);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(213, 200);
            panel2.TabIndex = 42;
            // 
            // radioButton_10sec
            // 
            radioButton_10sec.AutoSize = true;
            radioButton_10sec.Font = new Font("Segoe UI", 11.25F);
            radioButton_10sec.Location = new Point(27, 142);
            radioButton_10sec.Margin = new Padding(4);
            radioButton_10sec.Name = "radioButton_10sec";
            radioButton_10sec.Size = new Size(92, 35);
            radioButton_10sec.TabIndex = 35;
            radioButton_10sec.Text = "10 초";
            radioButton_10sec.UseVisualStyleBackColor = true;
            // 
            // radioButton_5sec
            // 
            radioButton_5sec.AutoSize = true;
            radioButton_5sec.Font = new Font("Segoe UI", 11.25F);
            radioButton_5sec.Location = new Point(27, 102);
            radioButton_5sec.Margin = new Padding(4);
            radioButton_5sec.Name = "radioButton_5sec";
            radioButton_5sec.Size = new Size(80, 35);
            radioButton_5sec.TabIndex = 34;
            radioButton_5sec.Text = "5 초";
            radioButton_5sec.UseVisualStyleBackColor = true;
            // 
            // radioButton_1sec
            // 
            radioButton_1sec.AutoSize = true;
            radioButton_1sec.Checked = true;
            radioButton_1sec.Font = new Font("Segoe UI", 11.25F);
            radioButton_1sec.Location = new Point(27, 62);
            radioButton_1sec.Margin = new Padding(4);
            radioButton_1sec.Name = "radioButton_1sec";
            radioButton_1sec.Size = new Size(80, 35);
            radioButton_1sec.TabIndex = 33;
            radioButton_1sec.TabStop = true;
            radioButton_1sec.Text = "1 초";
            radioButton_1sec.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label17.Location = new Point(22, 14);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(172, 32);
            label17.TabIndex = 32;
            label17.Text = "측정 주기 설정";
            // 
            // panel7
            // 
            panel7.BackColor = Color.Silver;
            panel7.Controls.Add(formsPlot2);
            panel7.Location = new Point(16, 986);
            panel7.Margin = new Padding(4);
            panel7.Name = "panel7";
            panel7.Size = new Size(1740, 212);
            panel7.TabIndex = 49;
            // 
            // formsPlot2
            // 
            formsPlot2.DisplayScale = 1F;
            formsPlot2.Dock = DockStyle.Fill;
            formsPlot2.Enabled = false;
            formsPlot2.Location = new Point(0, 0);
            formsPlot2.Margin = new Padding(4);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Padding = new Padding(4);
            formsPlot2.Size = new Size(1740, 212);
            formsPlot2.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Silver;
            panel6.Controls.Add(formsPlot1);
            panel6.Location = new Point(16, 440);
            panel6.Margin = new Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new Size(1740, 537);
            panel6.TabIndex = 48;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Enabled = false;
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Margin = new Padding(4);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Padding = new Padding(4);
            formsPlot1.Size = new Size(1740, 537);
            formsPlot1.TabIndex = 0;
            // 
            // label_Temp1
            // 
            label_Temp1.BackColor = Color.Black;
            label_Temp1.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            label_Temp1.ForeColor = Color.Red;
            label_Temp1.Location = new Point(238, 87);
            label_Temp1.Margin = new Padding(4, 0, 4, 0);
            label_Temp1.Name = "label_Temp1";
            label_Temp1.Size = new Size(135, 57);
            label_Temp1.TabIndex = 50;
            label_Temp1.Text = "0";
            label_Temp1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Alarm1
            // 
            label_Alarm1.AutoSize = true;
            label_Alarm1.BackColor = Color.DarkGray;
            label_Alarm1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Alarm1.ForeColor = Color.Gray;
            label_Alarm1.Location = new Point(178, 114);
            label_Alarm1.Margin = new Padding(4, 0, 4, 0);
            label_Alarm1.Name = "label_Alarm1";
            label_Alarm1.Size = new Size(29, 29);
            label_Alarm1.TabIndex = 52;
            label_Alarm1.Text = "●";
            // 
            // label_Alarm2
            // 
            label_Alarm2.AutoSize = true;
            label_Alarm2.BackColor = Color.DarkGray;
            label_Alarm2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Alarm2.ForeColor = Color.Gray;
            label_Alarm2.Location = new Point(178, 200);
            label_Alarm2.Margin = new Padding(4, 0, 4, 0);
            label_Alarm2.Name = "label_Alarm2";
            label_Alarm2.Size = new Size(29, 29);
            label_Alarm2.TabIndex = 53;
            label_Alarm2.Text = "●";
            // 
            // label_Leak1
            // 
            label_Leak1.AutoSize = true;
            label_Leak1.BackColor = Color.FromArgb(179, 178, 178);
            label_Leak1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Leak1.ForeColor = Color.Gray;
            label_Leak1.Location = new Point(183, 288);
            label_Leak1.Margin = new Padding(4, 0, 4, 0);
            label_Leak1.Name = "label_Leak1";
            label_Leak1.Size = new Size(29, 29);
            label_Leak1.TabIndex = 54;
            label_Leak1.Text = "●";
            // 
            // timer_Display
            // 
            timer_Display.Interval = 200;
            timer_Display.Tick += timer_Display_Tick;
            // 
            // timer_Chart
            // 
            timer_Chart.Interval = 1000;
            timer_Chart.Tick += timer_Chart_Tick;
            // 
            // label_Temp2
            // 
            label_Temp2.BackColor = Color.Black;
            label_Temp2.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            label_Temp2.ForeColor = Color.Red;
            label_Temp2.Location = new Point(378, 87);
            label_Temp2.Margin = new Padding(4, 0, 4, 0);
            label_Temp2.Name = "label_Temp2";
            label_Temp2.Size = new Size(135, 57);
            label_Temp2.TabIndex = 55;
            label_Temp2.Text = "0";
            label_Temp2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Temp3
            // 
            label_Temp3.BackColor = Color.Black;
            label_Temp3.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            label_Temp3.ForeColor = Color.Red;
            label_Temp3.Location = new Point(519, 87);
            label_Temp3.Margin = new Padding(4, 0, 4, 0);
            label_Temp3.Name = "label_Temp3";
            label_Temp3.Size = new Size(135, 57);
            label_Temp3.TabIndex = 56;
            label_Temp3.Text = "0";
            label_Temp3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Temp4
            // 
            label_Temp4.BackColor = Color.Black;
            label_Temp4.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            label_Temp4.ForeColor = Color.Red;
            label_Temp4.Location = new Point(238, 172);
            label_Temp4.Margin = new Padding(4, 0, 4, 0);
            label_Temp4.Name = "label_Temp4";
            label_Temp4.Size = new Size(135, 57);
            label_Temp4.TabIndex = 57;
            label_Temp4.Text = "0";
            label_Temp4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Temp5
            // 
            label_Temp5.BackColor = Color.Black;
            label_Temp5.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            label_Temp5.ForeColor = Color.Red;
            label_Temp5.Location = new Point(378, 172);
            label_Temp5.Margin = new Padding(4, 0, 4, 0);
            label_Temp5.Name = "label_Temp5";
            label_Temp5.Size = new Size(135, 57);
            label_Temp5.TabIndex = 58;
            label_Temp5.Text = "0";
            label_Temp5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Leak2
            // 
            label_Leak2.AutoSize = true;
            label_Leak2.BackColor = Color.FromArgb(179, 178, 178);
            label_Leak2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Leak2.ForeColor = Color.Gray;
            label_Leak2.Location = new Point(214, 288);
            label_Leak2.Margin = new Padding(4, 0, 4, 0);
            label_Leak2.Name = "label_Leak2";
            label_Leak2.Size = new Size(29, 29);
            label_Leak2.TabIndex = 59;
            label_Leak2.Text = "●";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(179, 178, 178);
            label1.Font = new Font("Segoe UI", 6F);
            label1.Location = new Point(190, 315);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(13, 15);
            label1.TabIndex = 60;
            label1.Text = "1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(179, 178, 178);
            label2.Font = new Font("Segoe UI", 6F);
            label2.Location = new Point(222, 315);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(13, 15);
            label2.TabIndex = 61;
            label2.Text = "2";
            // 
            // button_SetUp
            // 
            button_SetUp.FlatStyle = FlatStyle.Flat;
            button_SetUp.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            button_SetUp.Image = (Image)resources.GetObject("button_SetUp.Image");
            button_SetUp.ImageAlign = ContentAlignment.MiddleLeft;
            button_SetUp.Location = new Point(966, 359);
            button_SetUp.Margin = new Padding(4);
            button_SetUp.Name = "button_SetUp";
            button_SetUp.Padding = new Padding(20, 0, 0, 0);
            button_SetUp.Size = new Size(272, 68);
            button_SetUp.TabIndex = 62;
            button_SetUp.Text = "설정";
            button_SetUp.UseVisualStyleBackColor = true;
            button_SetUp.Click += button_SetUp_Click;
            // 
            // MonitorCh7
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1776, 1216);
            Controls.Add(button_SetUp);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label_Leak2);
            Controls.Add(label_Temp5);
            Controls.Add(label_Temp4);
            Controls.Add(label_Temp3);
            Controls.Add(label_Temp2);
            Controls.Add(label_Leak1);
            Controls.Add(label_Alarm2);
            Controls.Add(label_Alarm1);
            Controls.Add(label_Temp1);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(button_LoggingStop);
            Controls.Add(button_LoggingStart);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label_Running2);
            Controls.Add(label_Running1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MonitorCh7";
            Text = "TML-T (7ch)";
            FormClosing += MonitorCh7_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label_Running1;
        private Label label_Running2;
        private Panel panel1;
        private Label label3;
        private Button button_Connect;
        private ComboBox comboBox_Baudrate;
        private Label label4;
        private ComboBox comboBox_Comport;
        private Panel panel5;
        private RadioButton radioButton_60min;
        private RadioButton radioButton_10min;
        private RadioButton radioButton_1min;
        private Label label5;
        private Panel panel4;
        private Label label14;
        private TextBox textBox_SamplingRate;
        private Label label15;
        private Label label_Status;
        private Label label12;
        private TextBox textBox_ProgressHour;
        private Label label13;
        private Button button_OpenFileFolder;
        private TextBox textBox_FileName;
        private Label label11;
        private TextBox textBox_SetHour;
        private TextBox textBox_StartTime;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button button_LoggingStop;
        private Button button_LoggingStart;
        private Panel panel3;
        private Label label6;
        private TextBox textBox_SettingHours;
        private Label label16;
        private Panel panel2;
        private RadioButton radioButton_10sec;
        private RadioButton radioButton_5sec;
        private RadioButton radioButton_1sec;
        private Label label17;
        private Panel panel7;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private Panel panel6;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Label label_Temp1;
        private Label label_Alarm1;
        private Label label_Alarm2;
        private Label label_Leak1;
        private System.Windows.Forms.Timer timer_Display;
        private System.Windows.Forms.Timer timer_Chart;
        private Label label_Temp2;
        private Label label_Temp3;
        private Label label_Temp4;
        private Label label_Temp5;
        private Label label_Leak2;
        private Label label1;
        private Label label2;
        private Button button_SetUp;
    }
}