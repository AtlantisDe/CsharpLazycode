using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Color
{
    public class Util
    {
        public static string cssRandomrgbvalue
        {
            get
            {
                var r1 = CsharpLazycode.Module.Laycode.random.NextIncludeMax(0, 255);
                var r2 = CsharpLazycode.Module.Laycode.random.NextIncludeMax(0, 255);
                var r3 = CsharpLazycode.Module.Laycode.random.NextIncludeMax(0, 255);
                var a = string.Format("rgb({0}, {1}, {2})", r1, r2, r3);
                return a;
            }
        }
        public static string cssRandomToHtmlvalue
        {
            get
            {
                var r1 = CsharpLazycode.Module.Laycode.random.NextIncludeMax(0, 255);
                var r2 = CsharpLazycode.Module.Laycode.random.NextIncludeMax(0, 255);
                var r3 = CsharpLazycode.Module.Laycode.random.NextIncludeMax(0, 255);

                var color = System.Drawing.Color.FromArgb(r1, r2, r3);

                return System.Drawing.ColorTranslator.ToHtml(color);
            }
        }

        public static char[] cssRandomToHtmlvaluechararg
        {
            get
            {
                return cssRandomToHtmlvalue.ToArray();
            }
        }

        public static string css_color_random_Like_aaaaaa(string oldstring)
        {
            //Console.WriteLine("28a745".Length);
            var arg = oldstring.ToCharArray();
            char color_begin = '#';
            char color_end = ';';
            var count_break = arg.Length - 100;
            for (int i = 0; i < arg.Length; i++)
            {
                if (i > count_break) { break; }
                var ele_a = arg[i];
                var ele_b = arg[i + 7];

                if (ele_a == color_begin && ele_b == color_end)
                {
                    var newcolor = CsharpLazycode.Module.Color.Util.cssRandomToHtmlvaluechararg;
                    for (int j = 0; j < newcolor.Length; j++)
                    {
                        arg[i + j] = newcolor[j];
                    }
                }
            }
            var newstr = new string(arg);
            arg = null;
            return newstr;
        }
    }
}
