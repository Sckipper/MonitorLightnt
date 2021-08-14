// Decompiled with JetBrains decompiler
// Type: Win10_BrightnessSlider.wmiMonFn
// Assembly: Win10_BrightnessSlider, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 271A8139-F024-4787-8802-FC5911CE41C9
// Assembly location: C:\Users\Sckipper\Downloads\Win10_BrightnessSlider(1).exe

using System;
using System.Collections.Generic;
using System.Management;

namespace MonitorLightnt
{
  public static class wmiMonFn
  {
    public static bool SetBrightness(byte value, string wmi_InstanceName)
    {
      bool flag = false;
      try
      {
        using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(new ManagementScope("root\\WMI"), (ObjectQuery) new SelectQuery("WmiMonitorBrightnessMethods")))
        {
          using (ManagementObjectCollection objectCollection = managementObjectSearcher.Get())
          {
            foreach (ManagementObject managementObject in objectCollection)
            {
              string str = managementObject.Properties["InstanceName"].Value?.ToString() ?? "";
              if (wmi_InstanceName == str)
              {
                managementObject.InvokeMethod("WmiSetBrightness", new object[2]
                {
                  (object) uint.MaxValue,
                  (object) value
                });
                flag = true;
                break;
              }
            }
          }
        }
        return flag;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public static int GetBrightness(string wmi_InstanceName)
    {
      try
      {
        using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(new ManagementScope("root\\WMI"), (ObjectQuery) new SelectQuery("WmiMonitorBrightness")))
        {
          using (ManagementObjectCollection objectCollection = managementObjectSearcher.Get())
          {
            foreach (ManagementObject managementObject in objectCollection)
            {
              string str = managementObject.Properties["InstanceName"].Value?.ToString() ?? "";
              if (wmi_InstanceName == str)
                return (int) Convert.ToDouble(managementObject.Properties["CurrentBrightness"].Value);
            }
          }
        }
        return -1;
      }
      catch (Exception ex)
      {
        return -1;
      }
    }

    public static string ToCharArray(ushort[] arr)
    {
      if (arr == null)
        return "";
      char[] chArray = new char[arr.Length];
      for (int index = 0; index < arr.Length; ++index)
        chArray[index] = (char) arr[index];
      return new string(chArray).TrimEnd(new char[1]);
    }

    public static List<wmiMonFn.WMIMonitorID2> GetWMIMonitorIDs()
    {
      List<wmiMonFn.WMIMonitorID2> wmiMonitorId2List = new List<wmiMonFn.WMIMonitorID2>();
      using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(new ManagementScope("root\\WMI"), (ObjectQuery) new SelectQuery("WMIMonitorID")))
      {
        using (ManagementObjectCollection objectCollection = managementObjectSearcher.Get())
        {
          foreach (ManagementObject managementObject in objectCollection)
            wmiMonitorId2List.Add(new wmiMonFn.WMIMonitorID2()
            {
              InstanceName = managementObject.Properties["InstanceName"].Value?.ToString() ?? "",
              ManufacturerName = wmiMonFn.ToCharArray((ushort[]) managementObject.Properties["ManufacturerName"].Value),
              ProductCodeID = wmiMonFn.ToCharArray((ushort[]) managementObject.Properties["ProductCodeID"].Value),
              SerialNumberID = wmiMonFn.ToCharArray((ushort[]) managementObject.Properties["SerialNumberID"].Value),
              UserFriendlyName = wmiMonFn.ToCharArray((ushort[]) managementObject.Properties["UserFriendlyName"].Value),
              YearOfManufacture = managementObject.Properties["YearOfManufacture"].Value?.ToString() ?? ""
            });
        }
      }
      return wmiMonitorId2List;
    }

    public class WMIMonitorID2
    {
      public string InstanceName;
      public string ManufacturerName;
      public string ProductCodeID;
      public string SerialNumberID;
      public string UserFriendlyName;
      public string YearOfManufacture;
    }
  }
}
