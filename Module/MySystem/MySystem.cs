using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Management.Automation;

namespace CsharpLazycode.Module.MySystem
{
    public class Util
    {
        #region DLL
        [DllImport("kernel32")]
        public static extern void GetWindowsDirectory(StringBuilder WinDir, int count);
        [DllImport("kernel32")]
        public static extern void GetSystemDirectory(StringBuilder SysDir, int count);
        [DllImport("kernel32")]
        private static extern void GlobalMemoryStatus(ref StorageInfo memibfo);
        [DllImport("kernel32")]
        public static extern void GetSystemInfo(ref CPUInfo cpuinfo);
        [DllImport("kernel32")]
        public static extern void GetSystemTime(ref SystemTimeInfo stinfo);
        [DllImport("Iphlpapi.dll")]
        public static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 MacAddr, ref Int32 PhyAddrLen);
        [DllImport("Ws2_32.dll")]
        public static extern Int32 Inet_addr(string ipaddr);
        //内存信息结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct StorageInfo //此处全是以字节为单位
        {
            public uint dwLength;//长度
            public uint dwMemoryLoad;//内存使用率
            public uint dwTotalPhys;//总物理内存
            public uint dwAvailPhys;//可用物理内存
            public uint dwTotalPageFile;//交换文件总大小
            public uint dwAvailPageFile;//可用交换文件大小
            public uint dwTotalVirtual;//总虚拟内存
            public uint dwAvailVirtual;//可用虚拟内存大小
        }
        //cpu信息结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct CPUInfo
        {
            public uint cpu的OemId;
            public uint cpu页面大小;
            public uint lpMinimumApplicationAddress;
            public uint lpMaximumApplicationAddress;
            public uint dwActiveProcessorMask;
            public uint cpu个数;
            public uint cpu类别;
            public uint dwAllocationGranularity;
            public uint cpu等级;
            public uint cpu修正;
        }
        //系统时间信息结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTimeInfo
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }
        #endregion
        public static bool Debug()
        {
            System.Console.WriteLine("内存利用率:" + Get_utilization_rate());
            System.Console.WriteLine("系统路径:" + Get_system_path());
            System.Console.WriteLine("window路径:" + Get_window_path());
            System.Console.WriteLine("cpu的id号:" + Get_CPUID());
            System.Console.WriteLine("获取cpu使用率:" + GetCPUCounter());


            System.Console.WriteLine("设备硬件卷号:" + Get_Disk_VolumeSerialNumber());
            System.Console.WriteLine("本机MAC地址:" + Get_mac_address());
            System.Console.WriteLine("邻节点MAC地址:" + Get_remote_mac("192.168.100.179"));
            System.Console.WriteLine("本机的ip地址:" + Get_ip());
            System.Console.WriteLine("硬盘id号:" + Get_disk_id());
            System.Console.WriteLine("登陆用户名:" + Get_user());
            System.Console.WriteLine("系统类型:" + Get_SystemType());
            System.Console.WriteLine("物理总内存:" + Get_TotalPhysicalMemory());
            System.Console.WriteLine("物理总内存换算:" + CsharpLazycode.Module.HardDisk.size.Util.GetString(Convert.ToInt64(Get_TotalPhysicalMemory())));

            System.Console.WriteLine("电脑名称:" + Get_ComputerName());
            System.Console.WriteLine("os版本信息:" + Get_OSVersion());


            return true;
        }

        public static MemoryInfo GetMemoryInfo()
        {
            var memoryInfo = new MemoryInfo();

            try
            {
                memoryInfo.TotalSize = Convert.ToUInt64(Get_TotalPhysicalMemory());

                //memoryInfo.totalSizestr = CsharpLazycode.Module.HardDisk.size.Util.GetString(Convert.ToInt64(memoryInfo.totalSize));

                memoryInfo.TotalSizestr = Get_PhysicalMemoryStrGBvalue() + " GB";

                memoryInfo.Percent = (Convert.ToDecimal(Get_utilization_rate())).ToString("0.00") + "%";


            }
            catch (Exception ex)
            {
                memoryInfo.TotalSize = 0;
                memoryInfo.TotalSizestr = "异常";
                memoryInfo.Percent = "异常" + "%";

                var exErr = string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                Console.WriteLine(exErr);

            }

            return memoryInfo;
        }

        public class MemoryInfo
        {
            public ulong TotalSize { get; set; }

            public string TotalSizestr { get; set; }

            public string Percent { get; set; }


        }


        public static CpuInfo GetCpuInfo()
        {

            var cpuInfo = new CpuInfo();

            try
            {
                cpuInfo.Total = 1;
                cpuInfo.Percent = (Convert.ToDecimal(GetCPUCounter())).ToString("0.00") + "%";
            }
            catch (Exception ex)
            {
                cpuInfo.Total = 1;
                cpuInfo.Percent = "异常" + "%";

                var exErr = string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                Console.WriteLine(exErr);
            }

            return cpuInfo;
        }

        public class CpuInfo
        {
            public int Total { get; set; }

            public string Percent { get; set; }

        }

        //获取内存信息
        public static StorageInfo Get_StorageInfo()
        {
            StorageInfo memInfor = new StorageInfo();
            GlobalMemoryStatus(ref memInfor);
            return memInfor;
        }
        //获取cpu信息
        public static CPUInfo Get_CPUInfo()
        {
            CPUInfo memInfor = new CPUInfo();
            GetSystemInfo(ref memInfor);
            return memInfor;
        }

        //获取cpu使用率
        public static object GetCPUCounter()
        {

            //PerformanceCounter cpuCounter = new PerformanceCounter
            //{
            //    CategoryName = "Processor",
            //    CounterName = "% Processor Time",
            //    InstanceName = "_Total"
            //};

            //// will always start at 0
            ////dynamic firstValue = cpuCounter.NextValue();
            //System.Threading.Thread.Sleep(1000);
            //// now matches task manager reading
            //dynamic secondValue = cpuCounter.NextValue();



            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddCommand("Get-WmiObject").AddArgument("win32_processor");
                IAsyncResult async = ps.BeginInvoke();
                foreach (PSObject result in ps.EndInvoke(async))
                {
                    var LoadPercentage = result.Members["LoadPercentage"].Value;
                    return LoadPercentage;

                    //Console.WriteLine(result);
                }
            }

            return 0;
            //return secondValue;

        }
        //获取系统时间信息
        public static SystemTimeInfo Get_SystemTimeInfo()
        {
            SystemTimeInfo memInfor = new SystemTimeInfo();
            GetSystemTime(ref memInfor);
            return memInfor;
        }
        //获取内存利用率函数
        public static string Get_utilization_rate()
        {
            StorageInfo memInfor = new StorageInfo();
            GlobalMemoryStatus(ref memInfor);
            return memInfor.dwMemoryLoad.ToString("0.0");
        }
        //获取系统路径
        public static string Get_system_path()
        {
            const int nChars = 128;
            StringBuilder Buff = new StringBuilder(nChars);
            GetSystemDirectory(Buff, nChars);
            return Buff.ToString();
        }
        //获取window路径
        public static string Get_window_path()
        {
            const int nChars = 128;
            StringBuilder Buff = new StringBuilder(nChars);
            GetWindowsDirectory(Buff, nChars);
            return Buff.ToString();
        }

        //获取cpu的id号
        public static string Get_CPUID()
        {
            try
            {
                string cpuInfo = "";//cpu序列号 

                using (ManagementClass mc = new ManagementClass("Win32_Processor"))
                {
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    }

                    return cpuInfo;
                }


            }
            catch
            {
                return "unknow";
            }
        }
        //获取设备硬件卷号
        public static string Get_Disk_VolumeSerialNumber()
        {
            //ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");

            using (ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"d:\""))
            {
                disk.Get();
                return disk.GetPropertyValue("VolumeSerialNumber").ToString();
            }

        }
        //获取mac地址
        public static string Get_mac_address()
        {
            string mac = "";

            using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                    }
                    mo.Dispose();
                }
                return mac;
            }



        }
        //根据ip获取邻节点MAC地址
        public static string Get_remote_mac(string ip)
        {
            StringBuilder mac = new StringBuilder();
            try
            {
                Int32 remote = Inet_addr(ip);
                Int64 macinfo = new Int64();
                Int32 length = 6;
                SendARP(remote, 0, ref macinfo, ref length);
                string temp = Convert.ToString(macinfo, 16).PadLeft(12, '0').ToUpper();
                int x = 12;
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5)
                        mac.Append(temp.Substring(x - 2, 2));
                    else
                        mac.Append(temp.Substring(x - 2, 2) + "-");
                    x -= 2;
                }
                return mac.ToString();
            }
            catch
            {
                return mac.ToString();
            }
        }
        //获取本机的ip地址
        public static string Get_ip()
        {
            try
            {
                string st = "";


                using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
                {
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        if ((bool)mo["IPEnabled"] == true)
                        {
                            //st=mo["IpAddress"].ToString(); 
                            System.Array ar;
                            ar = (System.Array)(mo.Properties["IpAddress"].Value);
                            st = ar.GetValue(0).ToString();
                            break;
                        }
                    }

                    return st;
                }



            }
            catch
            {
                return "unknow";
            }
        }
        //获取硬盘id号
        public static string Get_disk_id()
        {
            try
            {
                String HDid = "";

                using (ManagementClass mc = new ManagementClass("Win32_DiskDrive"))
                {
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        HDid = (string)mo.Properties["Model"].Value;
                    }

                    return HDid;
                } 
            }
            catch
            {
                return "unknow";
            }
        }
        //获得系统登陆用户名
        public static string Get_user()
        {
            try
            {
                string st = "";
                using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                {
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        st = mo["UserName"].ToString();
                    }
                    moc.Dispose();
                    mc.Dispose();
                    return st;
                }

            }
            catch
            {
                return "unknow";
            }
        }
        //获得系统类型
        public static string Get_SystemType()
        {
            try
            {
                string st = "";

                using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                {
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        st = mo["SystemType"].ToString();
                    }
                    return st;
                }



            }
            catch
            {
                return "unknow";
            }
        }
        //获得物理总内存
        public static string Get_TotalPhysicalMemory()
        {
            try
            {
                string st = "";

                using (ManagementClass mc = new ManagementClass("Win32_ComputerSystem"))
                {
                    ManagementObjectCollection moc = mc.GetInstances();
                    foreach (ManagementObject mo in moc)
                    {
                        st = mo["TotalPhysicalMemory"].ToString();
                    }
                }
                return st;
            }
            catch
            {
                return "unknow";
            }

        }
        //获得物理总内存 单位GB
        public static string Get_PhysicalMemoryStrGBvalue()
        {
            try
            {
                //Memory
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.AddScript("(Get-CimInstance Win32_PhysicalMemory | Measure-Object -Property capacity -Sum).sum /1gb");
                    IAsyncResult async = ps.BeginInvoke();
                    foreach (PSObject result in ps.EndInvoke(async))
                    {
                        var str = result.ToString();
                        return str;
                    }
                }

                return "0";
            }
            catch
            {
                return "0";
            }

        }


        //获得电脑名称
        public static string Get_ComputerName()
        {
            try
            {
                return System.Environment.GetEnvironmentVariable("ComputerName");
            }
            catch
            {
                return "unknow";
            }
        }
        //
        public static float 性能显示状况2(string CategoryName, string CounterName)
        {
            PerformanceCounter pc = new PerformanceCounter(CategoryName, CounterName);
            Thread.Sleep(500);
            float xingneng = pc.NextValue();
            pc.Dispose();
            return xingneng;
        }

        public static float 性能显示状况3(string CategoryName, string CounterName, string InstanceName)
        {
            using (PerformanceCounter pc = new PerformanceCounter(CategoryName, CounterName, InstanceName))
            {
                Thread.Sleep(500); // wait for 1 second 
                float xingneng = pc.NextValue();
                return xingneng;
            }

        }
        //获取os版本信息
        public static string Get_OSVersion()
        {
            System.OperatingSystem version = System.Environment.OSVersion;
            switch (version.Platform)
            {
                case System.PlatformID.Win32Windows:
                    switch (version.Version.Minor)
                    {
                        case 0:
                            return "Windows 95";
                        case 10:
                            if (version.Version.Revision.ToString() == "2222A")
                                return "Windows 98 Second Edition";
                            else
                                return "Windows 98";
                        case 90:
                            return "Windows Me";
                    }
                    break;
                case System.PlatformID.Win32NT:
                    switch (version.Version.Major)
                    {
                        case 3:
                            return "Windows NT 3.51";
                        case 4:
                            return "Windows NT 4.0";
                        case 5:
                            if (version.Version.Minor == 0)
                                return "Windows 2000";
                            else
                                return "Windows XP";
                        case 6:
                            return "Windows 8";
                    }
                    break;
            }
            return "发现失败";

        }


    }


}

