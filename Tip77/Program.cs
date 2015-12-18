using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tip77
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("线程被终止！");
                        break;
                    }
                    Console.WriteLine(DateTime.Now.ToString());
                    Thread.Sleep(1000);
                }
            });
            t.Start();
            Console.ReadLine();
            cts.Cancel();

        }
    }
}
