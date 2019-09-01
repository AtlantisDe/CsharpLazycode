using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Page
{
    public class Utilities
    {
        //void PageEach<T>(IEnumerable<T> pageItems, int pageSize, Action<List<T>> action);
        public static void PageEach<T>(IEnumerable<T> pageItems, int pageSize, Action<List<T>> action)
        {
            if (pageItems != null && pageItems.Any())
            {
                int totalRecord = pageItems.Count();
                int pageCount = (totalRecord + pageSize - 1) / pageSize;
                for (int i = 1; i <= pageCount; i++)
                {
                    var list = pageItems.Skip((i - 1) * pageSize).Take(pageSize).ToList();
                    action(list);
                }
            }
        } 


    }
}
