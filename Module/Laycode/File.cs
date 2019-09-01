using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.Laycode.file
{
    public class Util
    {
        //读取txt文件中总行数的方法
        public static int requestMethod(String _fileName)
        {
            Stopwatch sw = new Stopwatch();
            var path = _fileName;
            int lines = 0;

            //按行读取
            sw.Restart();
            using (var sr = new StreamReader(path))
            {
                var ls = "";
                while ((ls = sr.ReadLine()) != null)
                {
                    lines++;
                }
            }
            sw.Stop();
            return lines;
        }
        //性能差
        public static int TextfileLineCount(string path)
        {
            var lineCount = 0;
            using (var reader = System.IO.File.OpenText(path))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            return lineCount;
        }
        //性能差
        public static string TextfileGetRandoneLine(string path)
        {
            var lineCount = TextfileLineCount(path);
            var rid = CsharpLazycode.Module.Laycode.random.Next(1, lineCount);

            using (var reader = System.IO.File.OpenText(path))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    lineCount++;
                    if (lineCount == rid) { return line; }
                    line = reader.ReadLine();
                }
            }
            return "";
        }
          
    }
}
