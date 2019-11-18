using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Extensions
{
    class ListExtenions
    {
    }
}

public static class ListExtensions
{
    public static string ToStringWithNewline<T>(this List<T> list, string splitStr = "\r\n")
    {
        var tmp = "";
        for (int i = 0; i < list.Count; i++)
        {
            tmp = tmp + list[i] + (i < list.Count - 1 ? splitStr : "");
        }

        return tmp;
    }

    public static T GetRandomOneElement<T>(this List<T> list)
    {
 

        try
        {
            var RandomNumber = CsharpLazycode.Module.Laycode.Random.Next(0, list.Count); 
            return (T)list[RandomNumber];
        }
        catch (Exception)
        {
            return default;
        }
    }
   

}

