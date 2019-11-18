using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Laycode.Path
{
    public class Util
    {
        public static string ToWindowsstyle(string pathstr)
        {
            var a = pathstr;
            a = a.Replace("/", @"\");
            a = a.Replace(@"\\", @"\"); 
            return a;
        }
    }
}
