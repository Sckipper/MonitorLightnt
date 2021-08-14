// Decompiled with JetBrains decompiler
// Type: Win10_BrightnessSlider.DxvaMonFn
// Assembly: Win10_BrightnessSlider, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 271A8139-F024-4787-8802-FC5911CE41C9
// Assembly location: C:\Users\Sckipper\Downloads\Win10_BrightnessSlider(1).exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MonitorLightnt
{
  public static class DxvaMonFn
  {
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr MonitorFromPoint(Point pt, DxvaMonFn.MonitorOptions dwFlags);

    [DllImport("dxva2.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetPhysicalMonitorsFromHMONITOR(
      IntPtr hMonitor,
      uint dwPhysicalMonitorArraySize,
      [Out] DxvaMonFn.PHYSICAL_MONITOR[] pPhysicalMonitorArray);

    [DllImport("dxva2.dll", SetLastError = true)]
    public static extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(
      IntPtr hMonitor,
      ref uint pdwNumberOfPhysicalMonitors);

    [DllImport("dxva2.dll", SetLastError = true)]
    public static extern bool DestroyPhysicalMonitors(
      uint dwPhysicalMonitorArraySize,
      DxvaMonFn.PHYSICAL_MONITOR[] pPhysicalMonitorArray);

    [DllImport("dxva2.dll", SetLastError = true)]
    public static extern bool GetMonitorCapabilities(
      IntPtr hMonitor,
      ref uint pdwMonitorCapabilities,
      ref uint pdwSupportedColorTemperatures);

    [DllImport("dxva2.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetMonitorBrightness(
      IntPtr handle,
      out uint minBrightness,
      out uint currentBrightness,
      out uint maxBrightness);

    [DllImport("dxva2.dll", SetLastError = true)]
    public static extern bool SetMonitorBrightness(IntPtr hMonitor, uint dwNewBrightness);

    [DllImport("dxva2.dll", SetLastError = true)]
    public static extern bool GetMonitorContrast(
      IntPtr hMonitor,
      ref uint pdwMinContrast,
      ref uint pdwCurrentContrast,
      ref uint pdwMaxContrast);

    [DllImport("dxva2.dll", SetLastError = true)]
    public static extern bool SetMonitorContrast(IntPtr hMonitor, uint dwNewContrast);

    [DllImport("dxva2.dll", SetLastError = true)]
    public static extern bool SaveCurrentMonitorSettings(IntPtr hMonitor);

    public static DxvaMonFn.PHYSICAL_MONITOR[] GetPhysicalMonitors_All_Flattened()
    {
      List<DxvaMonFn.PHYSICAL_MONITOR> physicalMonitorList = new List<DxvaMonFn.PHYSICAL_MONITOR>();
      foreach (Screen allScreen in Screen.AllScreens)
        physicalMonitorList.AddRange((IEnumerable<DxvaMonFn.PHYSICAL_MONITOR>) DxvaMonFn.GetPhysicalMonitors(allScreen));
      return physicalMonitorList.ToArray();
    }

    public static DxvaMonFn.PHYSICAL_MONITOR[] GetPhysicalMonitors(Screen screen)
    {
      IntPtr hMonitor = DxvaMonFn.MonitorFromPoint(screen.Bounds.Location, DxvaMonFn.MonitorOptions.MONITOR_DEFAULTTONEAREST);
      uint pdwNumberOfPhysicalMonitors = 0;
      DxvaMonFn.GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, ref pdwNumberOfPhysicalMonitors);
      DxvaMonFn.PHYSICAL_MONITOR[] pPhysicalMonitorArray = new DxvaMonFn.PHYSICAL_MONITOR[(int) pdwNumberOfPhysicalMonitors];
      DxvaMonFn.GetPhysicalMonitorsFromHMONITOR(hMonitor, pdwNumberOfPhysicalMonitors, pPhysicalMonitorArray);
      return pPhysicalMonitorArray;
    }

    public static bool DestroyAllPhysicalMonitors(DxvaMonFn.PHYSICAL_MONITOR[] PhysicalMonitors) => DxvaMonFn.DestroyPhysicalMonitors(Convert.ToUInt32(PhysicalMonitors.Length), PhysicalMonitors);

    private static uint GetPhysicalMonitorCapabilities(DxvaMonFn.PHYSICAL_MONITOR physicalMonitor)
    {
      uint pdwMonitorCapabilities = 0;
      uint pdwSupportedColorTemperatures = 0;
      DxvaMonFn.GetMonitorCapabilities(physicalMonitor.hPhysicalMonitor, ref pdwMonitorCapabilities, ref pdwSupportedColorTemperatures);
      return pdwMonitorCapabilities;
    }

    public static int GetPhysicalMonitorBrightness(DxvaMonFn.PHYSICAL_MONITOR physicalMonitor)
    {
      uint minBrightness = 0;
      uint currentBrightness = 0;
      uint maxBrightness = 0;
      if (DxvaMonFn.GetMonitorBrightness(physicalMonitor.hPhysicalMonitor, out minBrightness, out currentBrightness, out maxBrightness))
        return (int) ((double) (currentBrightness - minBrightness) / (double) (maxBrightness - minBrightness) * 100.0);
      return -1;
    }

    public static bool SetPhysicalMonitorBrightness(
      DxvaMonFn.PHYSICAL_MONITOR physicalMonitor,
      double brightness)
    {
      bool flag = DxvaMonFn.SetMonitorBrightness(physicalMonitor.hPhysicalMonitor, Convert.ToUInt32(brightness));
      Thread.Sleep(60);
      uint minBrightness = 0;
      uint currentBrightness = 0;
      uint maxBrightness = 0;
      if (!DxvaMonFn.GetMonitorBrightness(physicalMonitor.hPhysicalMonitor, out minBrightness, out currentBrightness, out maxBrightness))
      {
        return false;
      }
      double num = (double) minBrightness + (double) (maxBrightness - minBrightness) * (brightness / 100.0);
      if (DxvaMonFn.SetMonitorBrightness(physicalMonitor.hPhysicalMonitor, Convert.ToUInt32(num)))
        return true;
      return false;
    }

    public static bool SaveCurrentMonitorSettings(DxvaMonFn.PHYSICAL_MONITOR physicalMonitor)
    {
      if (DxvaMonFn.SaveCurrentMonitorSettings(physicalMonitor.hPhysicalMonitor))
        return true;
      return false;
    }

    public enum MonitorOptions : uint
    {
      MONITOR_DEFAULTTONULL,
      MONITOR_DEFAULTTOPRIMARY,
      MONITOR_DEFAULTTONEAREST,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PHYSICAL_MONITOR
    {
      public IntPtr hPhysicalMonitor;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
      public string szPhysicalMonitorDescription;
    }
  }
}
