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

            str_HardDiskName += ":\\";

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

            str_HardDiskName += ":\\";

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
            try
            {
                hardDiskInfo.HardDiskName = str_HardDiskName;

                hardDiskInfo.Utotal = GetHardDiskSpace(str_HardDiskName);
                hardDiskInfo.Ufree = GetHardDiskFreeSpace(str_HardDiskName);

                hardDiskInfo.Percent = ((hardDiskInfo.Ufree * 1.0 / hardDiskInfo.Utotal) * 100).ToString("0.00") + "%";

                hardDiskInfo.Total = CsharpLazycode.Module.HardDisk.size.Util.GetString(hardDiskInfo.Utotal);
                hardDiskInfo.Free = CsharpLazycode.Module.HardDisk.size.Util.GetString(hardDiskInfo.Ufree);

            }
            catch (Exception ex)
            {

                hardDiskInfo.Utotal = 0;
                hardDiskInfo.Ufree = 0;

                hardDiskInfo.Percent = "异常" + "%";

                hardDiskInfo.Total = "异常";
                hardDiskInfo.Free = "异常";

                var exErr = string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                Console.WriteLine(exErr);

            }




            return hardDiskInfo;
        }

        public class HardDiskInfo
        {
            public string HardDiskName { get; set; }


            public string Total { get; set; }
            public string Free { get; set; }


            public long Utotal { get; set; }
            public long Ufree { get; set; }

            public string Percent { get; set; }


        }

    }
}
