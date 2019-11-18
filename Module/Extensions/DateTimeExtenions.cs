using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Extensions
{
}


public static class DateTimeExtenions
{

    public static string Format1(this DateTime thisValue, string FormatStr = "yyyy-MM-dd HH:mm:ss:ffff")
    {
        var tmp = thisValue.ToString(FormatStr);

        try
        {
            tmp = thisValue.ToString(FormatStr);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return tmp;
    }
    public static string Format2(this DateTime thisValue, string FormatStr = "yyyy-MM-dd HH:mm:ss")
    {
        var tmp = thisValue.ToString(FormatStr);

        try
        {
            tmp = thisValue.ToString(FormatStr);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return tmp;
    }

    public static string Format3(this DateTime thisValue, string FormatStr = "yyyy-MM-dd")
    {
        var tmp = thisValue.ToString(FormatStr);
        try
        {
            tmp = thisValue.ToString(FormatStr);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return tmp;
    }


}

