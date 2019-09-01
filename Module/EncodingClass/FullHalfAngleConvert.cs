using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.EncodingClass
{
    public class FullHalfAngleConvert
    {

        public class Util
        {
            /// <summary>
            /// 转全角的函数(SBC case)  全角字符串  全角空格为12288，半角空格为32 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
            /// </summary>
            /// <param name="input">任意字符串</param>
            /// <returns></returns>
            public static String ToSBC(String input)
            {

                // 半角转全角：
                char[] c = input.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == 32)
                    {
                        c[i] = (char)12288;
                        continue;
                    }
                    if (c[i] < 127)
                        c[i] = (char)(c[i] + 65248);
                }
                return new String(c);
            }

            /// <summary>
            /// 转半角的函数(DBC case) 任意字符串 半角字符串 全角空格为12288，半角空格为32 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
            /// </summary>
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static String ToDBC(String input)
            {
                char[] c = input.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == 12288)
                    {
                        c[i] = (char)32;
                        continue;
                    }
                    if (c[i] > 65280 && c[i] < 65375)
                        c[i] = (char)(c[i] - 65248);
                }
                return new String(c);
            }

       
            public static void TestMethod_ToDBC_TEST()
            {
                string strSBC = "中华１２５９ｔｅｓｔ";
                string result = ToDBC(strSBC);

                Console.WriteLine(strSBC);
                Console.WriteLine(result);
              
            }

            public static void TestMethod_ToSBC_TEST()
            {
                string strSBC = "中华1259test";
                string result = ToDBC(strSBC);

             

                Console.WriteLine(strSBC);
                Console.WriteLine(result);

            }

            public static void TestMethod_useSpeToSBC_TEST()
            {
                string strSBC = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; 
                string result = ToSBC(strSBC);
                 

                Console.WriteLine(strSBC);
                Console.WriteLine(result);

            }


        }
    }
}
