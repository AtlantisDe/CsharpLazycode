using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpLazycode.Module.encode
{
    public class Main
    {
        public class Enum
        {
            public enum logitemStates
            {
                normal = 0,
                error = 1,
                unknown = 404
            }
        }

        public class Methods
        {

            public static System.Text.Encoding GetFileEncodeType(string filename)
            {
                System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] buffer = br.ReadBytes(2);
                if (buffer[0] >= 0xEF)
                {
                    if (buffer[0] == 0xEF && buffer[1] == 0xBB)
                    {
                        return System.Text.Encoding.UTF8;
                    }
                    else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
                    {
                        return System.Text.Encoding.BigEndianUnicode;
                    }
                    else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
                    {
                        return System.Text.Encoding.Unicode;
                    }
                    else
                    {
                        return System.Text.Encoding.Default;
                    }
                }
                else
                {
                    return System.Text.Encoding.Default;
                }
            }



        }

    }
    public class Util
    {
        public static System.Text.Encoding GB2312
        {
            get { return System.Text.Encoding.GetEncoding(936); }
        }
        public static System.Text.Encoding UTF8
        {
            get { return System.Text.Encoding.UTF8; }
        }


    }
}
