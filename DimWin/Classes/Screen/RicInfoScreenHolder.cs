// Decompiled with JetBrains decompiler
// Type: Win10_BrightnessSlider.RicInfoScreenHolder
// Assembly: Win10_BrightnessSlider, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 271A8139-F024-4787-8802-FC5911CE41C9
// Assembly location: C:\Users\Sckipper\Downloads\Win10_BrightnessSlider(1).exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace MonitorLightnt
{
  public static class RicInfoScreenHolder
  {
    public static List<BrightnessInfo> BriInfoLi = new List<BrightnessInfo>();

    public static void RememberBrightness(RichInfoScreen ris, int briValue)
    {
      try
      {
        BrightnessInfo brightnessInfo1 = RicInfoScreenHolder.BriInfoLi.FirstOrDefault<BrightnessInfo>((Func<BrightnessInfo, bool>) (x =>
        {
          string user32dcDevicePath = x.user32dc_DevicePath;
          ref User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME? local = ref ris.dc_TargetDeviceName;
          string str = local.HasValue ? local.GetValueOrDefault().monitorDevicePath : (string) null;
          return user32dcDevicePath == str;
        }));
        if (brightnessInfo1 != null)
        {
          brightnessInfo1.Brightness = briValue;
        }
        else
        {
          BrightnessInfo brightnessInfo2 = RicInfoScreenHolder.BriInfoLi.FirstOrDefault<BrightnessInfo>((Func<BrightnessInfo, bool>) (x => x.wmi_InstanceName == ris.WMIMonitorID.InstanceName));
          if (brightnessInfo2 != null)
          {
            brightnessInfo2.Brightness = briValue;
          }
          else
          {
            List<BrightnessInfo> briInfoLi = RicInfoScreenHolder.BriInfoLi;
            BrightnessInfo brightnessInfo3 = new BrightnessInfo();
            brightnessInfo3.Brightness = briValue;
            ref User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME? local = ref ris.dc_TargetDeviceName;
            brightnessInfo3.user32dc_DevicePath = local.HasValue ? local.GetValueOrDefault().monitorDevicePath : (string) null;
            brightnessInfo3.wmi_InstanceName = ris.WMIMonitorID.InstanceName;
            briInfoLi.Add(brightnessInfo3);
          }
        }
      }
      catch (Exception ex) // ToDO
      {
      }
    }
  }
}
