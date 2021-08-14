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
using System.Windows.Forms;

namespace MonitorLightnt
{
    public class RichInfoScreen
    {
        public Screen Screen;
        public User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME? dc_TargetDeviceName;
        public DxvaMonFn.PHYSICAL_MONITOR[] PhysicalMonitors;
        public wmiMonFn.WMIMonitorID2 WMIMonitorID;
        public string TooltipText = ".";

        public DxvaMonFn.PHYSICAL_MONITOR? PhysicalMonitor
        {
            get
            {
                DxvaMonFn.PHYSICAL_MONITOR[] physicalMonitors = this.PhysicalMonitors;
                return physicalMonitors != null ? new DxvaMonFn.PHYSICAL_MONITOR?(((IEnumerable<DxvaMonFn.PHYSICAL_MONITOR>)physicalMonitors).FirstOrDefault<DxvaMonFn.PHYSICAL_MONITOR>()) : new DxvaMonFn.PHYSICAL_MONITOR?();
            }
        }

        public string TooltipTitle
        {
            get
            {
                try
                {
                    if (this.WMIMonitorID?.InstanceName != null)
                        return !string.IsNullOrWhiteSpace(this.WMIMonitorID.UserFriendlyName) ? "wmi." + this.WMIMonitorID.UserFriendlyName : "wmi." + this.WMIMonitorID.ManufacturerName + "-" + this.WMIMonitorID.ProductCodeID;
                    if (this.dc_TargetDeviceName.HasValue)
                    {
                        User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME targetDeviceName = this.dc_TargetDeviceName.Value;
                        return "user32_dc." + targetDeviceName.edidManufactureId.ToString() + "-" + targetDeviceName.edidProductCodeId.ToString();
                    }
                    DxvaMonFn.PHYSICAL_MONITOR? physicalMonitor1 = this.PhysicalMonitor;
                    ref DxvaMonFn.PHYSICAL_MONITOR? local1 = ref physicalMonitor1;
                    IntPtr? nullable1 = local1.HasValue ? new IntPtr?(local1.GetValueOrDefault().hPhysicalMonitor) : new IntPtr?();
                    IntPtr zero = IntPtr.Zero;
                    if (nullable1.HasValue && (!nullable1.HasValue || !(nullable1.GetValueOrDefault() != zero)))
                        return "noName";
                    DxvaMonFn.PHYSICAL_MONITOR? physicalMonitor2 = this.PhysicalMonitor;
                    ref DxvaMonFn.PHYSICAL_MONITOR? local2 = ref physicalMonitor2;
                    IntPtr? nullable2;
                    if (!local2.HasValue)
                    {
                        nullable1 = new IntPtr?();
                        nullable2 = nullable1;
                    }
                    else
                        nullable2 = new IntPtr?(local2.GetValueOrDefault().hPhysicalMonitor);
                    nullable1 = nullable2;
                    return "dxva-ddci." + nullable1.ToString();
                }
                catch (Exception ex)
                {
                    return "Ex:" + ex?.ToString();
                }
            }
            set => this.TooltipTitle = value;
        }

        public int SetBrightness(byte value)
        {
            bool flag = false;
            if (this.WMIMonitorID != null)
                flag = wmiMonFn.SetBrightness(value, this.WMIMonitorID.InstanceName);
            DxvaMonFn.PHYSICAL_MONITOR? physicalMonitor;
            int num2;
            if (!flag)
            {
                physicalMonitor = this.PhysicalMonitor;
                ref DxvaMonFn.PHYSICAL_MONITOR? local = ref physicalMonitor;
                IntPtr? nullable = local.HasValue ? new IntPtr?(local.GetValueOrDefault().hPhysicalMonitor) : new IntPtr?();
                IntPtr zero = IntPtr.Zero;
                num2 = nullable.HasValue ? (nullable.HasValue ? (nullable.GetValueOrDefault() != zero ? 1 : 0) : 0) : 1;
            }
            else
                num2 = 0;
            if (num2 != 0)
            {
                physicalMonitor = this.PhysicalMonitor;
                if (DxvaMonFn.SetPhysicalMonitorBrightness(physicalMonitor.Value, (double)value))
                {
                    physicalMonitor = this.PhysicalMonitor;
                    DxvaMonFn.SaveCurrentMonitorSettings(physicalMonitor.Value);
                }
            }
            RicInfoScreenHolder.RememberBrightness(this, value);
            return value;
        }

        public int GetBrightness()
        {
            int num1 = -1;
            if (this.WMIMonitorID?.InstanceName != null)
                num1 = wmiMonFn.GetBrightness(this.WMIMonitorID.InstanceName);
            DxvaMonFn.PHYSICAL_MONITOR? physicalMonitor = this.PhysicalMonitor;
            ref DxvaMonFn.PHYSICAL_MONITOR? local = ref physicalMonitor;
            int num2;
            if (!local.HasValue)
            {
                num2 = 0;
            }
            else
            {
                local.GetValueOrDefault();
                num2 = 1;
            }
            if (num2 != 0 && num1 == -1)
            {
                physicalMonitor = this.PhysicalMonitor;
                num1 = DxvaMonFn.GetPhysicalMonitorBrightness(physicalMonitor.Value);
            }
            return num1;
        }

        public int GetContrast()
        {
            return 100;
        }

        public int SetContrast()
        {
            return 0;
        }

