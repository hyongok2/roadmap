namespace TemperatureMonitor.Forms
{
    partial class Password
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
            textBox_Password = new TextBox();
            label1 = new Label();
            button_Ok = new Button();
            button_Cancel = new Button();
            SuspendLayout();
            // 
            // textBox_Password
            // 
            textBox_Password.Location = new Point(14, 29);
            textBox_Password.MaxLength = 10;
            textBox_Password.Name = "textBox_Password";
            textBox_Password.PasswordChar = '*';
            textBox_Password.Size = new Size(132, 23);
            textBox_Password.TabIndex = 0;
            textBox_Password.KeyPress += textBox_Password_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "비밀번호 입력";
            // 
            // button_Ok
            // 
            button_Ok.FlatAppearance.BorderColor = Color.Navy;
            button_Ok.FlatStyle = FlatStyle.Flat;
            button_Ok.Font = new Font("Segoe UI", 8.25F);
            button_Ok.Location = new Point(12, 58);
            button_Ok.Name = "button_Ok";
            button_Ok.Size = new Size(60, 25);
            button_Ok.TabIndex = 2;
            button_Ok.Text = "확인";
            button_Ok.UseVisualStyleBackColor = true;
            button_Ok.Click += button_Ok_Click;
            // 
            // button_Cancel
            // 
            button_Cancel.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            button_Cancel.FlatStyle = FlatStyle.Flat;
            button_Cancel.Font = new Font("Segoe UI", 8.25F);
            button_Cancel.Location = new Point(84, 58);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(60, 25);
            button_Cancel.TabIndex = 3;
            button_Cancel.Text = "취소";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += button_Cancel_Click;
            // 
            // Password
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(158, 90);
            Controls.Add(button_Cancel);
            Controls.Add(button_Ok);
            Controls.Add(label1);
            Controls.Add(textBox_Password);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Password";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_Password;
        private Label label1;
        private Button button_Ok;
        private Button button_Cancel;
    }
}