using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLazycode.Module.Extensions
{

}
public static class LongExtenions
{
    /// <summary>
    /// 字节转换成"B", "KB", "MB", "GB", "TB", "PB"实例
    /// </summary>
    /// <param name="b"></param>
    /// <param name="splitStr">与单位之间的分割符</param>
    /// <returns></returns>
    public static string ToUnitStr(this long b, string splitStr = " ")
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
