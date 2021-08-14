/* 
    The Commons Clause source-available License  (https://commonsclause.com/)
 
    All Rights Reserved.  blackholeearth (https://github.com/blackholeearth)
    Intellectual Property.

    you are Free To Download And use On your Pc
    you are Free To View Code and See How its Done.

    You Cant Sell This. 
 */

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
