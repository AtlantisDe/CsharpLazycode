using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLazycode.Module.Extensions
{

}

public static class RandomExtenions
{
    //随机字符不含特殊字符 包含数字 字母 大小写
    public static string Xcharacter(int len)
    {
        return CsharpLazycode.Module.Laycode.Random.GetRandomString(len, true, true, true, false, "");
    }
    //随机字符不含特殊字符 包含数字 字母 大小写
    public static int NextIncludeMax(int minValue, int maxValue)
    {
        return CsharpLazycode.Module.Laycode.Random.NextIncludeMax(minValue, maxValue);
    }


}