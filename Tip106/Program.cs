using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tip106
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass.SampleMethod();
            Console.ReadKey();

        }
    }

    static class SampleClass
    {
        static FileStream fileStream;

        static SampleClass()
        {
            try
            {
                fileStream = File.Open(@"c:\temp.txt", FileMode.Open);
            }
            catch (FileNotFoundException err)
            {
                Console.WriteLine(err.Message);
                //处理异常
            }
        }

        public static void SampleMethod()
        { }
    }

}
