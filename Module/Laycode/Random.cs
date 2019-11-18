using System;
using System.Linq;

namespace CsharpLazycode.Module.Laycode
{
    public class Random
    {
        ///<summary>
        ///生成随机字符串
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            //byte[] b = new byte[4];
            //new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);

            //Random r = new Random(BitConverter.ToInt32(b, 0));
            //System.Random r = new System.Random(GetRandomSeed());
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                System.Random r = new System.Random(GetRandomSeed());
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }

            return s;
        }


        public static string GetRandomString(int min, int max, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            var rid = CsharpLazycode.Module.Laycode.Random.NextIncludeMax(min, max);

            return CsharpLazycode.Module.Laycode.Random.GetRandomString(rid, useNum, useLow, useUpp, useSpe, custom);
        }


        //获取随机种子
        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            using (System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            return BitConverter.ToInt32(bytes, 0);
        }
        //传值(0,2)返回0-1包含1之间的数
        public static int Next(int minValue, int maxValue)
        {
            System.Random rd = new System.Random(GetRandomSeed());
            var id = rd.Next(minValue, maxValue);
            //Console.WriteLine(id);


            return id;

        }
        //传值(0,2)返回0-2包含2之间的数
        public static int NextIncludeMax(int minValue, int maxValue)
        {
            System.Random rd = new System.Random(GetRandomSeed());
            var id = rd.Next(minValue, maxValue + 1);
            //Console.WriteLine(id);
            return id;

        }
        //传值[0,2]返回0-2包含2之间的数,如果解析异常,返回默认配置值
        public static int NextIncludeMax(string Range, int intdefault)
        {

            try
            {
                var a = Range.Replace("[", "").Replace("]", "").Trim();



                if (a.IsContainsIn(","))
                {
                    var arr = a.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length == 2)
                    {
                        int minValue = Convert.ToInt32(arr[0]);
                        int maxValue = Convert.ToInt32(arr[1]);
                        System.Random rd = new System.Random(GetRandomSeed());
                        var id = rd.Next(minValue, maxValue + 1);
                        //Console.WriteLine(id);
                        return id;
                    }
                }

            }
            catch (Exception ex)
            {
                var exErr = string.Format("异常包: [{0}] [{1}] 异常消息:{2}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                Console.WriteLine(exErr);
            }
            finally
            {
            }

            return intdefault;
        }

    }

}



