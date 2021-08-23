/*
    The MIT License (MIT)

    Copyright (c) 2019 reblGreen Software Ltd. (https://reblgreen.com/)
                  2021 Sckipper (https://github.com/Sckipper)  

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace MonitorLightnt
{
    public partial class Brightness : Form
    {
        NotifyIcon TrayIcon;
        ContextMenu TrayMenu;
        BasicWindow Overlay;
        System.Windows.Forms.Timer OntopTimer;
        bool HasChanged;
        public List<RichInfoScreen> riScreens;
        Thread getBrightnessThread;
        Thread getContrastThread;
        bool isAdvancedView = true;

        public Brightness(string[] args)
        {
            InitializeComponent();

            SetupSlidersGrid();

            SetupOntopTimer();

            SetupContrastOverlay();

            SetupSlidersForm();

            SetupScreens();

            SetupSlidersValues();

            SetupTrayIcon();
        }


        void SetupSlidersGrid()
        {
            BrightnessLabel.Parent = LayoutPanel;
            BrightnessLabel.AutoSize = true;
            BrightnessLabel.Padding = new Padding(0, 0, 0, 75);


            ContrastLabel.Parent = LayoutPanel;
        }

        private void SetupOntopTimer()
        {
            OntopTimer = new System.Windows.Forms.Timer()
            {
                Interval = 200,
            };

            OntopTimer.Tick += (sender, e) =>
            {
                if (Overlay != null)
                {
                    Overlay.Show(false, false);

                    Native.SetWindowPos(Overlay.Handle, (IntPtr)Native.HWND_TOPMOST, 0, 0, 0, 0,
                        (int)(Native.SetWindowPosFlags.SWP_NOACTIVATE | Native.SetWindowPosFlags.SWP_NOMOVE |
                        Native.SetWindowPosFlags.SWP_NOSIZE | Native.SetWindowPosFlags.SWP_SHOWWINDOW));
                }
            };

            OntopTimer.Start();
        }

        void SetupSlidersForm()
        {
            OverlaySlider.LostFocus += LoseFocus;
            BrightnessSlider.LostFocus += LoseFocus;
            LostFocus += LoseFocus;

            OverlaySlider.KeyDown += KeysDown;
            BrightnessSlider.KeyDown += KeysDown;
            KeyDown += KeysDown;

            ScreenComboBox.SelectedValueChanged += ScreenComboBoxValueChanged;
            OverlaySlider.ValueChanged += OverlaySliderValueChanged;
            OverlaySlider.MouseUp += OverlaySliderChangeValue;
            OverlayImageToolTip.SetToolTip(OverlayImage, "Overlay");
            BrightnessSlider.ValueChanged += BrightnessSliderValueChanged;
            BrightnessSlider.MouseUp += BrightnessSliderChangeValue;
            BrightnessImageToolTip.SetToolTip(BrightnessImage, "Brightness");
            ContrastSlider.ValueChanged += ContrastSliderValueChanged;
            ContrastSlider.MouseUp += ContrastSliderChangeValue;
            ContrastImageToolTip.SetToolTip(ContrastImage, "Contrast");

            StartPosition = FormStartPosition.Manual;
            SetLocation();
            Visible = false;

            if (Helpers.IsVistaOrHigher() && Native.DwmIsCompositionEnabled())
            {
                Helpers.RemoveFromAeroPeek(Handle);
            }
        }

        void SetupContrastOverlay()
        {
            int top = 0;
            int left = 0;
            int bottom = 0;
            int right = 0;

            Overlay = new BasicWindow();
            Helpers.SetGhost(Overlay.Handle);

            foreach (Screen scr in Screen.AllScreens)
            {
                top = Math.Min(top, scr.Bounds.Top) - 1;
                left = Math.Min(left, scr.Bounds.Left) - 1;
                bottom = Math.Max(bottom, scr.Bounds.Bottom) + 2;
                right = Math.Max(right, scr.Bounds.Right) + 2;
            }

            Overlay.SetLocation(left, top, right, bottom);
            Overlay.TopMost = true;

            Overlay.Opacity = 0;
            Overlay.Color = Color.Black;
            Overlay.Show(false, false);

            if (Helpers.IsVistaOrHigher() && Native.DwmIsCompositionEnabled())
            {
                Helpers.RemoveFromAeroPeek(Overlay.Handle);
            }
        }

        void SetupTrayIcon()
        {
            TrayMenu = new ContextMenu();
            TrayMenu.MenuItems.Add("Run at Startup", RunOnStartup);
            TrayMenu.MenuItems.Add(isAdvancedView ? "Basic view" : "Advanced view", RunOnStartup);
            TrayMenu.MenuItems.Add("-");
            TrayMenu.MenuItems.Add("Exit", OnExit);
            TrayMenu.MenuItems[0].Checked = Startup.CheckStartup();

            TrayIcon = new NotifyIcon();
            TrayIcon.Text = "Monitor Lightn't";
            TrayIcon.Icon = Icon;

            TrayIcon.Click += (object sender, EventArgs e) =>
            {
                SetLocation();
                Visible = true;
                Activate();
                OverlaySlider.Focus();
            };
            
            TrayIcon.ContextMenu = TrayMenu;
            TrayIcon.Visible = true;
        }

        void SetupScreens()
        {
            riScreens = RichInfoScreen.Get_RichInfo_Screen();
            if (riScreens != null)
            {
                foreach (RichInfoScreen richinfoscreen in riScreens)
                {
                    ScreenComboBox.Items.Add(richinfoscreen.TooltipText);
                }
                ScreenComboBox.SelectedIndex = 0;
            }
        }

        void InitializeBrightness()
        {
            int brightness = -1;
            while (brightness < BrightnessSlider.Minimum || brightness > BrightnessSlider.Maximum)
            {
                try
                {
                    brightness = GetBrightness();
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }

            BrightnessSlider.Invoke((MethodInvoker)(() =>  BrightnessSlider.Value = brightness ));
            BrightnessValue.Invoke((MethodInvoker)(() => BrightnessValue.Text = brightness.ToString() ));
            BrightnessValue.Invoke((MethodInvoker)(() => BrightnessValue.ForeColor = Color.White ));
        }

        void InitializeContrast()
        {
            int contrast = -1;
            while (contrast < ContrastSlider.Minimum || contrast > ContrastSlider.Maximum)
            {
                try
                {
                    contrast = GetContrast();
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }

            ContrastSlider.Invoke((MethodInvoker)(() => ContrastSlider.Value = contrast));
            ContrastValue.Invoke((MethodInvoker)(() => ContrastValue.Text = contrast.ToString()));
            ContrastValue.Invoke((MethodInvoker)(() => ContrastValue.ForeColor = Color.White));
        }

        void SetupSlidersValues()
        {
            // Overlay - ToDo keep Overlay value in memory
            OverlaySlider.Value = Properties.Settings.Default.Brightness;
            OverlayValue.Text = OverlaySlider.Value.ToString();

            // Brightness
            BrightnessSlider.Value = BrightnessSlider.Maximum;
            BrightnessValue.ForeColor = Color.Red;
            BrightnessValue.Text = BrightnessSlider.Maximum.ToString();
            getBrightnessThread = new Thread(new ThreadStart(InitializeBrightness));
            getBrightnessThread.Start();

            //Contrast
            ContrastSlider.Value = ContrastSlider.Maximum;
            ContrastValue.ForeColor = Color.Red;
            ContrastValue.Text = ContrastSlider.Maximum.ToString();
            getContrastThread = new Thread(new ThreadStart(InitializeContrast));
            getContrastThread.Start();
        }

        private void SetLocation()
        {
            var workingArea = Screen.PrimaryScreen.WorkingArea;
            var left = workingArea.Right - Width;
            var top = workingArea.Bottom - Height;
            Location = new Point(left, top);
        }

        private void RunOnStartup(object sender, EventArgs e)
        {
            var menItm = (MenuItem)sender;
            if (!menItm.Checked)
            {
                Startup.AddToStartup();
            }
            else
            {
                Startup.RemoveFromStartup();
            }

            menItm.Checked = Startup.CheckStartup();
        }

        void ScreenComboBoxValueChanged(object sender, EventArgs e)
        {
            if(getBrightnessThread != null)
                getBrightnessThread.Abort();

            if (getContrastThread != null)
                getContrastThread.Abort();

            SetupSlidersValues();
        }

        void OverlaySliderValueChanged(object sender, EventArgs e)
        {
            OverlayValue.Text = OverlaySlider.Value.ToString();
        }

        void OverlaySliderChangeValue(object sender, EventArgs e)
        {
            var overlay = 100 - (double)OverlaySlider.Value;

            if (overlay > 95)
            {
                overlay = 95;
            }

            Overlay.Opacity = overlay / 100;
            Properties.Settings.Default["Brightness"] = OverlaySlider.Value;
            HasChanged = true;
        }

        void BrightnessSliderValueChanged(object sender, EventArgs e)
        {
            BrightnessValue.Text = BrightnessSlider.Value.ToString();
        }

        void BrightnessSliderChangeValue(object sender, EventArgs e)
        {
            int brightness = BrightnessSlider.Value;
            SetBrightness(brightness);
            Helpers.Brightness = brightness;
            BrightnessValue.Text = BrightnessSlider.Value.ToString();
        }

        int GetBrightness()
        {
            return riScreens[ScreenComboBox.SelectedIndex].GetBrightness();
        }

        void SetBrightness(int value)
        {
            if (value < BrightnessSlider.Minimum || value > BrightnessSlider.Maximum)
            {
                BrightnessValue.ForeColor = Color.Red;
                return;
            }

            riScreens[ScreenComboBox.SelectedIndex].SetBrightness((byte)value);
            BrightnessSlider.Value = value;
            BrightnessValue.ForeColor = Color.White;
            BrightnessValue.Text = BrightnessSlider.Value.ToString();
        }

        void ContrastSliderValueChanged(object sender, EventArgs e)
        {
            ContrastValue.Text = ContrastSlider.Value.ToString();
            ContrastValue.ForeColor = Color.White;
        }

        void ContrastSliderChangeValue(object sender, EventArgs e)
        {
            SetContrast(ContrastSlider.Value);
        }

        int GetContrast()
        {
            return riScreens[ScreenComboBox.SelectedIndex].GetContrast();
        }

        void SetContrast(int value)
        {
            if (value < ContrastSlider.Minimum || value > ContrastSlider.Maximum)
            {
                ContrastValue.ForeColor = Color.Red;
                return;
            }

            riScreens[ScreenComboBox.SelectedIndex].SetContrast((byte)value);
            ContrastSlider.Value = value;
            ContrastValue.ForeColor = Color.White;
            ContrastValue.Text = ContrastSlider.Value.ToString();
        }

        

        void KeysDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Visible = false;
            }
        }

        void LoseFocus(object sender, EventArgs e)
        {
            if (!ContainsFocus)
            {
                Activate();
                Visible = false;

                if (HasChanged)
                {
                    Properties.Settings.Default.Save();
                    HasChanged = false;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);
        }
 
        private void OnExit(object sender, EventArgs e)
        {
            TrayIcon.Visible = false;
            Application.Exit();
        }
    }
}
