using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Tip15
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = 1000000;
            DynamicSample reflectSample = new DynamicSample();
            var addMethod = typeof(DynamicSample).GetMethod("Add");
            Stopwatch watch1 = Stopwatch.StartNew();
            for (var i = 0; i < times; i++)
            {
                addMethod.Invoke(reflectSample, new object[] { 1, 2 });
            }
            Console.WriteLine(string.Format("反射耗时：{0} 毫秒", watch1.ElapsedMilliseconds));
            dynamic dynamicSample = new DynamicSample();
            Stopwatch watch2 = Stopwatch.StartNew();
            for (int i = 0; i < times; i++)
            {
                dynamicSample.Add(1, 2);
            }
            Console.WriteLine(string.Format("dynamic耗时：{0} 毫秒", watch2.ElapsedMilliseconds));

            DynamicSample reflectSampleBetter = new DynamicSample();
            var addMethod2 = typeof(DynamicSample).GetMethod("Add");
            var delg = (Func<DynamicSample, int, int, int>)Delegate.CreateDelegate(typeof(Func<DynamicSample, int, int, int>), addMethod2);
            Stopwatch watch3 = Stopwatch.StartNew();
            for (var i = 0; i < times; i++)
            {
                delg(reflectSampleBetter, 1, 2);
            }
            Console.WriteLine(string.Format("优化的反射耗时：{0} 毫秒", watch3.ElapsedMilliseconds));

            Console.Read();
        }
    }

    public class DynamicSample
    {
        public string Name { get; set; }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }

}
