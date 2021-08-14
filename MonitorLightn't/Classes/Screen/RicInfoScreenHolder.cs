/*
    The MIT License (MIT)

    Copyright (c) 2021 Sckipper (https://github.com/Sckipper)

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
using System.Linq;

namespace MonitorLightnt
{
    public static class RicInfoScreenHolder
    {
        public static List<MonitorInfo> BriInfoLi = new List<MonitorInfo>();

        public static void RememberBrightness(RichInfoScreen ris, int briValue)
        {
            MonitorInfo brightnessInfo;
            try
            {
                brightnessInfo = RicInfoScreenHolder.BriInfoLi.FirstOrDefault<MonitorInfo>((Func<MonitorInfo, bool>)(x =>
                                 {
                                     string user32dcDevicePath = x.user32dc_DevicePath;
                                     ref User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME? local = ref ris.dc_TargetDeviceName;
                                     string str = local.HasValue ? local.GetValueOrDefault().monitorDevicePath : (string)null;
                                     return user32dcDevicePath == str;
                                 }));
                if (brightnessInfo != null)
                {
                    brightnessInfo.Brightness = briValue;
                }
                else
                {
                    brightnessInfo = RicInfoScreenHolder.BriInfoLi.FirstOrDefault<MonitorInfo>((Func<MonitorInfo, bool>)(x => x.wmi_InstanceName == ris.WMIMonitorID.InstanceName));
                    if (brightnessInfo != null)
                    {
                        brightnessInfo.Brightness = briValue;
                    }
                    else
                    {
                        List<MonitorInfo> briInfoLi = RicInfoScreenHolder.BriInfoLi;
                        brightnessInfo = new MonitorInfo();
                        brightnessInfo.Brightness = briValue;
                        ref User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME? local = ref ris.dc_TargetDeviceName;
                        brightnessInfo.user32dc_DevicePath = local.HasValue ? local.GetValueOrDefault().monitorDevicePath : (string)null;
                        brightnessInfo.wmi_InstanceName = ris.WMIMonitorID.InstanceName;
                        briInfoLi.Add(brightnessInfo);
                    }
                }
            }
            catch (Exception ex) // ToDO
            {
            }
        }

        public static void RememberContrast(RichInfoScreen ris, int briValue)
        {
            MonitorInfo contrastInfo;

            try
            {
                contrastInfo = RicInfoScreenHolder.BriInfoLi.FirstOrDefault<MonitorInfo>((Func<MonitorInfo, bool>)(x =>
                                {
                                    string user32dcDevicePath = x.user32dc_DevicePath;
                                    ref User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME? local = ref ris.dc_TargetDeviceName;
                                    string str = local.HasValue ? local.GetValueOrDefault().monitorDevicePath : (string)null;
                                    return user32dcDevicePath == str;
                                }));
                if (contrastInfo != null)
                {
                    contrastInfo.Contrast = briValue;
                }
                else
                {
                    contrastInfo = RicInfoScreenHolder.BriInfoLi.FirstOrDefault<MonitorInfo>((Func<MonitorInfo, bool>)(x => x.wmi_InstanceName == ris.WMIMonitorID.InstanceName));
                    if (contrastInfo != null)
                    {
                        contrastInfo.Contrast = briValue;
                    }
                    else
                    {
                        List<MonitorInfo> briInfoLi = RicInfoScreenHolder.BriInfoLi;
                        contrastInfo = new MonitorInfo();
                        contrastInfo.Contrast = briValue;
                        ref User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME? local = ref ris.dc_TargetDeviceName;
                        contrastInfo.user32dc_DevicePath = local.HasValue ? local.GetValueOrDefault().monitorDevicePath : (string)null;
                        contrastInfo.wmi_InstanceName = ris.WMIMonitorID.InstanceName;
                        briInfoLi.Add(contrastInfo);
                    }
                }
            }
            catch (Exception ex) // ToDO
            {
            }
        }
    }
}
