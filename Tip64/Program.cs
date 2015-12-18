using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Tip64
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();
            int x = 0;
            for (int i = 0; i < 10000; i++)
            {
                try
                {
                    int j = i / x;
                }
                catch
                {
                }
            }
            Console.WriteLine(watch.ElapsedMilliseconds.ToString());

            watch = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                if (x == 0)
                {
                    continue;
                }
                int j = i / x;
            }
            Console.WriteLine(watch.ElapsedMilliseconds.ToString());
            Console.ReadKey();

        }
    }
}
