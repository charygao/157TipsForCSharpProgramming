using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tip83
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
            string[] stringArr = new string[] { "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh" };
            string result = string.Empty;
            Parallel.For<string>(0, stringArr.Length, () => "-", (i, loopState, subResult) =>
            {
                return subResult += stringArr[i];
            }, (threadEndString) =>
            {
                result += threadEndString;
                Console.WriteLine("Inner:" + threadEndString);
            });
            Console.WriteLine(result);
            Console.ReadKey();
        }


    }
}
