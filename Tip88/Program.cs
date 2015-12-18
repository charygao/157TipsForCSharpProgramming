using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Tip88
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            DoInFor();
            watch.Stop();
            Console.WriteLine("同步耗时：{0}", watch.Elapsed);

            watch.Restart();
            DoInParalleFor();
            watch.Stop();
            Console.WriteLine("并行耗时：{0}", watch.Elapsed);

            Console.ReadKey();
        }

        static void DoSomething()
        {
            for (int i = 0; i < 10; i++)
            {
                i++;
            }
        }

        static void DoInFor()
        {
            for (int i = 0; i < 200; i++)
            {
                DoSomething();
            }
        }

        static void DoInParalleFor()
        {
            Parallel.For(0, 200, (i) =>
            {
                DoSomething();
            });
        }

    }
}
