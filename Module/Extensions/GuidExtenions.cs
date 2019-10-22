using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLazycode.Module.Extensions
{
    class GuidExtenions
    {
    }
}
public static class GuidExtenions
{
    public static string N
    {
        get { return System.Guid.NewGuid().ToString("N"); }
    } 
 }

