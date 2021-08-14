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
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MonitorLightnt
{
  public static class User32_MonFn
  {
    public const int ERROR_SUCCESS = 0;

    [DllImport("user32.dll")]
    public static extern int GetDisplayConfigBufferSizes(
      User32_MonFn.QUERY_DEVICE_CONFIG_FLAGS flags,
      out uint numPathArrayElements,
      out uint numModeInfoArrayElements);

    [DllImport("user32.dll")]
    public static extern int QueryDisplayConfig(
      User32_MonFn.QUERY_DEVICE_CONFIG_FLAGS flags,
      ref uint numPathArrayElements,
      [Out] User32_MonFn.DISPLAYCONFIG_PATH_INFO[] PathInfoArray,
      ref uint numModeInfoArrayElements,
      [Out] User32_MonFn.DISPLAYCONFIG_MODE_INFO[] ModeInfoArray,
      IntPtr currentTopologyId);

    [DllImport("user32.dll")]
    public static extern int DisplayConfigGetDeviceInfo(
      ref User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME deviceName);

    private static User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME MonitorFriendlyName(
      User32_MonFn.LUID adapterId,
      uint targetId)
    {
      User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME deviceName = new User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME()
      {
        header = {
          size = (uint) Marshal.SizeOf(typeof (User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME)),
          adapterId = adapterId,
          id = targetId,
          type = User32_MonFn.DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME
        }
      };
      int deviceInfo = User32_MonFn.DisplayConfigGetDeviceInfo(ref deviceName);
      if ((uint) deviceInfo > 0U)
        throw new Win32Exception(deviceInfo);
      return deviceName;
    }

    private static IEnumerable<User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME> GetAllMonitorsFriendlyNames()
    {
      uint pathCount;
      uint modeCount;
      int error = User32_MonFn.GetDisplayConfigBufferSizes(User32_MonFn.QUERY_DEVICE_CONFIG_FLAGS.QDC_ONLY_ACTIVE_PATHS, out pathCount, out modeCount);
      if ((uint) error > 0U)
        throw new Win32Exception(error);
      User32_MonFn.DISPLAYCONFIG_PATH_INFO[] displayPaths = new User32_MonFn.DISPLAYCONFIG_PATH_INFO[(int) pathCount];
      User32_MonFn.DISPLAYCONFIG_MODE_INFO[] displayModes = new User32_MonFn.DISPLAYCONFIG_MODE_INFO[(int) modeCount];
      error = User32_MonFn.QueryDisplayConfig(User32_MonFn.QUERY_DEVICE_CONFIG_FLAGS.QDC_ONLY_ACTIVE_PATHS, ref pathCount, displayPaths, ref modeCount, displayModes, IntPtr.Zero);
      if ((uint) error > 0U)
        throw new Win32Exception(error);
      for (int i = 0; (long) i < (long) modeCount; ++i)
      {
        if (displayModes[i].infoType == User32_MonFn.DISPLAYCONFIG_MODE_INFO_TYPE.DISPLAYCONFIG_MODE_INFO_TYPE_TARGET)
          yield return User32_MonFn.MonitorFriendlyName(displayModes[i].adapterId, displayModes[i].id);
      }
    }

    public static User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME? dc_TargetDeviceName(
      this Screen screen)
    {
      IEnumerable<User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME> monitorsFriendlyNames = User32_MonFn.GetAllMonitorsFriendlyNames();
      for (int index = 0; index < Screen.AllScreens.Length; ++index)
      {
        if (object.Equals((object) screen, (object) Screen.AllScreens[index]))
          return new User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME?(monitorsFriendlyNames.ToArray<User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME>()[index]);
      }
      return new User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME?();
    }

    public enum QUERY_DEVICE_CONFIG_FLAGS : uint
    {
      QDC_ALL_PATHS = 1,
      QDC_ONLY_ACTIVE_PATHS = 2,
      QDC_DATABASE_CURRENT = 4,
    }

    public enum DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY : uint
    {
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HD15 = 0,
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SVIDEO = 1,
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPOSITE_VIDEO = 2,
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPONENT_VIDEO = 3,
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DVI = 4,
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HDMI = 5,
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_LVDS = 6,
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_D_JPN = 8,
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDI = 9,
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EXTERNAL = 10, // 0x0000000A
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EMBEDDED = 11, // 0x0000000B
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EXTERNAL = 12, // 0x0000000C
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EMBEDDED = 13, // 0x0000000D
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDTVDONGLE = 14, // 0x0000000E
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_MIRACAST = 15, // 0x0000000F
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL = 2147483648, // 0x80000000
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_FORCE_UINT32 = 4294967295, // 0xFFFFFFFF
      DISPLAYCONFIG_OUTPUT_TECHNOLOGY_OTHER = 4294967295, // 0xFFFFFFFF
    }

    public enum DISPLAYCONFIG_SCANLINE_ORDERING : uint
    {
      DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED = 0,
      DISPLAYCONFIG_SCANLINE_ORDERING_PROGRESSIVE = 1,
      DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED = 2,
      DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_UPPERFIELDFIRST = 2,
      DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_LOWERFIELDFIRST = 3,
      DISPLAYCONFIG_SCANLINE_ORDERING_FORCE_UINT32 = 4294967295, // 0xFFFFFFFF
    }

    public enum DISPLAYCONFIG_ROTATION : uint
    {
      DISPLAYCONFIG_ROTATION_IDENTITY = 1,
      DISPLAYCONFIG_ROTATION_ROTATE90 = 2,
      DISPLAYCONFIG_ROTATION_ROTATE180 = 3,
      DISPLAYCONFIG_ROTATION_ROTATE270 = 4,
      DISPLAYCONFIG_ROTATION_FORCE_UINT32 = 4294967295, // 0xFFFFFFFF
    }

    public enum DISPLAYCONFIG_SCALING : uint
    {
      DISPLAYCONFIG_SCALING_IDENTITY = 1,
      DISPLAYCONFIG_SCALING_CENTERED = 2,
      DISPLAYCONFIG_SCALING_STRETCHED = 3,
      DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX = 4,
      DISPLAYCONFIG_SCALING_CUSTOM = 5,
      DISPLAYCONFIG_SCALING_PREFERRED = 128, // 0x00000080
      DISPLAYCONFIG_SCALING_FORCE_UINT32 = 4294967295, // 0xFFFFFFFF
    }

    public enum DISPLAYCONFIG_PIXELFORMAT : uint
    {
      DISPLAYCONFIG_PIXELFORMAT_8BPP = 1,
      DISPLAYCONFIG_PIXELFORMAT_16BPP = 2,
      DISPLAYCONFIG_PIXELFORMAT_24BPP = 3,
      DISPLAYCONFIG_PIXELFORMAT_32BPP = 4,
      DISPLAYCONFIG_PIXELFORMAT_NONGDI = 5,
      DISPLAYCONFIG_PIXELFORMAT_FORCE_UINT32 = 4294967295, // 0xFFFFFFFF
    }

    public enum DISPLAYCONFIG_MODE_INFO_TYPE : uint
    {
      DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE = 1,
      DISPLAYCONFIG_MODE_INFO_TYPE_TARGET = 2,
      DISPLAYCONFIG_MODE_INFO_TYPE_FORCE_UINT32 = 4294967295, // 0xFFFFFFFF
    }

    public enum DISPLAYCONFIG_DEVICE_INFO_TYPE : uint
    {
      DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME = 1,
      DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME = 2,
      DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_PREFERRED_MODE = 3,
      DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME = 4,
      DISPLAYCONFIG_DEVICE_INFO_SET_TARGET_PERSISTENCE = 5,
      DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_BASE_TYPE = 6,
      DISPLAYCONFIG_DEVICE_INFO_FORCE_UINT32 = 4294967295, // 0xFFFFFFFF
    }

    public struct LUID
    {
      public uint LowPart;
      public int HighPart;
    }

    public struct DISPLAYCONFIG_PATH_SOURCE_INFO
    {
      public User32_MonFn.LUID adapterId;
      public uint id;
      public uint modeInfoIdx;
      public uint statusFlags;
    }

    public struct DISPLAYCONFIG_PATH_TARGET_INFO
    {
      public User32_MonFn.LUID adapterId;
      public uint id;
      public uint modeInfoIdx;
      private User32_MonFn.DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;
      private User32_MonFn.DISPLAYCONFIG_ROTATION rotation;
      private User32_MonFn.DISPLAYCONFIG_SCALING scaling;
      private User32_MonFn.DISPLAYCONFIG_RATIONAL refreshRate;
      private User32_MonFn.DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
      public bool targetAvailable;
      public uint statusFlags;
    }

    public struct DISPLAYCONFIG_RATIONAL
    {
      public uint Numerator;
      public uint Denominator;
    }

    public struct DISPLAYCONFIG_PATH_INFO
    {
      public User32_MonFn.DISPLAYCONFIG_PATH_SOURCE_INFO sourceInfo;
      public User32_MonFn.DISPLAYCONFIG_PATH_TARGET_INFO targetInfo;
      public uint flags;
    }

    public struct DISPLAYCONFIG_2DREGION
    {
      public uint cx;
      public uint cy;
    }

    public struct DISPLAYCONFIG_VIDEO_SIGNAL_INFO
    {
      public ulong pixelRate;
      public User32_MonFn.DISPLAYCONFIG_RATIONAL hSyncFreq;
      public User32_MonFn.DISPLAYCONFIG_RATIONAL vSyncFreq;
      public User32_MonFn.DISPLAYCONFIG_2DREGION activeSize;
      public User32_MonFn.DISPLAYCONFIG_2DREGION totalSize;
      public uint videoStandard;
      public User32_MonFn.DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
    }

    public struct DISPLAYCONFIG_TARGET_MODE
    {
      public User32_MonFn.DISPLAYCONFIG_VIDEO_SIGNAL_INFO targetVideoSignalInfo;
    }

    public struct POINTL
    {
      private int x;
      private int y;
    }

    public struct DISPLAYCONFIG_SOURCE_MODE
    {
      public uint width;
      public uint height;
      public User32_MonFn.DISPLAYCONFIG_PIXELFORMAT pixelFormat;
      public User32_MonFn.POINTL position;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct DISPLAYCONFIG_MODE_INFO_UNION
    {
      [FieldOffset(0)]
      public User32_MonFn.DISPLAYCONFIG_TARGET_MODE targetMode;
      [FieldOffset(0)]
      public User32_MonFn.DISPLAYCONFIG_SOURCE_MODE sourceMode;
    }

    public struct DISPLAYCONFIG_MODE_INFO
    {
      public User32_MonFn.DISPLAYCONFIG_MODE_INFO_TYPE infoType;
      public uint id;
      public User32_MonFn.LUID adapterId;
      public User32_MonFn.DISPLAYCONFIG_MODE_INFO_UNION modeInfo;
    }

    public struct DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS
    {
      public uint value;
    }

    public struct DISPLAYCONFIG_DEVICE_INFO_HEADER
    {
      public User32_MonFn.DISPLAYCONFIG_DEVICE_INFO_TYPE type;
      public uint size;
      public User32_MonFn.LUID adapterId;
      public uint id;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_TARGET_DEVICE_NAME
    {
      public User32_MonFn.DISPLAYCONFIG_DEVICE_INFO_HEADER header;
      public User32_MonFn.DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS flags;
      public User32_MonFn.DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;
      public ushort edidManufactureId;
      public ushort edidProductCodeId;
      public uint connectorInstance;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
      public string monitorFriendlyDeviceName;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
      public string monitorDevicePath;
    }
  }
}
