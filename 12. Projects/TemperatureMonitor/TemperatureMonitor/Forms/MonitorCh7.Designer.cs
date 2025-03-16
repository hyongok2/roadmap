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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorCh7));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Running1 = new System.Windows.Forms.Label();
            this.label_Running2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.comboBox_Baudrate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Comport = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButton_60min = new System.Windows.Forms.RadioButton();
            this.radioButton_10min = new System.Windows.Forms.RadioButton();
            this.radioButton_1min = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_SamplingRate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label_Status = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_ProgressHour = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button_OpenFileFolder = new System.Windows.Forms.Button();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_SetHour = new System.Windows.Forms.TextBox();
            this.textBox_StartTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_LoggingStop = new System.Windows.Forms.Button();
            this.button_LoggingStart = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_SettingHours = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton_10sec = new System.Windows.Forms.RadioButton();
            this.radioButton_5sec = new System.Windows.Forms.RadioButton();
            this.radioButton_1sec = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            this.panel6 = new System.Windows.Forms.Panel();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.label_Temp1 = new System.Windows.Forms.Label();
            this.label_Alarm1 = new System.Windows.Forms.Label();
            this.label_Alarm2 = new System.Windows.Forms.Label();
            this.label_Leak1 = new System.Windows.Forms.Label();
            this.timer_Display = new System.Windows.Forms.Timer(this.components);
            this.timer_Chart = new System.Windows.Forms.Timer(this.components);
            this.label_Temp2 = new System.Windows.Forms.Label();
            this.label_Temp3 = new System.Windows.Forms.Label();
            this.label_Temp4 = new System.Windows.Forms.Label();
            this.label_Temp5 = new System.Windows.Forms.Label();
            this.label_Leak2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(461, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_Running1
            // 
            this.label_Running1.AutoSize = true;
            this.label_Running1.BackColor = System.Drawing.Color.DarkGray;
            this.label_Running1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Running1.ForeColor = System.Drawing.Color.Gray;
            this.label_Running1.Location = new System.Drawing.Point(121, 55);
            this.label_Running1.Margin = new System.Windows.Forms.Padding(0);
            this.label_Running1.Name = "label_Running1";
            this.label_Running1.Size = new System.Drawing.Size(20, 20);
            this.label_Running1.TabIndex = 30;
            this.label_Running1.Text = "●";
            // 
            // label_Running2
            // 
            this.label_Running2.AutoSize = true;
            this.label_Running2.BackColor = System.Drawing.Color.DarkGray;
            this.label_Running2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Running2.ForeColor = System.Drawing.Color.Gray;
            this.label_Running2.Location = new System.Drawing.Point(121, 112);
            this.label_Running2.Margin = new System.Windows.Forms.Padding(0);
            this.label_Running2.Name = "label_Running2";
            this.label_Running2.Size = new System.Drawing.Size(20, 20);
            this.label_Running2.TabIndex = 31;
            this.label_Running2.Text = "●";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button_Connect);
            this.panel1.Controls.Add(this.comboBox_Baudrate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox_Comport);
            this.panel1.Location = new System.Drawing.Point(12, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 37);
            this.panel1.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(17, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "컴포트";
            // 
            // button_Connect
            // 
            this.button_Connect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Connect.Location = new System.Drawing.Point(379, 7);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(2);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(72, 22);
            this.button_Connect.TabIndex = 32;
            this.button_Connect.Text = "통신 연결";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // comboBox_Baudrate
            // 
            this.comboBox_Baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Baudrate.FormattingEnabled = true;
            this.comboBox_Baudrate.Location = new System.Drawing.Point(255, 7);
            this.comboBox_Baudrate.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Baudrate.Name = "comboBox_Baudrate";
            this.comboBox_Baudrate.Size = new System.Drawing.Size(104, 23);
            this.comboBox_Baudrate.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(197, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 34;
            this.label4.Text = "통신속도";
            // 
            // comboBox_Comport
            // 
            this.comboBox_Comport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Comport.FormattingEnabled = true;
            this.comboBox_Comport.Location = new System.Drawing.Point(63, 7);
            this.comboBox_Comport.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Comport.Name = "comboBox_Comport";
            this.comboBox_Comport.Size = new System.Drawing.Size(104, 23);
            this.comboBox_Comport.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGray;
            this.panel5.Controls.Add(this.radioButton_60min);
            this.panel5.Controls.Add(this.radioButton_10min);
            this.panel5.Controls.Add(this.radioButton_1min);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(484, 152);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(142, 133);
            this.panel5.TabIndex = 43;
            // 
            // radioButton_60min
            // 
            this.radioButton_60min.AutoSize = true;
            this.radioButton_60min.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton_60min.Location = new System.Drawing.Point(18, 95);
            this.radioButton_60min.Name = "radioButton_60min";
            this.radioButton_60min.Size = new System.Drawing.Size(62, 24);
            this.radioButton_60min.TabIndex = 35;
            this.radioButton_60min.Text = "60 분";
            this.radioButton_60min.UseVisualStyleBackColor = true;
            // 
            // radioButton_10min
            // 
            this.radioButton_10min.AutoSize = true;
            this.radioButton_10min.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton_10min.Location = new System.Drawing.Point(18, 68);
            this.radioButton_10min.Name = "radioButton_10min";
            this.radioButton_10min.Size = new System.Drawing.Size(62, 24);
            this.radioButton_10min.TabIndex = 34;
            this.radioButton_10min.Text = "10 분";
            this.radioButton_10min.UseVisualStyleBackColor = true;
            // 
            // radioButton_1min
            // 
            this.radioButton_1min.AutoSize = true;
            this.radioButton_1min.Checked = true;
            this.radioButton_1min.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton_1min.Location = new System.Drawing.Point(18, 41);
            this.radioButton_1min.Name = "radioButton_1min";
            this.radioButton_1min.Size = new System.Drawing.Size(54, 24);
            this.radioButton_1min.TabIndex = 33;
            this.radioButton_1min.TabStop = true;
            this.radioButton_1min.Text = "1 분";
            this.radioButton_1min.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(15, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 21);
            this.label5.TabIndex = 32;
            this.label5.Text = "차트 표시 범위";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.textBox_SamplingRate);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label_Status);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.textBox_ProgressHour);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.button_OpenFileFolder);
            this.panel4.Controls.Add(this.textBox_FileName);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.textBox_SetHour);
            this.panel4.Controls.Add(this.textBox_StartTime);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(841, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(330, 273);
            this.panel4.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(275, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 21);
            this.label14.TabIndex = 53;
            this.label14.Text = "초";
            // 
            // textBox_SamplingRate
            // 
            this.textBox_SamplingRate.Enabled = false;
            this.textBox_SamplingRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_SamplingRate.Location = new System.Drawing.Point(110, 155);
            this.textBox_SamplingRate.MaxLength = 6;
            this.textBox_SamplingRate.Name = "textBox_SamplingRate";
            this.textBox_SamplingRate.Size = new System.Drawing.Size(162, 29);
            this.textBox_SamplingRate.TabIndex = 52;
            this.textBox_SamplingRate.Text = "1";
            this.textBox_SamplingRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(20, 159);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 20);
            this.label15.TabIndex = 51;
            this.label15.Text = "측정 주기";
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.BackColor = System.Drawing.Color.Gainsboro;
            this.label_Status.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Status.ForeColor = System.Drawing.Color.White;
            this.label_Status.Location = new System.Drawing.Point(193, 7);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(130, 30);
            this.label_Status.TabIndex = 42;
            this.label_Status.Text = "측정 대기 중";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(274, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 21);
            this.label12.TabIndex = 50;
            this.label12.Text = "시간";
            // 
            // textBox_ProgressHour
            // 
            this.textBox_ProgressHour.Enabled = false;
            this.textBox_ProgressHour.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_ProgressHour.Location = new System.Drawing.Point(109, 120);
            this.textBox_ProgressHour.MaxLength = 6;
            this.textBox_ProgressHour.Name = "textBox_ProgressHour";
            this.textBox_ProgressHour.Size = new System.Drawing.Size(162, 29);
            this.textBox_ProgressHour.TabIndex = 49;
            this.textBox_ProgressHour.Text = "1";
            this.textBox_ProgressHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(19, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 20);
            this.label13.TabIndex = 48;
            this.label13.Text = "경과 시간";
            // 
            // button_OpenFileFolder
            // 
            this.button_OpenFileFolder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_OpenFileFolder.Location = new System.Drawing.Point(18, 228);
            this.button_OpenFileFolder.Name = "button_OpenFileFolder";
            this.button_OpenFileFolder.Size = new System.Drawing.Size(299, 34);
            this.button_OpenFileFolder.TabIndex = 42;
            this.button_OpenFileFolder.Text = "파일 경로 열기";
            this.button_OpenFileFolder.UseVisualStyleBackColor = true;
            this.button_OpenFileFolder.Click += new System.EventHandler(this.button_OpenFileFolder_Click);
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Enabled = false;
            this.textBox_FileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_FileName.Location = new System.Drawing.Point(79, 190);
            this.textBox_FileName.MaxLength = 25;
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(238, 29);
            this.textBox_FileName.TabIndex = 47;
            this.textBox_FileName.Text = "TML-R_20250315170000.csv";
            this.textBox_FileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(274, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 21);
            this.label11.TabIndex = 46;
            this.label11.Text = "시간";
            // 
            // textBox_SetHour
            // 
            this.textBox_SetHour.Enabled = false;
            this.textBox_SetHour.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_SetHour.Location = new System.Drawing.Point(109, 85);
            this.textBox_SetHour.MaxLength = 6;
            this.textBox_SetHour.Name = "textBox_SetHour";
            this.textBox_SetHour.Size = new System.Drawing.Size(162, 29);
            this.textBox_SetHour.TabIndex = 45;
            this.textBox_SetHour.Text = "1";
            this.textBox_SetHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_StartTime
            // 
            this.textBox_StartTime.Enabled = false;
            this.textBox_StartTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_StartTime.Location = new System.Drawing.Point(109, 50);
            this.textBox_StartTime.MaxLength = 25;
            this.textBox_StartTime.Name = "textBox_StartTime";
            this.textBox_StartTime.Size = new System.Drawing.Size(208, 29);
            this.textBox_StartTime.TabIndex = 44;
            this.textBox_StartTime.Text = "2000-01-01 00:00:00";
            this.textBox_StartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(19, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 20);
            this.label10.TabIndex = 43;
            this.label10.Text = "설정 시간";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(19, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "파일명";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(19, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "시작 시간";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(15, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 21);
            this.label7.TabIndex = 40;
            this.label7.Text = "측정 기록 정보";
            // 
            // button_LoggingStop
            // 
            this.button_LoggingStop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_LoggingStop.Location = new System.Drawing.Point(644, 206);
            this.button_LoggingStop.Name = "button_LoggingStop";
            this.button_LoggingStop.Size = new System.Drawing.Size(181, 79);
            this.button_LoggingStop.TabIndex = 46;
            this.button_LoggingStop.Text = "종료";
            this.button_LoggingStop.UseVisualStyleBackColor = true;
            this.button_LoggingStop.Click += new System.EventHandler(this.button_LoggingStop_Click);
            // 
            // button_LoggingStart
            // 
            this.button_LoggingStart.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_LoggingStart.Location = new System.Drawing.Point(644, 124);
            this.button_LoggingStart.Name = "button_LoggingStart";
            this.button_LoggingStart.Size = new System.Drawing.Size(181, 79);
            this.button_LoggingStart.TabIndex = 45;
            this.button_LoggingStart.Text = "시작";
            this.button_LoggingStart.UseVisualStyleBackColor = true;
            this.button_LoggingStart.Click += new System.EventHandler(this.button_LoggingStart_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.textBox_SettingHours);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Location = new System.Drawing.Point(644, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 106);
            this.panel3.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(121, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 34;
            this.label6.Text = "시간";
            // 
            // textBox_SettingHours
            // 
            this.textBox_SettingHours.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox_SettingHours.Location = new System.Drawing.Point(15, 50);
            this.textBox_SettingHours.MaxLength = 6;
            this.textBox_SettingHours.Name = "textBox_SettingHours";
            this.textBox_SettingHours.Size = new System.Drawing.Size(100, 29);
            this.textBox_SettingHours.TabIndex = 33;
            this.textBox_SettingHours.Text = "1";
            this.textBox_SettingHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SettingHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SettingHours_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(31, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 21);
            this.label16.TabIndex = 32;
            this.label16.Text = "측정 시간 설정";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.radioButton_10sec);
            this.panel2.Controls.Add(this.radioButton_5sec);
            this.panel2.Controls.Add(this.radioButton_1sec);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Location = new System.Drawing.Point(484, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(142, 133);
            this.panel2.TabIndex = 42;
            // 
            // radioButton_10sec
            // 
            this.radioButton_10sec.AutoSize = true;
            this.radioButton_10sec.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton_10sec.Location = new System.Drawing.Point(18, 95);
            this.radioButton_10sec.Name = "radioButton_10sec";
            this.radioButton_10sec.Size = new System.Drawing.Size(62, 24);
            this.radioButton_10sec.TabIndex = 35;
            this.radioButton_10sec.Text = "10 초";
            this.radioButton_10sec.UseVisualStyleBackColor = true;
            // 
            // radioButton_5sec
            // 
            this.radioButton_5sec.AutoSize = true;
            this.radioButton_5sec.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton_5sec.Location = new System.Drawing.Point(18, 68);
            this.radioButton_5sec.Name = "radioButton_5sec";
            this.radioButton_5sec.Size = new System.Drawing.Size(54, 24);
            this.radioButton_5sec.TabIndex = 34;
            this.radioButton_5sec.Text = "5 초";
            this.radioButton_5sec.UseVisualStyleBackColor = true;
            // 
            // radioButton_1sec
            // 
            this.radioButton_1sec.AutoSize = true;
            this.radioButton_1sec.Checked = true;
            this.radioButton_1sec.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButton_1sec.Location = new System.Drawing.Point(18, 41);
            this.radioButton_1sec.Name = "radioButton_1sec";
            this.radioButton_1sec.Size = new System.Drawing.Size(54, 24);
            this.radioButton_1sec.TabIndex = 33;
            this.radioButton_1sec.TabStop = true;
            this.radioButton_1sec.Text = "1 초";
            this.radioButton_1sec.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(15, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(114, 21);
            this.label17.TabIndex = 32;
            this.label17.Text = "측정 주기 설정";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Silver;
            this.panel7.Controls.Add(this.formsPlot2);
            this.panel7.Location = new System.Drawing.Point(11, 657);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1160, 141);
            this.panel7.TabIndex = 49;
            // 
            // formsPlot2
            // 
            this.formsPlot2.DisplayScale = 1F;
            this.formsPlot2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot2.Enabled = false;
            this.formsPlot2.Location = new System.Drawing.Point(0, 0);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Padding = new System.Windows.Forms.Padding(3);
            this.formsPlot2.Size = new System.Drawing.Size(1160, 141);
            this.formsPlot2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.Controls.Add(this.formsPlot1);
            this.panel6.Location = new System.Drawing.Point(11, 293);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1160, 358);
            this.panel6.TabIndex = 48;
            // 
            // formsPlot1
            // 
            this.formsPlot1.DisplayScale = 1F;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Enabled = false;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Padding = new System.Windows.Forms.Padding(3);
            this.formsPlot1.Size = new System.Drawing.Size(1160, 358);
            this.formsPlot1.TabIndex = 0;
            // 
            // label_Temp1
            // 
            this.label_Temp1.BackColor = System.Drawing.Color.Black;
            this.label_Temp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Temp1.ForeColor = System.Drawing.Color.Red;
            this.label_Temp1.Location = new System.Drawing.Point(159, 59);
            this.label_Temp1.Name = "label_Temp1";
            this.label_Temp1.Size = new System.Drawing.Size(90, 38);
            this.label_Temp1.TabIndex = 50;
            this.label_Temp1.Text = "0";
            this.label_Temp1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Alarm1
            // 
            this.label_Alarm1.AutoSize = true;
            this.label_Alarm1.BackColor = System.Drawing.Color.DarkGray;
            this.label_Alarm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Alarm1.ForeColor = System.Drawing.Color.Gray;
            this.label_Alarm1.Location = new System.Drawing.Point(121, 77);
            this.label_Alarm1.Name = "label_Alarm1";
            this.label_Alarm1.Size = new System.Drawing.Size(20, 20);
            this.label_Alarm1.TabIndex = 52;
            this.label_Alarm1.Text = "●";
            // 
            // label_Alarm2
            // 
            this.label_Alarm2.AutoSize = true;
            this.label_Alarm2.BackColor = System.Drawing.Color.DarkGray;
            this.label_Alarm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Alarm2.ForeColor = System.Drawing.Color.Gray;
            this.label_Alarm2.Location = new System.Drawing.Point(121, 136);
            this.label_Alarm2.Name = "label_Alarm2";
            this.label_Alarm2.Size = new System.Drawing.Size(20, 20);
            this.label_Alarm2.TabIndex = 53;
            this.label_Alarm2.Text = "●";
            // 
            // label_Leak1
            // 
            this.label_Leak1.AutoSize = true;
            this.label_Leak1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.label_Leak1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Leak1.ForeColor = System.Drawing.Color.Gray;
            this.label_Leak1.Location = new System.Drawing.Point(122, 192);
            this.label_Leak1.Name = "label_Leak1";
            this.label_Leak1.Size = new System.Drawing.Size(20, 20);
            this.label_Leak1.TabIndex = 54;
            this.label_Leak1.Text = "●";
            // 
            // timer_Display
            // 
            this.timer_Display.Interval = 200;
            this.timer_Display.Tick += new System.EventHandler(this.timer_Display_Tick);
            // 
            // timer_Chart
            // 
            this.timer_Chart.Interval = 1000;
            this.timer_Chart.Tick += new System.EventHandler(this.timer_Chart_Tick);
            // 
            // label_Temp2
            // 
            this.label_Temp2.BackColor = System.Drawing.Color.Black;
            this.label_Temp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Temp2.ForeColor = System.Drawing.Color.Red;
            this.label_Temp2.Location = new System.Drawing.Point(253, 59);
            this.label_Temp2.Name = "label_Temp2";
            this.label_Temp2.Size = new System.Drawing.Size(90, 38);
            this.label_Temp2.TabIndex = 55;
            this.label_Temp2.Text = "0";
            this.label_Temp2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Temp3
            // 
            this.label_Temp3.BackColor = System.Drawing.Color.Black;
            this.label_Temp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Temp3.ForeColor = System.Drawing.Color.Red;
            this.label_Temp3.Location = new System.Drawing.Point(347, 59);
            this.label_Temp3.Name = "label_Temp3";
            this.label_Temp3.Size = new System.Drawing.Size(90, 38);
            this.label_Temp3.TabIndex = 56;
            this.label_Temp3.Text = "0";
            this.label_Temp3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Temp4
            // 
            this.label_Temp4.BackColor = System.Drawing.Color.Black;
            this.label_Temp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Temp4.ForeColor = System.Drawing.Color.Red;
            this.label_Temp4.Location = new System.Drawing.Point(159, 116);
            this.label_Temp4.Name = "label_Temp4";
            this.label_Temp4.Size = new System.Drawing.Size(90, 38);
            this.label_Temp4.TabIndex = 57;
            this.label_Temp4.Text = "0";
            this.label_Temp4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Temp5
            // 
            this.label_Temp5.BackColor = System.Drawing.Color.Black;
            this.label_Temp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Temp5.ForeColor = System.Drawing.Color.Red;
            this.label_Temp5.Location = new System.Drawing.Point(253, 116);
            this.label_Temp5.Name = "label_Temp5";
            this.label_Temp5.Size = new System.Drawing.Size(90, 38);
            this.label_Temp5.TabIndex = 58;
            this.label_Temp5.Text = "0";
            this.label_Temp5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Leak2
            // 
            this.label_Leak2.AutoSize = true;
            this.label_Leak2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.label_Leak2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Leak2.ForeColor = System.Drawing.Color.Gray;
            this.label_Leak2.Location = new System.Drawing.Point(146, 192);
            this.label_Leak2.Name = "label_Leak2";
            this.label_Leak2.Size = new System.Drawing.Size(20, 20);
            this.label_Leak2.TabIndex = 59;
            this.label_Leak2.Text = "●";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(127, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 11);
            this.label1.TabIndex = 60;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(151, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 11);
            this.label2.TabIndex = 61;
            this.label2.Text = "2";
            // 
            // MonitorCh7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 811);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Leak2);
            this.Controls.Add(this.label_Temp5);
            this.Controls.Add(this.label_Temp4);
            this.Controls.Add(this.label_Temp3);
            this.Controls.Add(this.label_Temp2);
            this.Controls.Add(this.label_Leak1);
            this.Controls.Add(this.label_Alarm2);
            this.Controls.Add(this.label_Alarm1);
            this.Controls.Add(this.label_Temp1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button_LoggingStop);
            this.Controls.Add(this.button_LoggingStart);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_Running2);
            this.Controls.Add(this.label_Running1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MonitorCh7";
            this.Text = "TML-T (7ch)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}