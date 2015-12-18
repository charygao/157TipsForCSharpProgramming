using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Tip116
{
    class Program
    {
        static void Main()
        {
            EncryptFile(@"c:\temp.txt", @"c:\tempcm.txt", "123");
            Console.WriteLine("加密成功！");
            DecryptFile(@"c:\tempcm.txt", @"c:\tempm.txt", "123");
            Console.WriteLine("解密成功！");
        }

        //缓冲区大小
        static int bufferSize = 128 * 1024;
        //密钥salt
        static byte[] salt = { 134, 216, 7, 36, 88, 164, 91, 227, 174, 76, 191, 197, 192, 154, 200, 248 };
        //初始化向量
        static byte[] iv = { 134, 216, 7, 36, 88, 164, 91, 227, 174, 76, 191, 197, 192, 154, 200, 248 };

        //初始化并返回对称加密算法
        static SymmetricAlgorithm CreateRijndael(string password, byte[] salt)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt, "SHA256", 1000);
            SymmetricAlgorithm sma = Rijndael.Create();
            sma.KeySize = 256;
            sma.Key = pdb.GetBytes(32);
            sma.Padding = PaddingMode.PKCS7;
            return sma;
        }

        static void EncryptFile(string inFile, string outFile, string password)
        {
            using (FileStream inFileStream = File.OpenRead(inFile), outFileStream = File.Open(outFile, FileMode.OpenOrCreate))
            using (SymmetricAlgorithm algorithm = CreateRijndael(password, salt))
            {
                algorithm.IV = iv;
                using (CryptoStream cryptoStream = new CryptoStream(outFileStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] bytes = new byte[bufferSize];
                    int readSize = -1;
                    while ((readSize = inFileStream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        cryptoStream.Write(bytes, 0, readSize);
                    }
                    cryptoStream.Flush();
                }
            }
        }

        static void DecryptFile(string inFile, string outFile, string password)
        {
            using (FileStream inFileStream = File.OpenRead(inFile), outFileStream = File.OpenWrite(outFile))
            using (SymmetricAlgorithm algorithm = CreateRijndael(password, salt))
            {
                algorithm.IV = iv;
                using (CryptoStream cryptoStream = new CryptoStream(inFileStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] bytes = new byte[bufferSize];
                    int readSize = -1;
                    int numReads = (int)(inFileStream.Length / bufferSize);
                    int slack = (int)(inFileStream.Length % bufferSize);
                    for (int i = 0; i < numReads; ++i)
                    {
                        readSize = cryptoStream.Read(bytes, 0, bytes.Length);
                        outFileStream.Write(bytes, 0, readSize);
                    }
                    if (slack > 0)
                    {
                        readSize = cryptoStream.Read(bytes, 0, (int)slack);
                        outFileStream.Write(bytes, 0, readSize);
                    }
                    outFileStream.Flush();
                }
            }
        }

    }
}
