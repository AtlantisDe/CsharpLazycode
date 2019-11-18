using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.base64
{
    public class Util
    {
        public static string BeforeEncode(string base64string)
        {
            return base64string.Replace("+", "%2B");
        }
        public static string AfterDecode(string base64string)
        {
            return base64string.Replace("%2B", "+");
        }
        //base64字符串解密为字符串,本类型:解密-(加密base64替换的数据)
        public static string AfterDecodeRspace(string base64string, System.Text.Encoding encode = null)
        {
            var abase64 = Convert.FromBase64String(CsharpLazycode.Module.base64.Util.AfterDecode(base64string));

            string nobase64string = "";
            try
            {
                if (encode == null) { encode = System.Text.Encoding.UTF8; }
                nobase64string = encode.GetString(abase64);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("异常[{0}] [{1}]:{2}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            }

            return nobase64string;
        }

        public static string Base64ToString(string base64string, System.Text.Encoding encode = null)
        {

            var DeStr = "";
            try
            {
                var abase64 = Convert.FromBase64String(base64string); 
                if (encode == null) { encode = System.Text.Encoding.UTF8; }
                DeStr = encode.GetString(abase64);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("异常[{0}] [{1}]:{2}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            } 
            return DeStr;
        }

        //字符串到Base64加密字符串
        public static string String2base64(string text, System.Text.Encoding encode = null)
        {
            //string  to  base64
            string base64string = "";
            try
            {

                if (encode == null) { encode = System.Text.Encoding.UTF8; }
                byte[] bytedata = encode.GetBytes(text);
                base64string = Convert.ToBase64String(bytedata, 0, bytedata.Length);

            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("异常[{0}] [{1}]:{2}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            }
            return base64string;
        }



    }
}
