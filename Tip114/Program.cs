using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Tip114
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入密码，按回车键结束……");
            string source = Console.ReadLine();
            if (VerifyMd5Hash(source, "D3A8E4D76A0AEF23B65D9F6D6BCB358F"))
            {
                Console.WriteLine("密码正确，准许登录系统。");
            }
            else
            {
                Console.WriteLine("密码有误，拒绝登录。");
            }

            //Console.WriteLine("开始穷举法破解用户密码……");
            //string key = string.Empty;
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //for (int i = 0; i < 9999; i++)
            //{
            //    if (VerifyMd5Hash(i.ToString(), "CF79AE6ADDBA60AD018347359BD144D2"))
            //    {
            //        key = i.ToString();
            //        break;
            //    }
            //}
            //watch.Stop();
            //Console.WriteLine("密码已破解，为：{0}，耗时{1}毫秒。", key, watch.ElapsedMilliseconds);

        }

        static string GetMd5Hash(string input)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input))).Replace("-", "");
            }
        }

        //static string GetMd5Hash(string input)
        //{
        //    string hashKey = "Aa1@#$,.Klj+{>.45oP";
        //    using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        //    {
        //        string hashCode = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input))).Replace("-", "") + BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(hashKey))).Replace("-", "");
        //        return BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(hashCode))).Replace("-", "");
        //    }
        //}


        static bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = GetMd5Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0 ? true : false;
        }


    }
}
