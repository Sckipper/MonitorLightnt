namespace MonitorLightnt
{
    partial class Brightness
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Brightness));
            this.OverlayValue = new System.Windows.Forms.Label();
            this.BrightnessValue = new System.Windows.Forms.Label();
            this.BrightnessLabel = new System.Windows.Forms.Label();
            this.ContrastLabel = new System.Windows.Forms.Label();
            this.ContrastValue = new System.Windows.Forms.Label();
            this.ContrastImage = new System.Windows.Forms.PictureBox();
            this.BrightnessImage = new System.Windows.Forms.PictureBox();
            this.OverlayImage = new System.Windows.Forms.PictureBox();
            this.OverlayImageToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ContrastSlider = new MonitorLightnt.NoFocusSlider();
            this.BrightnessSlider = new MonitorLightnt.NoFocusSlider();
            this.OverlaySlider = new MonitorLightnt.NoFocusSlider();
            this.BrightnessImageToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ContrastImageToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ContrastImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlaySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // OverlayValue
            // 
            this.OverlayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverlayValue.ForeColor = System.Drawing.Color.White;
            this.OverlayValue.Location = new System.Drawing.Point(311, 18);
            this.OverlayValue.Name = "OverlayValue";
            this.OverlayValue.Size = new System.Drawing.Size(42, 45);
            this.OverlayValue.TabIndex = 1;
            this.OverlayValue.Text = "100";
            this.OverlayValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrightnessValue
            // 
            this.BrightnessValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrightnessValue.ForeColor = System.Drawing.Color.White;
            this.BrightnessValue.Location = new System.Drawing.Point(311, 74);
            this.BrightnessValue.Name = "BrightnessValue";
            this.BrightnessValue.Size = new System.Drawing.Size(42, 45);
            this.BrightnessValue.TabIndex = 4;
            this.BrightnessValue.Text = "100";
            this.BrightnessValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrightnessLabel
            // 
            this.BrightnessLabel.AutoSize = true;
            this.BrightnessLabel.BackColor = System.Drawing.Color.Transparent;
            this.BrightnessLabel.ForeColor = System.Drawing.Color.Transparent;
            this.BrightnessLabel.Location = new System.Drawing.Point(82, 107);
            this.BrightnessLabel.Name = "BrightnessLabel";
            this.BrightnessLabel.Size = new System.Drawing.Size(223, 13);
            this.BrightnessLabel.TabIndex = 6;
            this.BrightnessLabel.Text = "0              25             50             75            100";
            // 
            // ContrastLabel
            // 
            this.ContrastLabel.AutoSize = true;
            this.ContrastLabel.BackColor = System.Drawing.Color.Transparent;
            this.ContrastLabel.ForeColor = System.Drawing.Color.Transparent;
            this.ContrastLabel.Location = new System.Drawing.Point(82, 172);
            this.ContrastLabel.Name = "ContrastLabel";
            this.ContrastLabel.Size = new System.Drawing.Size(223, 13);
            this.ContrastLabel.TabIndex = 10;
            this.ContrastLabel.Text = "0              25             50             75            100";
            // 
            // ContrastValue
            // 
            this.ContrastValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContrastValue.ForeColor = System.Drawing.Color.White;
            this.ContrastValue.Location = new System.Drawing.Point(311, 134);
            this.ContrastValue.Name = "ContrastValue";
            this.ContrastValue.Size = new System.Drawing.Size(42, 45);
            this.ContrastValue.TabIndex = 8;
            this.ContrastValue.Text = "100";
            this.ContrastValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContrastImage
            // 
            this.ContrastImage.Image = global::MonitorLightnt.Properties.Resources.contrast_31;
            this.ContrastImage.Location = new System.Drawing.Point(23, 140);
            this.ContrastImage.Name = "ContrastImage";
            this.ContrastImage.Size = new System.Drawing.Size(30, 30);
            this.ContrastImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ContrastImage.TabIndex = 9;
            this.ContrastImage.TabStop = false;
            // 
            // BrightnessImage
            // 
            this.BrightnessImage.Image = global::MonitorLightnt.Properties.Resources.brightness_2;
            this.BrightnessImage.Location = new System.Drawing.Point(23, 80);
            this.BrightnessImage.Name = "BrightnessImage";
            this.BrightnessImage.Size = new System.Drawing.Size(30, 30);
            this.BrightnessImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BrightnessImage.TabIndex = 5;
            this.BrightnessImage.TabStop = false;
            // 
            // OverlayImage
            // 
            this.OverlayImage.Image = global::MonitorLightnt.Properties.Resources.contrast;
            this.OverlayImage.Location = new System.Drawing.Point(23, 27);
            this.OverlayImage.Name = "OverlayImage";
            this.OverlayImage.Size = new System.Drawing.Size(35, 30);
            this.OverlayImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OverlayImage.TabIndex = 2;
            this.OverlayImage.TabStop = false;
            // 
            // ContrastSlider
            // 
            this.ContrastSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ContrastSlider.Location = new System.Drawing.Point(75, 143);
            this.ContrastSlider.Maximum = 100;
            this.ContrastSlider.Name = "ContrastSlider";
            this.ContrastSlider.Size = new System.Drawing.Size(230, 45);
            this.ContrastSlider.TabIndex = 7;
            this.ContrastSlider.TickFrequency = 5;
            this.ContrastSlider.Value = 1;
            // 
            // BrightnessSlider
            // 
            this.BrightnessSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BrightnessSlider.LargeChange = 10;
            this.BrightnessSlider.Location = new System.Drawing.Point(75, 78);
            this.BrightnessSlider.Maximum = 100;
            this.BrightnessSlider.Name = "BrightnessSlider";
            this.BrightnessSlider.Size = new System.Drawing.Size(230, 45);
            this.BrightnessSlider.SmallChange = 5;
            this.BrightnessSlider.TabIndex = 3;
            this.BrightnessSlider.TickFrequency = 5;
            this.BrightnessSlider.Value = 5;
            // 
            // OverlaySlider
            // 
            this.OverlaySlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OverlaySlider.Location = new System.Drawing.Point(75, 27);
            this.OverlaySlider.Maximum = 100;
            this.OverlaySlider.Minimum = 25;
            this.OverlaySlider.Name = "OverlaySlider";
            this.OverlaySlider.Size = new System.Drawing.Size(230, 45);
            this.OverlaySlider.TabIndex = 0;
            this.OverlaySlider.TickFrequency = 5;
            this.OverlaySlider.Value = 100;
            // 
            // Brightness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(370, 210);
            this.ControlBox = false;
            this.Controls.Add(this.ContrastLabel);
            this.Controls.Add(this.ContrastImage);
            this.Controls.Add(this.ContrastValue);
            this.Controls.Add(this.ContrastSlider);
            this.Controls.Add(this.BrightnessLabel);
            this.Controls.Add(this.BrightnessImage);
            this.Controls.Add(this.BrightnessValue);
            this.Controls.Add(this.BrightnessSlider);
            this.Controls.Add(this.OverlayImage);
            this.Controls.Add(this.OverlayValue);
            this.Controls.Add(this.OverlaySlider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Brightness";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "dimwin";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.ContrastImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlaySlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NoFocusSlider OverlaySlider;
        private System.Windows.Forms.Label OverlayValue;
        private System.Windows.Forms.PictureBox OverlayImage;
        private System.Windows.Forms.PictureBox BrightnessImage;
        private System.Windows.Forms.Label BrightnessValue;
        private NoFocusSlider BrightnessSlider;
        private System.Windows.Forms.Label BrightnessLabel;
        private System.Windows.Forms.Label ContrastLabel;
        private System.Windows.Forms.PictureBox ContrastImage;
        private System.Windows.Forms.Label ContrastValue;
        private NoFocusSlider ContrastSlider;
        private System.Windows.Forms.ToolTip OverlayImageToolTip;
        private System.Windows.Forms.ToolTip BrightnessImageToolTip;
        private System.Windows.Forms.ToolTip ContrastImageToolTip;
    }
}

