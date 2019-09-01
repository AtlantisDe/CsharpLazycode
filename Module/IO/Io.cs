using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.IO
{
    public class Util
    {
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        public static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin); // 设置当前流的位置为流的开始
            return bytes;
        }

        //本方法不会自动关闭流,请自行关闭流
        [Obsolete]
        public static string StreamTostringEncodingDetector(Stream stream)
        {
            var bytebody = CsharpLazycode.Module.IO.Util.StreamToBytes(stream);
            var retString = "";
            if ((retString = System.Text.Encoding.UTF8.GetString(bytebody)).Contains("��") == false)
            {
                return retString;
            }
            else if ((retString = System.Text.Encoding.GetEncoding(936).GetString(bytebody)).Contains("") == false)
            {
                return retString;
            }
            else if ((retString = System.Text.Encoding.GetEncoding(950).GetString(bytebody)).Contains("��") == false)
            {
                return retString;
            }
            else if ((retString = System.Text.Encoding.Unicode.GetString(bytebody)).Contains("��") == false)
            {
                return retString;
            }
            else if ((retString = System.Text.Encoding.GetEncoding(52936).GetString(bytebody)).Contains("��") == false)
            {
                return retString;
            }
            else if ((retString = System.Text.Encoding.GetEncoding(54936).GetString(bytebody)).Contains("��") == false)
            {
                return retString;
            }

            return "";
        }


    }
}
