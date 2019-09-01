using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CsharpLazycode.Module.Laycode
{
    public class INIFile
    {
        public string inipath;

        [DllImport("kernel32")] public static extern bool WritePrivateProfileString(byte[] section, byte[] key, byte[] val, string filePath);
        [DllImport("kernel32")] public static extern int GetPrivateProfileString(byte[] section, byte[] key, byte[] def, byte[] retVal, int size, string filePath);

        public INIFile(string INIPath)
        {
            inipath = INIPath;
        }

        //与ini交互必须统一编码格式
        private static byte[] getBytes(string s, string encodingName)
        {
            return null == s ? null : System.Text.Encoding.GetEncoding(encodingName).GetBytes(s);
        }
        public string ReadString(string section, string key, string def, string encodingName = "utf-8", int size = 1024)
        {
            byte[] buffer = new byte[size];
            int count = GetPrivateProfileString(getBytes(section, encodingName), getBytes(key, encodingName), getBytes(def, encodingName), buffer, size, inipath);
            return System.Text.Encoding.GetEncoding(encodingName).GetString(buffer, 0, count).Trim();
        }
        public bool WriteString(string section, string key, string value, string encodingName = "utf-8")
        {
            return WritePrivateProfileString(getBytes(section, encodingName), getBytes(key, encodingName), getBytes(value, encodingName), inipath);
        }
    }
    public class INIFileDefault
    {
        public string inipath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]

        private static extern int GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);

        public INIFileDefault(string INIPath)
        {
            inipath = INIPath;
        }

        public void IniWriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, inipath);
        }

        public string IniReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(500);
            int length = GetPrivateProfileString(section, key, "", temp, 500, inipath);
            return temp.ToString();
        }

    }


}



