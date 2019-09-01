using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.HardDisk
{
    public class Util
    {
        /// 获取指定驱动器的空间总大小(单位为B)
        /// </summary>
        /// <param name="str_HardDiskName">只需输入代表驱动器的字母即可 </param>
        /// <returns> </returns>
        public static long GetHardDiskSpace(string str_HardDiskName)

        {

            long totalSize = new long();

            str_HardDiskName = str_HardDiskName + ":\\";

            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();

            foreach (System.IO.DriveInfo drive in drives)

            {

                if (drive.Name == str_HardDiskName)

                {

                    totalSize = drive.TotalSize;

                }

            }

            return totalSize;

        }

        public static string GetHardDiskSpacestr(string str_HardDiskName)
        {
            return CsharpLazycode.Module.HardDisk.size.Util.GetString(GetHardDiskSpace(str_HardDiskName));

        }

        /// <summary>

        /// 获取指定驱动器的剩余空间总大小(单位为B)

        /// </summary>

        /// <param name="str_HardDiskName">只需输入代表驱动器的字母即可 </param>

        /// <returns> </returns>

        public static long GetHardDiskFreeSpace(string str_HardDiskName)
        {

            long freeSpace = new long();

            str_HardDiskName = str_HardDiskName + ":\\";

            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();

            foreach (System.IO.DriveInfo drive in drives)

            {

                if (drive.Name == str_HardDiskName)

                {

                    freeSpace = drive.TotalFreeSpace;

                }

            }

            return freeSpace;

        }

        public static string GetHardDiskFreeSpacestr(string str_HardDiskName)
        {
            return CsharpLazycode.Module.HardDisk.size.Util.GetString(GetHardDiskFreeSpace(str_HardDiskName));
        }

        public static HardDiskInfo GetHardDiskinfo(string str_HardDiskName)
        {

            var hardDiskInfo = new HardDiskInfo();
            hardDiskInfo.HardDiskName = str_HardDiskName;

            hardDiskInfo.utotal = GetHardDiskSpace(str_HardDiskName);
            hardDiskInfo.ufree = GetHardDiskFreeSpace(str_HardDiskName);

            hardDiskInfo.Percent = ((hardDiskInfo.ufree * 1.0 / hardDiskInfo.utotal) * 100).ToString("0.00") + "%";

            hardDiskInfo.total = CsharpLazycode.Module.HardDisk.size.Util.GetString(hardDiskInfo.utotal);
            hardDiskInfo.free = CsharpLazycode.Module.HardDisk.size.Util.GetString(hardDiskInfo.ufree);


            return hardDiskInfo;
        }

        public class HardDiskInfo
        {
            public string HardDiskName { get; set; }


            public string total { get; set; }
            public string free { get; set; }


            public long utotal { get; set; }
            public long ufree { get; set; }

            public string Percent { get; set; }


        }

    }
}
