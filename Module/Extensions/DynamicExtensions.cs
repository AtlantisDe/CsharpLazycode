using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLazycode.Module.Extensions
{
    class DynamicExtensions
    {
    }
}

public static class DynamicExtensions
{

    public static bool IsPropertyExist(dynamic data, string propertyname)
    {
        if (data is ExpandoObject)
            return ((IDictionary<string, object>)data).ContainsKey(propertyname);
        return data.GetType().GetProperty(propertyname) != null;
    }

    public static object GetProperty(object o, string member)
    {
        if (o == null) throw new ArgumentNullException("o");
        if (member == null) throw new ArgumentNullException("member");
        Type scope = o.GetType();
        if (o as IDynamicMetaObjectProvider != null)
        {
            ParameterExpression param = Expression.Parameter(typeof(object));
            DynamicMetaObject mobj = (o as IDynamicMetaObjectProvider).GetMetaObject(param);
            GetMemberBinder binder = (GetMemberBinder)Microsoft.CSharp.RuntimeBinder.Binder.GetMember(0, member, scope, new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(0, null) });
            DynamicMetaObject ret = mobj.BindGetMember(binder);
            BlockExpression final = Expression.Block(
                Expression.Label(CallSiteBinder.UpdateLabel),
                ret.Expression
            );
            LambdaExpression lambda = Expression.Lambda(final, param);
            Delegate del = lambda.Compile();
            return del.DynamicInvoke(o);
        }
        else
        {
            return o.GetType().GetProperty(member, BindingFlags.Public | BindingFlags.Instance).GetValue(o, null);
        }
    }

    public static bool BoolGet(dynamic dynamicOBJ, string propertyname)
    {

        try
        {
            var value = DynamicExtensions.GetProperty(dynamicOBJ, propertyname);
            return Convert.ToBoolean(value);

        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return false;


    }
    public static string StringGet(dynamic dynamicOBJ, string propertyname)
    {

        try
        {
            var value = DynamicExtensions.GetProperty(dynamicOBJ, propertyname);
            if (value == null)
            {
                return "";

            }

            return (string)value;

        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return "";


    }

    public static int IntGet(dynamic dynamicOBJ, string propertyname)
    {

        try
        {
            var value = DynamicExtensions.GetProperty(dynamicOBJ, propertyname);
            if (value == null)
            {
                return 0;

            }

            return (int)value;

        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return 0;


    }


    public static DateTime DateTimeGet(dynamic dynamicOBJ, string propertyname)
    {
        try
        {
            var value = DynamicExtensions.GetProperty(dynamicOBJ, propertyname);
            if (value == null)
            {
                return default;

            }

            return (DateTime)value;

        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return default;


    }

}


