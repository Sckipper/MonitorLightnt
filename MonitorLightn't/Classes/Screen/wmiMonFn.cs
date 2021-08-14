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
