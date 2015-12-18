using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Tip86
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var parallelExceptions = new ConcurrentQueue<Exception>();
                Parallel.For(0, 1, (i) =>
                {
                    try
                    {
                        throw new InvalidOperationException("并行任务中出现的异常");
                    }
                    catch (Exception e)
                    {
                        parallelExceptions.Enqueue(e);
                    }
                    if (parallelExceptions.Count > 0)
                        throw new AggregateException(parallelExceptions);
                });
            }
            catch (AggregateException err)
            {
                foreach (Exception item in err.InnerExceptions)
                {
                    Console.WriteLine("异常类型：{0}{1}来自于：{2}{3}异常内容：{4}", item.InnerException.GetType(), Environment.NewLine, item.InnerException.Source, Environment.NewLine, item.InnerException.Message);
                }
            }
            Console.WriteLine("主线程马上结束");
            Console.ReadKey();
        }

    }
}
