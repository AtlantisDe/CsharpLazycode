using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Extensions
{

}


public static class HashtableExtenions
{

    public static string KeysToStringWithNewline(this Hashtable ht, string splitStr = "\r\n")
    {
        var tmp = "";
        foreach (var item in ht.Keys)
        {
            if (ht.Keys.Equals(item))
            {
                tmp = tmp + item;
            }
            else
            {
                tmp = tmp + item + splitStr;
            }
        }
        return tmp;
    } 
}

