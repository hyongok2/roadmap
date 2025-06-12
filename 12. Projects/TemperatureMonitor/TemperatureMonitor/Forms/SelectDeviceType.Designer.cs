namespace TemperatureMonitor.Forms
{
    partial class SelectDeviceType
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
            button_Ch2 = new Button();
            button_Ch3 = new Button();
            button_Ch7 = new Button();
            SuspendLayout();
            // 
            // button_Ch2
            // 
            button_Ch2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            button_Ch2.Location = new Point(11, 12);
            button_Ch2.Name = "button_Ch2";
            button_Ch2.Size = new Size(474, 67);
            button_Ch2.TabIndex = 0;
            button_Ch2.Text = "TML-R S (2ch)";
            button_Ch2.UseVisualStyleBackColor = true;
            button_Ch2.Click += button_Ch2_Click;
            // 
            // button_Ch3
            // 
            button_Ch3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            button_Ch3.Location = new Point(11, 85);
            button_Ch3.Name = "button_Ch3";
            button_Ch3.Size = new Size(474, 67);
            button_Ch3.TabIndex = 1;
            button_Ch3.Text = "TML-R D (3ch)";
            button_Ch3.UseVisualStyleBackColor = true;
            button_Ch3.Click += button_Ch3_Click;
            // 
            // button_Ch7
            // 
            button_Ch7.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            button_Ch7.Location = new Point(12, 158);
            button_Ch7.Name = "button_Ch7";
            button_Ch7.Size = new Size(474, 67);
            button_Ch7.TabIndex = 2;
            button_Ch7.Text = "TML-T (7ch)";
            button_Ch7.UseVisualStyleBackColor = true;
            button_Ch7.Click += button_Ch7_Click;
            // 
            // SelectDeviceType
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(498, 238);
            Controls.Add(button_Ch7);
            Controls.Add(button_Ch3);
            Controls.Add(button_Ch2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectDeviceType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "모델을 선택해 주세요.";
            ResumeLayout(false);

        }

        #endregion

        private Button button_Ch2;
        private Button button_Ch3;
        private Button button_Ch7;
    }
}