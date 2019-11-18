using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsharpLazycode.Module.Extensions
{

}


public static class StringExtenions
{

    public static int ToInt32(this string thisValue, int defaultvalue = 0)
    {
        var tmp = defaultvalue;
        try
        {
            tmp = Convert.ToInt32(thisValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }

        return tmp;
    }

    public static string GetStringMid(this string str, string str1, string str2)
    {
        try
        {
            int leftlocation;//左边位置
            int rightlocation;//右边位置
            int strmidlength; ;//中间字符串长度
            string strmid;//中间字符串
            leftlocation = str.IndexOf(str1);
            //获取左边字符串头所在位置
            if (leftlocation == -1)//判断左边字符串是否存在于总字符串中
            {
                return "";
            }
            leftlocation += str1.Length;//获取左边字符串尾所在位置
            rightlocation = str.IndexOf(str2, leftlocation);
            //获取右边字符串头所在位置
            if (rightlocation == -1 || leftlocation > rightlocation)//判断右边字符串是否存在于总字符串中，左边字符串位置是否在右边字符串前
            {
                return "";
            }
            strmidlength = rightlocation - leftlocation;//计算中间字符串长度
            strmid = str.Substring(leftlocation, strmidlength);//取出中间字符串
            return strmid;//返回中间字符串
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return "";

    }

    public static List<string> MatchStringMid(this string str, string str1, string str2, bool IncludeHalfOfFindKey = false)
    {
        var Items = new List<string>();
        try
        {
            int leftlocationStart;//左边开始位置 
            leftlocationStart = 0;

            while (leftlocationStart != -1)
            {
                Go_FindMathch();
            }

            bool Go_FindMathch()
            {
                int leftlocation;//左边位置
                int rightlocation;//右边位置
                int strmidlength; ;//中间字符串长度
                string strmid;//中间字符串
                leftlocation = str.IndexOf(str1, leftlocationStart);
                //获取左边字符串头所在位置
                if (leftlocation == -1)//判断左边字符串是否存在于总字符串中
                {
                    leftlocationStart = -1;
                    return false;
                }
                leftlocation += str1.Length;//获取左边字符串尾所在位置
                rightlocation = str.IndexOf(str2, leftlocation);
                //获取右边字符串头所在位置
                if (rightlocation == -1 || leftlocation > rightlocation)//判断右边字符串是否存在于总字符串中，左边字符串位置是否在右边字符串前
                {
                    leftlocationStart = -1;
                    return false;
                }
                strmidlength = rightlocation - leftlocation;//计算中间字符串长度
                strmid = str.Substring(leftlocation, strmidlength);//取出中间字符串

                leftlocationStart = leftlocation + strmidlength;

                if (strmid.IsNullOrEmpty() == false)
                {
                    if (IncludeHalfOfFindKey == true)
                    {
                        Items.Add(string.Format("{0}{1}{2}", str1, strmid, str2));//返回中间字符串} 
                    }
                    else
                    {
                        Items.Add(strmid);//返回中间字符串} 
                    }
                }

                return true;
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return Items;

    }

    public static string GetStringMidFromEnd(this string str, string str1, string str2)
    {
        try
        {
            int leftlocation;
            int rightlocation;
            int strmidlength; ;
            string strmid;
            rightlocation = str.LastIndexOf(str2);

            if (rightlocation == -1)
            {
                return "";
            }
            //rightlocation = rightlocation - str2.Length;
            leftlocation = str.LastIndexOf(str1, rightlocation - str2.Length);

            if (leftlocation == -1 || rightlocation < leftlocation)
            {
                return "";
            }
            strmidlength = rightlocation - (leftlocation + str1.Length);
            strmid = str.Substring(leftlocation + str1.Length, strmidlength);
            return strmid;
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return "";

    }

    public static bool IsNumeric(this string str)
    {
        if (str == null || str.Length == 0)
        {
            return false;
        }
        foreach (char c in str)
        {
            if (!Char.IsNumber(c))
            {
                return false;
            }
        }
        return true;
    }

    public static string Md5(this string str)
    {
        try
        {
            return CsharpLazycode.Module.MessageDigestAlgorithm.Util.Md5(str);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return "";
    }
    public static int StringToInt32(this string str)
    {
        try
        {
            return BitConverter.ToInt32(Encoding.UTF8.GetBytes(str), 0); ;
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return 0;
    }

    public static List<string> ToListGet(this string str, string separatorStr = "\r\n", StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
    {
        var items = new List<string>();
        try
        {
            items = str.Split(separatorStr.ToArray(), options).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return items;
    }
    public static string[] ToArrayGet(this string str, string separatorStr = "\r\n", StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
    {
        var items = new string[0];
        try
        {
            items = str.Split(separatorStr.ToArray(), options);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {

        }
        return items;
    }


    public static string ToBase64(this string str, System.Text.Encoding encode = null)
    {
        try
        {
            return CsharpLazycode.Module.base64.Util.String2base64(str, encode);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return "";
    }
    public static string ToBase64Typewebrequest(this string str, System.Text.Encoding encode = null)
    {
        try
        {
            var base64 = CsharpLazycode.Module.base64.Util.String2base64(str, encode);
            base64 = CsharpLazycode.Module.base64.Util.AfterDecode(base64);
            return base64;
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return "";
    }

    public static string Base64ToDeString(this string str, System.Text.Encoding encode = null)
    {
        try
        {
            return CsharpLazycode.Module.base64.Util.Base64ToString(str, encode);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return "";
    }

    /// <summary>
    /// 可传入默认值 发生异常返回默认值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="defaultvalue"></param>
    /// <returns></returns>
    public static T GetMemoryCacheDefault<T>(this string key, T defaultvalue = default)
    {

        var cache = System.Runtime.Caching.MemoryCache.Default;
        try
        {

            return (T)cache[key];
        }
        catch (Exception)
        {

            return defaultvalue;
        }
    }

    public static void SetMemoryCacheDefault(this string key, object obj, int seconds = 7200)
    {
        try
        {
            var cache = System.Runtime.Caching.MemoryCache.Default;

            var policy = new System.Runtime.Caching.CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(seconds)
            };

            cache.Set(key, obj, policy);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }




    }

    public static void RemoveMemoryCacheDefault(this string key)
    {
        try
        {
            System.Runtime.Caching.MemoryCache.Default.Remove(key);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }



    }

    public static bool DirectoryExists(this string path)
    {
        try
        {
            return Directory.Exists(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return false;
    }
    public static bool FileExists(this string path)
    {
        try
        {
            return File.Exists(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return false;
    }

    public static bool CreateDirectory(this string path)
    {
        try
        {
            if (false == System.IO.Directory.Exists(path))
            {
                var dir = System.IO.Directory.CreateDirectory(path);
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return false;
    }

    public static void ClearFolder(this string path)
    {
        try
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (FileInfo fi in dir.GetFiles())
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception) { } // Ignore all exceptions
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                try
                {
                    di.Delete();
                }
                catch (Exception) { } // Ignore all exceptions
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }



    }

    public static string GetFolderName(this string path)
    {
        try
        {
            var pathroot = new System.IO.DirectoryInfo(path);
            return pathroot.Name;
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return "";
    }

    public static List<string> EnumFolderPath(this string path)
    {
        var Items = new List<string>();
        try
        {
            var directoryInfo = new System.IO.DirectoryInfo(path);
            var getDirectories = directoryInfo.GetDirectories();
            for (int i = 0; i < getDirectories.Count(); i++)
            {
                var item = getDirectories[i];

                Items.Add(item.FullName);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return Items;
    }
    public static List<string> EnumFolderPath(this string path, string ContainsCondition, bool caseSensitive = false)
    {
        var Items = new List<string>();
        try
        {
            var directoryInfo = new System.IO.DirectoryInfo(path);
            var getDirectories = directoryInfo.GetDirectories();
            for (int i = 0; i < getDirectories.Count(); i++)
            {
                var item = getDirectories[i];
                var mark = false;
                if (caseSensitive == true)
                {
                    mark = item.FullName.Contains(ContainsCondition);
                }
                else
                {
                    mark = item.FullName.ContainsCase(ContainsCondition);
                }

                if (mark == true)
                {
                    Items.Add(item.FullName);
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
        return Items;
    }

    public static void DirectoryCopySingle(this string sourceDirName, string destDirName, bool copySubDirs)
    {

        try
        {

            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopySingle(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }




    }

    public static void DirectoryCopyParallel(this string sourceDirName, string destDirName, bool copySubDirs, int CopyFileMaxDegreeOfParallelism = 10, int copySubDirsMaxDegreeOfParallelism = 10)
    {

        try
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();

            Parallel.For(0, files.Length, new ParallelOptions() { MaxDegreeOfParallelism = CopyFileMaxDegreeOfParallelism }, (i, loopState) =>
            {
                var file = files[i];
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            });

            //foreach (FileInfo file in files)
            //{
            //    string temppath = Path.Combine(destDirName, file.Name);
            //    file.CopyTo(temppath, false);
            //}

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                Parallel.For(0, dirs.Length, new ParallelOptions() { MaxDegreeOfParallelism = copySubDirsMaxDegreeOfParallelism }, (i, loopState) =>
                {
                    var subdir = dirs[i];
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopySingle(subdir.FullName, temppath, copySubDirs);
                });

                //foreach (DirectoryInfo subdir in dirs)
                //{
                //    string temppath = Path.Combine(destDirName, subdir.Name);
                //    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                //}

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }




    }

    public static List<string> EnumFilePath(this string dirpath, string fileExtension = "*")
    {
        var items = new List<string>();
        DirectoryInfo TheFolder = new DirectoryInfo(dirpath);
        var FileInfos = TheFolder.GetFiles();
        for (int i = 0; i < FileInfos.Length; i++)
        {
            var a = FileInfos[i];

            if (fileExtension == "*")
            {
                items.Add(a.FullName);
            }
            else
            {
                if (Path.GetExtension(a.FullName).ToLower() == fileExtension.ToLower())
                {
                    items.Add(a.FullName);
                }
            }


        }

        return items;
    }

    public static bool ContainsCase(this string source, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
    {
        return source.IndexOf(toCheck, comp) >= 0;
    }

    public static void SaveDocument(this string path, string content, System.Text.Encoding encoding = null)
    {
        if (encoding == null) { encoding = System.Text.Encoding.UTF8; }
        try
        {
            System.IO.File.WriteAllText(path, content, encoding);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }
    }
    public async static void SaveDocumentAsync(this string path, string content, System.Text.Encoding encoding = null)
    {
        await Task.Run(() =>
      {
          if (encoding == null) { encoding = System.Text.Encoding.UTF8; }
          try
          {
              System.IO.File.WriteAllText(path, content, encoding);
          }
          catch (Exception ex)
          {
              Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
          }
          finally
          {
          }

          return;
      });

    }

    public static string ReadDocument(this string path, System.Text.Encoding encoding = null)
    {
        string content = "";
        if (encoding == null) { encoding = System.Text.Encoding.UTF8; }
        try
        {
            content = System.IO.File.ReadAllText(path, encoding);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format("异常[{0}]:{1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, ex.Message));
        }
        finally
        {
        }

        return content;

    }

    public async static Task<string> ReadDocumentAsync(this string path, System.Text.Encoding encoding = null)
    {
        return await Task.Run(() =>
        {
            return path.ReadDocument(encoding);
        });


    }

    public static string ToWindowsStyle(this string pathstr)
    {
        var a = pathstr;
        a = a.Replace("/", @"\");
        a = a.Replace(@"\\", @"\");
        return a;
    }

    public static string FilterCharNotIncludeUnderline(this string inputValue)
    {
        return Regex.Replace(inputValue, @"\W", "");
    }

    //static string GetFileNameFromUrl(string url)
    //{
    //    Uri uri;
    //    if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
    //        uri = new Uri(SomeBaseUri, url);

    //    return Path.GetFileName(uri.LocalPath);
    //}

    //字符串替换第一次
    public static string StringRemoveInsertFirstTime(this string lon, string oldChar, string newChar)
    {
        //第一次出现的位置
        int a = lon.IndexOf(oldChar);

        if (a != -1)
        {
            lon = lon.Remove(a, oldChar.Length).Insert(a, newChar);
        }

        return lon;
    }

    //字符串替换最后一次出现的匹配项
    public static string StringRemoveInsertLastTime(this string lon, string oldChar, string newChar)
    {
        //第一次出现的位置
        int a = lon.LastIndexOf(oldChar);

        if (a != -1)
        {
            lon = lon.Remove(a, oldChar.Length).Insert(a, newChar);
        }

        return lon;
    }

    //替换
    public static string ReplaceWithStringBuilder(this string value, IEnumerable<Tuple<string, string>> toReplace)
    {
        var result = new StringBuilder(value);
        foreach (var item in toReplace)
        {
            result.Replace(item.Item1, item.Item2);
        }
        return result.ToString();
    }

    //替换
    public static string HtmlYasuo(this string value)
    {
        IEnumerable<Tuple<string, string>> toReplace = new[]{
           Tuple.Create("\r\n", String.Empty),
              Tuple.Create("\r\n", String.Empty),

       };
        var result = new StringBuilder(value);
        foreach (var item in toReplace)
        {
            result.Replace(item.Item1, item.Item2);
        }
        return result.ToString();
    } 

    public delegate string ChangeEveryTimesNewwordDelegate();

    //同个关键词每次替换不同
    public static string ReplaceEveryTimeDifferentWithStringBuilder(this string str, string oldStr, ChangeEveryTimesNewwordDelegate newwordDelegate)
    {
        string newStr; 
      
        //Console.WriteLine("将字符串中的{0}替换成{1}···", oldStr, newStr);
        StringBuilder strBuffer = new StringBuilder();
        int start = 0;
        int tail = 0;

        //一旦找不到需要替换的字符串(第一次IndexOf返回-1)
        //就说明没有该关键字符串，可以直接返回之前的字符串
        if (str.IndexOf(oldStr) == -1)
        {
            //Console.WriteLine("没有找到需要替换的关键字符串!");
            return str;
        }

        //每次都不断循环，查找这个x
        //一旦找到了，就把它之前和上一个x之后的字符串拼接起来
        while (true)
        {
            start = str.IndexOf(oldStr, start);
            if (start == -1)
            {
                break;
            }
            strBuffer.Append(str.Substring(tail, start - tail));
            newStr = newwordDelegate();
            strBuffer.Append(newStr);
            start += oldStr.Length;
            tail = start;
        }

        //查找到最后一个位置之后
        //还要把剩下的字符串拼接进去
        strBuffer.Append(str.Substring(tail));
        return strBuffer.ToString();
    }

    //同个关键词每次替换不同
    public static string ReplaceEveryTimeDifferentWithRegex(this string str, string oldStr, ChangeEveryTimesNewwordDelegate newwordDelegate)
    {
        string newStr;
        while (str.IndexOf(oldStr) > 0)
        {
            Regex regex = new Regex(oldStr);//要替换字符串
            newStr = newwordDelegate();
            str = regex.Replace(str, newStr, 1);//最后一个参数是替换的次数 
        }
        return str;
    }


}

