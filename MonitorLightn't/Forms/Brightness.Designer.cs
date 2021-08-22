﻿namespace MonitorLightnt
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
            this.BrightnessImageToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ContrastImageToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ScreenComboBox = new System.Windows.Forms.ComboBox();
            this.LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.OverlaySlider = new MonitorLightnt.NoFocusSlider();
            this.BrightnessSlider = new MonitorLightnt.NoFocusSlider();
            this.ContrastSlider = new MonitorLightnt.NoFocusSlider();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayImage)).BeginInit();
            this.LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlaySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // OverlayValue
            // 
            this.OverlayValue.AutoSize = true;
            this.OverlayValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.OverlayValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverlayValue.ForeColor = System.Drawing.Color.White;
            this.OverlayValue.Location = new System.Drawing.Point(315, 58);
            this.OverlayValue.Margin = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.OverlayValue.Name = "OverlayValue";
            this.OverlayValue.Size = new System.Drawing.Size(39, 45);
            this.OverlayValue.TabIndex = 1;
            this.OverlayValue.Text = "100";
            this.OverlayValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrightnessValue
            // 
            this.BrightnessValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.BrightnessValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrightnessValue.ForeColor = System.Drawing.Color.White;
            this.BrightnessValue.Location = new System.Drawing.Point(315, 113);
            this.BrightnessValue.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.BrightnessValue.Name = "BrightnessValue";
            this.BrightnessValue.Size = new System.Drawing.Size(39, 40);
            this.BrightnessValue.TabIndex = 4;
            this.BrightnessValue.Text = "100";
            this.BrightnessValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrightnessLabel
            // 
            this.BrightnessLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BrightnessLabel.BackColor = System.Drawing.Color.Transparent;
            this.BrightnessLabel.ForeColor = System.Drawing.Color.Transparent;
            this.BrightnessLabel.Location = new System.Drawing.Point(72, 192);
            this.BrightnessLabel.Margin = new System.Windows.Forms.Padding(50, 0, 0, 50);
            this.BrightnessLabel.MinimumSize = new System.Drawing.Size(230, 13);
            this.BrightnessLabel.Name = "BrightnessLabel";
            this.BrightnessLabel.Size = new System.Drawing.Size(240, 13);
            this.BrightnessLabel.TabIndex = 6;
            this.BrightnessLabel.Text = "0               25              50             75            100";
            // 
            // ContrastLabel
            // 
            this.ContrastLabel.AutoSize = true;
            this.ContrastLabel.BackColor = System.Drawing.Color.Transparent;
            this.ContrastLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ContrastLabel.ForeColor = System.Drawing.Color.Transparent;
            this.ContrastLabel.Location = new System.Drawing.Point(72, 142);
            this.ContrastLabel.Margin = new System.Windows.Forms.Padding(10, 0, 30, 0);
            this.ContrastLabel.MinimumSize = new System.Drawing.Size(230, 10);
            this.ContrastLabel.Name = "ContrastLabel";
            this.ContrastLabel.Size = new System.Drawing.Size(230, 13);
            this.ContrastLabel.TabIndex = 10;
            this.ContrastLabel.Text = "0               25              50             75            100";
            // 
            // ContrastValue
            // 
            this.ContrastValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.ContrastValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContrastValue.ForeColor = System.Drawing.Color.White;
            this.ContrastValue.Location = new System.Drawing.Point(315, 163);
            this.ContrastValue.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.ContrastValue.Name = "ContrastValue";
            this.ContrastValue.Size = new System.Drawing.Size(40, 40);
            this.ContrastValue.TabIndex = 8;
            this.ContrastValue.Text = "100";
            this.ContrastValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContrastImage
            // 
            this.ContrastImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.ContrastImage.Image = ((System.Drawing.Image)(resources.GetObject("ContrastImage.Image")));
            this.ContrastImage.Location = new System.Drawing.Point(30, 163);
            this.ContrastImage.Margin = new System.Windows.Forms.Padding(15, 5, 10, 0);
            this.ContrastImage.MinimumSize = new System.Drawing.Size(30, 30);
            this.ContrastImage.Name = "ContrastImage";
            this.ContrastImage.Size = new System.Drawing.Size(30, 40);
            this.ContrastImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ContrastImage.TabIndex = 9;
            this.ContrastImage.TabStop = false;
            // 
            // BrightnessImage
            // 
            this.BrightnessImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.BrightnessImage.Image = ((System.Drawing.Image)(resources.GetObject("BrightnessImage.Image")));
            this.BrightnessImage.Location = new System.Drawing.Point(30, 113);
            this.BrightnessImage.Margin = new System.Windows.Forms.Padding(15, 5, 10, 5);
            this.BrightnessImage.MinimumSize = new System.Drawing.Size(30, 30);
            this.BrightnessImage.Name = "BrightnessImage";
            this.BrightnessImage.Size = new System.Drawing.Size(30, 40);
            this.BrightnessImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BrightnessImage.TabIndex = 5;
            this.BrightnessImage.TabStop = false;
            // 
            // OverlayImage
            // 
            this.OverlayImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.OverlayImage.Image = ((System.Drawing.Image)(resources.GetObject("OverlayImage.Image")));
            this.OverlayImage.Location = new System.Drawing.Point(30, 63);
            this.OverlayImage.Margin = new System.Windows.Forms.Padding(15, 5, 10, 5);
            this.OverlayImage.MinimumSize = new System.Drawing.Size(30, 30);
            this.OverlayImage.Name = "OverlayImage";
            this.OverlayImage.Size = new System.Drawing.Size(30, 40);
            this.OverlayImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OverlayImage.TabIndex = 2;
            this.OverlayImage.TabStop = false;
            // 
            // ScreenComboBox
            // 
            this.ScreenComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScreenComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ScreenComboBox.DropDownHeight = 140;
            this.ScreenComboBox.DropDownWidth = 120;
            this.ScreenComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScreenComboBox.Font = new System.Drawing.Font("Segoe UI Black", 11F);
            this.ScreenComboBox.ForeColor = System.Drawing.Color.White;
            this.ScreenComboBox.FormattingEnabled = true;
            this.ScreenComboBox.IntegralHeight = false;
            this.ScreenComboBox.ItemHeight = 20;
            this.ScreenComboBox.Location = new System.Drawing.Point(205, 15);
            this.ScreenComboBox.Margin = new System.Windows.Forms.Padding(190, 0, 0, 15);
            this.ScreenComboBox.Name = "ScreenComboBox";
            this.ScreenComboBox.Size = new System.Drawing.Size(140, 28);
            this.ScreenComboBox.TabIndex = 11;
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.AutoSize = true;
            this.LayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.LayoutPanel.Controls.Add(this.ScreenComboBox);
            this.LayoutPanel.Controls.Add(this.OverlayImage);
            this.LayoutPanel.Controls.Add(this.OverlaySlider);
            this.LayoutPanel.Controls.Add(this.OverlayValue);
            this.LayoutPanel.Controls.Add(this.BrightnessImage);
            this.LayoutPanel.Controls.Add(this.BrightnessSlider);
            this.LayoutPanel.Controls.Add(this.BrightnessValue);
            this.LayoutPanel.Controls.Add(this.ContrastImage);
            this.LayoutPanel.Controls.Add(this.ContrastSlider);
            this.LayoutPanel.Controls.Add(this.ContrastValue);
            this.LayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutPanel.MaximumSize = new System.Drawing.Size(370, 230);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.Padding = new System.Windows.Forms.Padding(15);
            this.LayoutPanel.Size = new System.Drawing.Size(370, 218);
            this.LayoutPanel.TabIndex = 12;
            // 
            // OverlaySlider
            // 
            this.OverlaySlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OverlaySlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverlaySlider.Location = new System.Drawing.Point(70, 68);
            this.OverlaySlider.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.OverlaySlider.Maximum = 100;
            this.OverlaySlider.Minimum = 25;
            this.OverlaySlider.MinimumSize = new System.Drawing.Size(240, 40);
            this.OverlaySlider.Name = "OverlaySlider";
            this.OverlaySlider.Size = new System.Drawing.Size(240, 40);
            this.OverlaySlider.TabIndex = 0;
            this.OverlaySlider.TickFrequency = 5;
            this.OverlaySlider.Value = 100;
            // 
            // BrightnessSlider
            // 
            this.BrightnessSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BrightnessSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrightnessSlider.Location = new System.Drawing.Point(70, 113);
            this.BrightnessSlider.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.BrightnessSlider.Maximum = 100;
            this.BrightnessSlider.MinimumSize = new System.Drawing.Size(240, 40);
            this.BrightnessSlider.Name = "BrightnessSlider";
            this.BrightnessSlider.Size = new System.Drawing.Size(240, 40);
            this.BrightnessSlider.TabIndex = 3;
            this.BrightnessSlider.TickFrequency = 5;
            this.BrightnessSlider.Value = 100;
            // 
            // ContrastSlider
            // 
            this.ContrastSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ContrastSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContrastSlider.Location = new System.Drawing.Point(70, 163);
            this.ContrastSlider.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.ContrastSlider.Maximum = 100;
            this.ContrastSlider.MinimumSize = new System.Drawing.Size(240, 40);
            this.ContrastSlider.Name = "ContrastSlider";
            this.ContrastSlider.Size = new System.Drawing.Size(240, 40);
            this.ContrastSlider.TabIndex = 7;
            this.ContrastSlider.TickFrequency = 5;
            this.ContrastSlider.Value = 100;
            // 
            // Brightness
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(370, 230);
            this.ControlBox = false;
            this.Controls.Add(this.ContrastLabel);
            this.Controls.Add(this.BrightnessLabel);
            this.Controls.Add(this.LayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Brightness";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "dimwin";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.ContrastImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayImage)).EndInit();
            this.LayoutPanel.ResumeLayout(false);
            this.LayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverlaySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastSlider)).EndInit();
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
        private System.Windows.Forms.ComboBox ScreenComboBox;
        private System.Windows.Forms.FlowLayoutPanel LayoutPanel;
    }
}

