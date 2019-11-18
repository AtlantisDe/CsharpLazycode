using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLazycode.Module
{
    public class ApplicationInfo
    {

        public class AppUsedMemoryInfo
        {
            public double Total { get; set; }

            public string Percent { get; set; }


        }


        public static double GetProcessUsedMemoryValue()
        {
            double usedMemory = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0;
            return usedMemory;

        }
     

        public static AppUsedMemoryInfo GetProcessUsedMemory()
        {
            AppUsedMemoryInfo appUsedMemoryInfo = new AppUsedMemoryInfo
            {
                Total = System.Diagnostics.Process.GetCurrentProcess().WorkingSet64
            };
            appUsedMemoryInfo.Percent = CsharpLazycode.Module.HardDisk.size.Util.GetString(Convert.ToInt64(appUsedMemoryInfo.Total));
             
            return appUsedMemoryInfo; 
        }


    }
}
