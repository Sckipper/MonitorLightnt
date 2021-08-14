﻿/*
    The MIT License (MIT)

    Copyright (c) 2019 reblGreen Software Ltd. (https://reblgreen.com/)

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
using System.Management;
using System.Windows.Forms;

namespace MonitorLightnt
{
    public partial class Brightness : Form
    {
        NotifyIcon TrayIcon;
        ContextMenu TrayMenu;
        BasicWindow Overlay;
        Timer OntopTimer;
        bool HasChanged;
        public RichInfoScreen riScreen = new RichInfoScreen();

        public Brightness(string[] args)
        {
            InitializeComponent();

            SetupOntopTimer();

            SetupContrastOverlay();

            SetupSlidersForm();

            SetupTrayIcon();

            SetupScreens();
        }

        private void SetupOntopTimer()
        {
            OntopTimer = new Timer()
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

               /* if (BrightnessSlider != null)
                {
                    BrightnessSlider.Value = Math.Max(Helpers.Brightness, 1);
                }*/
            };

            OntopTimer.Start();
        }

        void SetupSlidersForm()
        {
            try
            {
                SetOverlayValue(Properties.Settings.Default.Brightness);
            }
            catch
            {
                OverlaySlider.Value = OverlaySlider.Maximum;
            }

            try
            {
                SetBrightness(GetBrightness());
            }
            catch (Exception)
            {
                BrightnessSlider.Value = BrightnessSlider.Maximum;
            }

            OverlaySlider.LostFocus += LoseFocus;
            BrightnessSlider.LostFocus += LoseFocus;
            LostFocus += LoseFocus;

            OverlaySlider.KeyDown += KeysDown;
            BrightnessSlider.KeyDown += KeysDown;
            KeyDown += KeysDown;

            OverlaySlider.ValueChanged += OverlaySliderValueChanged;
            BrightnessSlider.MouseUp += BrightnessSliderValueChanged;

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
            TrayMenu.MenuItems.Add("Run On Startup", RunOnStartup);
            TrayMenu.MenuItems.Add("-");
            TrayMenu.MenuItems.Add("Exit", OnExit);
            TrayMenu.MenuItems[0].Checked = Startup.CheckStartup();

            TrayIcon = new NotifyIcon();
            TrayIcon.Text = "dimwin Brightness";
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
            List<RichInfoScreen> riScreens = RichInfoScreen.Get_RichInfo_Screen();
            if (riScreen != null)
                foreach (RichInfoScreen richinfoscreen in riScreens)
                {
                    riScreen = richinfoscreen;
                    break;
                }
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

        void SetBrightness(int value)
        {
            //TODO
            value = Math.Min(Math.Max(value, BrightnessSlider.Minimum), BrightnessSlider.Maximum);
            BrightnessSlider.Value = value;
        }

        void SetOverlayValue(int value)
        {
            value = Math.Min(Math.Max(value, OverlaySlider.Minimum), OverlaySlider.Maximum);
            OverlaySlider.Value = value;
        }

        void OverlaySliderValueChanged(object sender, EventArgs e)
        {
            var overlay = 100 - (double)OverlaySlider.Value;

            if (overlay > 95)
            {
                overlay = 95;
            }

            Overlay.Opacity = overlay / 100;
            OverlayValue.Text = OverlaySlider.Value.ToString();
            Properties.Settings.Default["Brightness"] = OverlaySlider.Value;
            HasChanged = true;
        }

        void BrightnessSliderValueChanged(object sender, EventArgs e)
        {
            var brightness = BrightnessSlider.Value;
            if (brightness < 0)
            {
                brightness = 0;
            }
            byte g = 0;

            if (byte.TryParse(BrightnessSlider.Value + "", out g))
            {
                SetBrightness(g);
            }

            Helpers.Brightness = brightness;
            BrightnessValue.Text = BrightnessSlider.Value.ToString();
        }

        void SetBrightness(byte value)
        {
            //TODO
            riScreen.SetBrightness(value);
        }
        int GetBrightness()
        {
            //TODO
            return 10;

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
