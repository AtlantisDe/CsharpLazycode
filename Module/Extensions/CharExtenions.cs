using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Extensions
{
    class CharExtenions
    {
    }
}
public static class CharExtenions
{
    public static char GetRandomOneElement(this char[] list)
    {
        var cache = System.Runtime.Caching.MemoryCache.Default;
        try
        {
            var RandomNumber = CsharpLazycode.Module.Laycode.random.Next(0, list.Length);
            return list[RandomNumber];
        }
        catch (Exception)
        {
            return default(char);
        }
    }

}