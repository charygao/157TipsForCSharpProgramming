using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tip78
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 200; i++)
            {
                Thread t = new Thread(() =>
                {
                    int j = 1;
                    while (true)
                    {
                        j++;
                    }
                });
                t.IsBackground = true;
                t.Start();
            }
            Thread.Sleep(5000);
            Thread t201 = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("T201正在执行");
                }
            });
            t201.Start();
            Console.ReadKey();
        }

    }
}