        public static List<RichInfoScreen> Get_RichInfo_Screen()
        {
            List<RichInfoScreen> richInfoScreenList = new List<RichInfoScreen>();
            List<wmiMonFn.WMIMonitorID2> wmiMonitorId2List = new List<wmiMonFn.WMIMonitorID2>();
            try
            {
                wmiMonitorId2List = wmiMonFn.GetWMIMonitorIDs();
            }
            catch (Exception ex) //TODO
            {

            }
            foreach (Screen allScreen in Screen.AllScreens)
            {
                DxvaMonFn.PHYSICAL_MONITOR[] physicalMonitorArray = new DxvaMonFn.PHYSICAL_MONITOR[0];
                try
                {
                    physicalMonitorArray = DxvaMonFn.GetPhysicalMonitors(allScreen);
                }
                catch (Exception ex) //TODO
                {

                }
                wmiMonFn.WMIMonitorID2 wmiMonitorId2 = (wmiMonFn.WMIMonitorID2)null;
                User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME? nullable = allScreen.dc_TargetDeviceName();
                if (nullable.HasValue)
                {
                    wmiMonitorId2 = RichInfoScreen.GetWmiMonitorID_by_TargetDeviceName(wmiMonitorId2List, nullable.Value);
                    wmiMonitorId2List.Remove(wmiMonitorId2);
                }
                richInfoScreenList.Add(new RichInfoScreen()
                {
                    Screen = allScreen,
                    dc_TargetDeviceName = nullable,
                    PhysicalMonitors = physicalMonitorArray,
                    WMIMonitorID = wmiMonitorId2
                });
            }
            if (wmiMonitorId2List.Count<wmiMonFn.WMIMonitorID2>() > 0)
            {
                List<RichInfoScreen> list = wmiMonitorId2List.Select<wmiMonFn.WMIMonitorID2, RichInfoScreen>((Func<wmiMonFn.WMIMonitorID2, RichInfoScreen>)(remWmi => new RichInfoScreen()
                {
                    WMIMonitorID = remWmi
                })).ToList<RichInfoScreen>();
                richInfoScreenList.InsertRange(0, (IEnumerable<RichInfoScreen>)list);
            }
            return richInfoScreenList;
        }

        private static wmiMonFn.WMIMonitorID2 GetWmiMonitorID_by_TargetDeviceName(
          List<wmiMonFn.WMIMonitorID2> WMIMonitorIDs,
          User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME dc_tarDevName)
        {
            string dc_tarDevName_monDevPath_asInstace = "none";
            int startIndex = dc_tarDevName.monitorDevicePath.IndexOf("DISPLAY");
            int num = dc_tarDevName.monitorDevicePath.IndexOf("#{");
            if (startIndex < 0)
                return (wmiMonFn.WMIMonitorID2)null;
            dc_tarDevName_monDevPath_asInstace = dc_tarDevName.monitorDevicePath.Substring(startIndex, num - startIndex).Replace("#", "\\");
            return WMIMonitorIDs.FirstOrDefault<wmiMonFn.WMIMonitorID2>((Func<wmiMonFn.WMIMonitorID2, bool>)(x => x.InstanceName.StartsWith(dc_tarDevName_monDevPath_asInstace)));
        }

        public static List<RichInfoScreen> GetMonitors()
        {
            List<RichInfoScreen> richInfoScreenList = new List<RichInfoScreen>();
            DxvaMonFn.PHYSICAL_MONITOR[] physicalMonitorArray = new DxvaMonFn.PHYSICAL_MONITOR[0];
            List<wmiMonFn.WMIMonitorID2> source = new List<wmiMonFn.WMIMonitorID2>();
            bool flag1 = false;
            bool flag2 = false;
            try
            {
                source = wmiMonFn.GetWMIMonitorIDs();
            }
            catch (Exception ex)
            {
                flag1 = true;
            }
            try
            {
                physicalMonitorArray = DxvaMonFn.GetPhysicalMonitors_All_Flattened();
            }
            catch (Exception ex)
            {
                flag2 = true;
            }
            if (source.Count<wmiMonFn.WMIMonitorID2>() == physicalMonitorArray.Length && source.Count<wmiMonFn.WMIMonitorID2>() > 0)
            {
                for (int index = 0; index < physicalMonitorArray.Length; ++index)
                    richInfoScreenList.Add(new RichInfoScreen()
                    {
                        WMIMonitorID = source[index],
                        PhysicalMonitors = new DxvaMonFn.PHYSICAL_MONITOR[1]
                      {
              physicalMonitorArray[index]
                      },
                        TooltipText = source[index].InstanceName,
                        TooltipTitle = "WMI, Fallback to dxva2"
                    });
            }
            else
            {
                if (!flag1)
                {
                    foreach (wmiMonFn.WMIMonitorID2 wmiMonitorId2 in source)
                        richInfoScreenList.Add(new RichInfoScreen()
                        {
                            WMIMonitorID = wmiMonitorId2,
                            TooltipText = wmiMonitorId2.InstanceName,
                            TooltipTitle = "WMI"
                        });
                }
                if (!flag2)
                {
                    for (int index = 0; index < physicalMonitorArray.Length; ++index)
                        richInfoScreenList.Add(new RichInfoScreen()
                        {
                            PhysicalMonitors = new DxvaMonFn.PHYSICAL_MONITOR[1]
                          {
                physicalMonitorArray[index]
                          },
                            TooltipText = physicalMonitorArray[index].hPhysicalMonitor.ToString() + "  " + physicalMonitorArray[index].szPhysicalMonitorDescription,
                            TooltipTitle = "dxva2"
                        });
                }
            }
            return flag2 & flag1 ? (List<RichInfoScreen>)null : richInfoScreenList;
        }
    }
}
