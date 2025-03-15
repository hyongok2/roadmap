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
            this.button_Ch2 = new System.Windows.Forms.Button();
            this.button_Ch3 = new System.Windows.Forms.Button();
            this.button_Ch7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Ch2
            // 
            this.button_Ch2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Ch2.Location = new System.Drawing.Point(11, 12);
            this.button_Ch2.Name = "button_Ch2";
            this.button_Ch2.Size = new System.Drawing.Size(474, 67);
            this.button_Ch2.TabIndex = 0;
            this.button_Ch2.Text = "TML-R S (2ch)";
            this.button_Ch2.UseVisualStyleBackColor = true;
            this.button_Ch2.Click += new System.EventHandler(this.button_Ch2_Click);
            // 
            // button_Ch3
            // 
            this.button_Ch3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Ch3.Location = new System.Drawing.Point(11, 85);
            this.button_Ch3.Name = "button_Ch3";
            this.button_Ch3.Size = new System.Drawing.Size(474, 67);
            this.button_Ch3.TabIndex = 1;
            this.button_Ch3.Text = "TML-R D (3ch)";
            this.button_Ch3.UseVisualStyleBackColor = true;
            this.button_Ch3.Click += new System.EventHandler(this.button_Ch3_Click);
            // 
            // button_Ch7
            // 
            this.button_Ch7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Ch7.Location = new System.Drawing.Point(12, 158);
            this.button_Ch7.Name = "button_Ch7";
            this.button_Ch7.Size = new System.Drawing.Size(474, 67);
            this.button_Ch7.TabIndex = 2;
            this.button_Ch7.Text = "TML-T (7ch)";
            this.button_Ch7.UseVisualStyleBackColor = true;
            this.button_Ch7.Click += new System.EventHandler(this.button_Ch7_Click);
            // 
            // SelectDeviceType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 238);
            this.Controls.Add(this.button_Ch7);
            this.Controls.Add(this.button_Ch3);
            this.Controls.Add(this.button_Ch2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDeviceType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "모델을 선택해 주세요.";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_Ch2;
        private Button button_Ch3;
        private Button button_Ch7;
    }
}