using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Laycode.List
{
   public class MyList<T> : IEnumerator
    {
        readonly List<T> list = new List<T>();
        public object current = null;
        public object Current
        {
            get { return current; }
        }
        int icout = 0;
        public bool MoveNext()
        {
            if (icout >= list.Count)
            {
                return false;
            }
            else
            {
                current = list[icout];
                icout++;
                return true;
            }
        }

        public void Reset()
        {
            icout = 0;
        }

        public void Add(T t)
        {
            list.Add(t);
        }

        public void Remove(T t)
        {
            if (list.Contains(t))
            {
                if (list.IndexOf(t) <= icout)
                {
                    icout--;
                }
                list.Remove(t);
            }
        }

    }
}
