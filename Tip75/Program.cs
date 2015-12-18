using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tip75
{
    class Program
    {
        static int _id = 0;

        static void Main()
        {
            for (int i = 0; i < 10; i++, _id++)
            {
                Thread t = new Thread(() =>
                {
                    Console.WriteLine(string.Format("{0}:{1}", Thread.CurrentThread.Name, _id));
                });
                t.Name = string.Format("Thread{0}", i);
                t.IsBackground = true;
                t.Start();
            }
            Console.ReadLine();
        }

        //static int _id = 0;

        //static void Main()
        //{
        //    for (int i = 0; i < 10; i++, _id++)
        //    {
        //        NewMethod1(i, _id);
        //    }
        //    Console.ReadLine();
        //}

        //private static void NewMethod1(int i, int realTimeID)
        //{
        //    Thread t = new Thread(() =>
        //    {
        //        Console.WriteLine(string.Format("{0}:{1}", Thread.CurrentThread.Name, realTimeID));
        //    });
        //    t.Name = string.Format("Thread{0}", i);
        //    t.IsBackground = true;
        //    t.Start();
        //}


    }
}
