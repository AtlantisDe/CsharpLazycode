using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace CsharpLazycode.Module.requireAdministrator
{
    public class Util
    {
        /// <summary>
        /// 确定当前主体是否属于具有指定 Administrator 的 Windows 用户组
        /// </summary>
        /// <returns>如果当前主体是指定的 Administrator 用户组的成员，则为 true；否则为 false。</returns>
        public static bool IsAdministrator()
        {
            bool result;
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                result = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static bool IsAdministratorshowmsg(string showmsg = "请用管理员身份运行本程序,权限不足,部分功能受限.", string title = "管理员权限低")
        {
            try
            {
                if (CsharpLazycode.Module.requireAdministrator.Util.IsAdministrator() == false)
                {
                    System.Windows.Forms.MessageBox.Show(showmsg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }
            catch
            {
            }
            return true;
        }


    }
}

