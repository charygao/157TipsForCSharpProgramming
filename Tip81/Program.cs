using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tip81
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            Parallel.For(0, nums.Length, (i) =>
            {
                Console.WriteLine("针对数组索引{0}对应的那个元素{1}的一些工作代码……", i, nums[i]);
            });
            Console.ReadKey();
        }

        //static void Main(string[] args)
        //{
        //    List<int> nums = new List<int> { 1, 2, 3, 4 };
        //    Parallel.ForEach(nums, (item) =>
        //    {
        //        Console.WriteLine("针对集合元素{0}的一些工作代码……", item);
        //    });
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    Parallel.Invoke(() =>
        //    {
        //        Console.WriteLine("任务1……");
        //    },
        //        () =>
        //        {
        //            Console.WriteLine("任务2……");
        //        },
        //        () =>
        //        {
        //            Console.WriteLine("任务3……");
        //        });
        //    Console.ReadKey();
        //}

    }
}
