using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Web
{
    public class WebToolcs
    {

        public class Util
        {

            /// <summary>
            /// 获取客户端ip
            /// </summary>
            /// <returns></returns>
            public static string GetWebClientIp()
            {
                string userIP = "";
                try
                {
                    if (System.Web.HttpContext.Current == null
                || System.Web.HttpContext.Current.Request == null
                || System.Web.HttpContext.Current.Request.ServerVariables == null)
                        return "";
                    string CustomerIP = "";
                    //CDN加速后取到的IP simone 090805
                    CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                    if (!string.IsNullOrEmpty(CustomerIP))
                    {
                        return CustomerIP;
                    }
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (!String.IsNullOrEmpty(CustomerIP))
                    {
                        return CustomerIP;
                    }
                    if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                    {
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (CustomerIP == null)
                            CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                    else
                    {
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                    if (string.Compare(CustomerIP, "unknown", true) == 0)
                        return System.Web.HttpContext.Current.Request.UserHostAddress;
                    return CustomerIP;
                }
                catch { }
                return userIP;
            }


        }
    }
}

