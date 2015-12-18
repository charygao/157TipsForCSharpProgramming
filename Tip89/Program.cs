using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tip89
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    int[] nums = new int[] { 1, 2, 3, 4 };
        //    int total = 0;
        //    Parallel.For<int>(0, nums.Length, () =>
        //    {
        //        return 1;
        //    }, (i, loopState, subtotal) =>
        //    {
        //        subtotal += nums[i];
        //        return subtotal;
        //    },
        //        (x) => Interlocked.Add(ref total, x)
        //        );
        //    Console.WriteLine("total={0}", total);
        //    Console.ReadKey();
        //}
        static void Main(string[] args)
        {
            SampleClass sample = new SampleClass();
            Parallel.For(0, 10000000, (i) =>
            {
                sample.SimpleAdd();
            });
            //object syncObj = new object();
            //Parallel.For(0, 10000000, (i) =>
            //{
            //    lock (syncObj)
            //    {
            //        sample.SimpleAdd();
            //    }
            //});

            Console.WriteLine(sample.SomeCount);
        }

        class SampleClass
        {
            public long SomeCount { get; private set; }

            public void SimpleAdd()
            {
                SomeCount++;
            }
        }

    }
}
