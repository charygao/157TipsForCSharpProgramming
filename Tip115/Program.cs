using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Tip115
{
    class Program
    {
        static void Main()
        {
            string fileHash = GetFileHash(@"C:\temp.txt");
            Console.WriteLine("文件MD5-HASH值为：{0}", fileHash);
        }

        public static string GetFileHash(string filePath)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return BitConverter.ToString(md5.ComputeHash(fs)).Replace("-", "");
            }
        }

    }
}
