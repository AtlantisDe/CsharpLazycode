using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Laycode.directory
{
    public class Util
    {
        public static List<string> GetDirectorieslststr(string folderFullName)
        {
            var lst = new List<string>();
            DirectoryInfo TheFolder = new DirectoryInfo(folderFullName);
            var lstd = TheFolder.GetDirectories();
            for (int i = 0; i < lstd.Count(); i++)
            {
                var aa = lstd[i];
                lst.Add(aa.FullName);
            }

            return lst;
        }

        public static DirectoryInfo[] GetDirectories(string folderFullName)
        {
            var lst = new List<string>();
            DirectoryInfo TheFolder = new DirectoryInfo(folderFullName);
            return TheFolder.GetDirectories();


        }


        //实现复制文件夹中文件到另一个文件夹的方法
        public static bool CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加
                if (aimPath[aimPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                {
                    aimPath += System.IO.Path.DirectorySeparatorChar;
                }
                // 判断目标目录是否存在如果不存在则新建
                if (!System.IO.Directory.Exists(aimPath))
                {
                    System.IO.Directory.CreateDirectory(aimPath);
                }
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（srcPath）；
                string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                    if (System.IO.Directory.Exists(file))
                    {
                        CopyDir(file, aimPath + System.IO.Path.GetFileName(file));
                    }
                    // 否则直接Copy文件
                    else
                    {
                        System.IO.File.Copy(file, aimPath + System.IO.Path.GetFileName(file), true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("异常[{0}] [{1}]:{2}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            }

            return true;
        }


        /// <summary>
                /// 将一个文件夹下的所有东西复制到另一个文件夹 (可备份文件夹)
                /// </summary>
                /// <param name="sourceDire">源文件夹全名</param>
                /// <param name="destDire">目标文件夹全名</param>
                /// <param name="backupsDire">备份文件夹全名</param>
        public void CopyDireToDire(string sourceDire, string destDire, string backupsDire = null)
        {
            if (Directory.Exists(sourceDire) && Directory.Exists(destDire))
            {
                DirectoryInfo sourceDireInfo = new DirectoryInfo(sourceDire);
                FileInfo[] fileInfos = sourceDireInfo.GetFiles();
                foreach (FileInfo fInfo in fileInfos)
                {
                    string sourceFile = fInfo.FullName;
                    string destFile = sourceFile.Replace(sourceDire, destDire);
                    if (backupsDire != null && File.Exists(destFile))
                    {
                        Directory.CreateDirectory(backupsDire);
                        string backFile = destFile.Replace(destDire, backupsDire);
                        File.Copy(destFile, backFile, true);
                    }
                    File.Copy(sourceFile, destFile, true);
                }
                DirectoryInfo[] direInfos = sourceDireInfo.GetDirectories();
                foreach (DirectoryInfo dInfo in direInfos)
                {
                    string sourceDire2 = dInfo.FullName;
                    string destDire2 = sourceDire2.Replace(sourceDire, destDire);
                    string backupsDire2 = null;
                    if (backupsDire != null)
                    {
                        backupsDire2 = sourceDire2.Replace(sourceDire, backupsDire);
                    }
                    Directory.CreateDirectory(destDire2);
                    CopyDireToDire(sourceDire2, destDire2, backupsDire2);
                }
            }
        }

    }
}
