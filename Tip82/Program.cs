using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tip82
{
    class Program
    {
        static void Main()
        {
            Task t = new Task(() =>
            {
                while (true)
                {

                }
            });
            t.Start();
            Console.WriteLine("主线程即将结束");
            Console.ReadKey();
        }

        //static void Main()
        //{
        //    //在这里也可以使用Invoke方法
        //    Parallel.For(0, 1, (i) =>
        //    {
        //        while (true)
        //        {

        //        }
        //    });
        //    Console.WriteLine("主线程即将结束");
        //    Console.ReadKey();
        //}

    }
}
