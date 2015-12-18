using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Tip4
{
    class Program
    {
        static void Main(string[] args)
        {
            double re;
            long ticks;

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            {
                try
                {
                    re = double.Parse("123");
                }
                catch
                {
                    re = 0;
                }
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            Console.WriteLine("double.Parse() 成功，{0} ticks", ticks);

            sw = Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            {
                if (double.TryParse("123", out re) == false)
                {
                    re = 0;
                }
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            Console.WriteLine("double.TryParse() 成功，{0} ticks", ticks);

            sw = Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            {
                try
                {
                    re = double.Parse("aaa");
                }
                catch
                {
                    re = 0;
                }
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            Console.WriteLine("double.Parse() 失败，{0} ticks", ticks);

            sw = Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            {
                if (double.TryParse("aaa", out re) == false)
                {
                    re = 0;
                }
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            Console.WriteLine("double.TryParse() 失败，{0} ticks", ticks);


            Console.Read();
        }
    }
}
