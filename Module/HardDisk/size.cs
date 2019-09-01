using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.HardDisk.size
{
    public class Util
    {
        //字节转换成"B", "KB", "MB", "GB", "TB", "PB"实例

        /// <summary>
        /// 转换方法 卡死了这算法弃用
        /// </summary>
        /// <param name="size">字节值</param>
        /// <returns></returns>
        [Obsolete]
        public static String HumanReadableFilesize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            double mod = 1024.0;
            int i = 0;
            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size) + units[i];
        }

        public static string GetString(long b, string splitStr = " ")
        {
            const int GB = 1024 * 1024 * 1024;
            const int MB = 1024 * 1024;
            const int KB = 1024;


            if (b / GB >= 1)
            {
                return Math.Round(b / (float)GB, 2) + splitStr + "GB";
            }


            if (b / MB >= 1)
            {
                return Math.Round(b / (float)MB, 2) + splitStr + "MB";
            }


            if (b / KB >= 1)
            {
                return Math.Round(b / (float)KB, 2) + splitStr + "KB";
            }


            return b + splitStr + "B";
        }

    }
}
