using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CsharpLazycode.Module.Process
{
    public class Util
    {
        public static bool IsnotmoreProcess(string guid, bool showmsg = true)
        {
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, guid, out bool ret);
            if (ret) { mutex.ReleaseMutex(); }
            else
            {
                if (showmsg == true)
                {
                    MessageBox.Show("有一个和本程序相同的应用程序已经在运行，请不要同时运行多个本程序。\n\n这个程序即将退出。", "禁止多开", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            mutex.Dispose();

            return ret;
        }

        /// <summary>    
        /// 运行DOS命令    
        /// DOS关闭进程命令(ntsd -c q -p PID )PID为进程的ID    
        /// 例如 "taskkill /im " +"WerFault.exe" + " /f "
        /// 例如: taskkill /im WerFault.exe /f
        /// </summary>    
        /// <param name="command"></param>    
        /// <returns></returns>    
        public static string RunCmd(string command)
        {
            try
            {
                //實例一個Process類，啟動一個獨立進程    
                System.Diagnostics.Process p = new System.Diagnostics.Process();

                //Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：    

                p.StartInfo.FileName = "cmd.exe";           //設定程序名    
                p.StartInfo.Arguments = "/c " + command;    //設定程式執行參數    
                p.StartInfo.UseShellExecute = false;        //關閉Shell的使用    
                p.StartInfo.RedirectStandardInput = true;   //重定向標準輸入    
                p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出    
                p.StartInfo.RedirectStandardError = true;   //重定向錯誤輸出    
                p.StartInfo.CreateNoWindow = true;          //設置不顯示窗口    

                p.Start();   //啟動    

                //p.StandardInput.WriteLine(command);       //也可以用這種方式輸入要執行的命令    
                //p.StandardInput.WriteLine("exit");        //不過要記得加上Exit要不然下一行程式執行的時候會當機    

                var rst = p.StandardOutput.ReadToEnd();        //從輸出流取得命令執行結果   
                p.Dispose();

                return rst;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("异常[{0}] [{1}]:{2}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));


                return string.Format("异常[{0}]", ex.Message);

            }


        }

    }
    public class Classes
    {

        public class DiagnosticsProcess
        {
            public static System.Diagnostics.Process GetParentProcess(int iCurrentPid)
            {
                int iParentPid = 0;
                //int iCurrentPid = Process.GetCurrentProcess().Id;

                IntPtr oHnd = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

                if (oHnd == IntPtr.Zero)
                    return null;

                PROCESSENTRY32 oProcInfo = new PROCESSENTRY32
                {
                    dwSize =
                (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(PROCESSENTRY32))
                };

                if (Process32First(oHnd, ref oProcInfo) == false)
                    return null;

                do
                {
                    if (iCurrentPid == oProcInfo.th32ProcessID)
                        iParentPid = (int)oProcInfo.th32ParentProcessID;
                }
                while (iParentPid == 0 && Process32Next(oHnd, ref oProcInfo));

                if (iParentPid > 0)
                    try
                    {
                        return System.Diagnostics.Process.GetProcessById(iParentPid);
                    }
                    catch (Exception)
                    {

                        return null;

                    }
                else
                    return null;
            }

            static readonly uint TH32CS_SNAPPROCESS = 2;

            [StructLayout(LayoutKind.Sequential)]
            public struct PROCESSENTRY32
            {
                public uint dwSize;
                public uint cntUsage;
                public uint th32ProcessID;
                public IntPtr th32DefaultHeapID;
                public uint th32ModuleID;
                public uint cntThreads;
                public uint th32ParentProcessID;
                public int pcPriClassBase;
                public uint dwFlags;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szExeFile;
            };

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

            [DllImport("kernel32.dll")]
            static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

            [DllImport("kernel32.dll")]
            static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);
        }
    }
}
