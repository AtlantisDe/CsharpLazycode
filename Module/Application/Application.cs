using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Application
{
    public class Util
    {
        public static void ExitWiki()
        {
            //Application.Exit()只是发出终止的消息，并不立即退出
            //立即退出可以用Environment.Exit(0)
            //最后也是使用 System.Diagnostics.Process.GetCurrentProcess().Kill();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        public static void Exit()
        {
            System.Windows.Forms.Application.Exit();
        }
        private static void Exit0()
        {
            //System.Windows.Forms.Application.Exit(0);

        }

        public static void KillCurrentProcess()
        { 
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }



    }
}
