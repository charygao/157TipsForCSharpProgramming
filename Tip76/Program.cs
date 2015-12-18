using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tip76
{
    class Program
    {
        static void Main(string[] args)
        {
            long t1Num = 0;
            long t2Num = 0;
            CancellationTokenSource cts = new CancellationTokenSource();

            Thread t1 = new Thread(() =>
            {
                while (true && !cts.Token.IsCancellationRequested)
                {
                    t1Num++;
                }
            });
            t1.IsBackground = true;
            t1.Priority = ThreadPriority.Highest;
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                while (true && !cts.Token.IsCancellationRequested)
                {
                    t2Num++;
                }
            });
            t2.IsBackground = true;
            t2.Start();

            Console.ReadLine();
            //停止线程
            cts.Cancel();
            Console.WriteLine("t1Num:" + t1Num.ToString());
            Console.WriteLine("t2Num:" + t2Num.ToString());
        }

    }
}
