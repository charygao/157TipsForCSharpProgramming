using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tip85
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Task t = new Task(() =>
        //    {
        //        throw new Exception("任务并行编码中产生的未知异常");
        //    });
        //    t.Start();

        //    try
        //    {
        //        //若有Result，可求Result
        //        t.Wait();
        //    }
        //    catch (AggregateException e)
        //    {
        //        foreach (var item in e.InnerExceptions)
        //        {
        //            Console.WriteLine("异常类型：{0}{1}来自于：{2}{3}异常内容：{4}", item.GetType(), Environment.NewLine, item.Source, Environment.NewLine, item.Message);
        //        }
        //    }
        //    Console.WriteLine("主线程马上结束");
        //    Console.ReadKey();
        //}

        //static void Main()
        //{
        //    Task t = new Task(() =>
        //    {
        //        throw new Exception("任务并行编码中产生的未知异常");
        //    });
        //    t.Start();
        //    Task tEnd = t.ContinueWith((task) =>
        //    {
        //        foreach (Exception item in task.Exception.InnerExceptions)
        //        {
        //            Console.WriteLine("异常类型：{0}{1}来自于：{2}{3}异常内容：{4}", item.GetType(), Environment.NewLine, item.Source, Environment.NewLine, item.Message);
        //        }
        //    }, TaskContinuationOptions.OnlyOnFaulted);

        //    Console.WriteLine("主线程马上结束");
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    Task t = new Task(() =>
        //    {
        //        throw new InvalidOperationException("任务并行编码中产生的未知异常");
        //    });
        //    t.Start();
        //    Task tEnd = t.ContinueWith((task) =>
        //    {
        //        throw task.Exception;
        //    }, TaskContinuationOptions.OnlyOnFaulted);
        //    try
        //    {
        //        tEnd.Wait();
        //    }
        //    catch (AggregateException err)
        //    {
        //        foreach (var item in err.InnerExceptions)
        //        {
        //            Console.WriteLine("异常类型：{0}{1}来自于：{2}{3}异常内容：{4}", item.InnerException.GetType(), Environment.NewLine, item.InnerException.Source, Environment.NewLine, item.InnerException.Message);
        //        }
        //    }
        //    Console.WriteLine("主线程马上结束");
        //    Console.ReadKey();
        //}

        //static event EventHandler<AggregateExceptionArgs> AggregateExceptionCatched;

        //public class AggregateExceptionArgs : EventArgs
        //{
        //    public AggregateException AggregateException { get; set; }
        //}

        //static void Main(string[] args)
        //{
        //    AggregateExceptionCatched += new EventHandler<AggregateExceptionArgs>(Program_AggregateExceptionCatched);
        //    Task t = new Task(() =>
        //    {
        //        try
        //        {
        //            throw new InvalidOperationException("任务并行编码中产生的未知异常");
        //        }
        //        catch (Exception err)
        //        {
        //            AggregateExceptionArgs errArgs = new AggregateExceptionArgs() { AggregateException = new AggregateException(err) };
        //            AggregateExceptionCatched(null, errArgs);
        //        }
        //    });
        //    t.Start();

        //    Console.WriteLine("主线程马上结束");
        //    Console.ReadKey();

        //}

        //static void Program_AggregateExceptionCatched(object sender, AggregateExceptionArgs e)
        //{
        //    foreach (var item in e.AggregateException.InnerExceptions)
        //    {
        //        Console.WriteLine("异常类型：{0}{1}来自于：{2}{3}异常内容：{4}", item.GetType(), Environment.NewLine, item.Source, Environment.NewLine, item.Message);
        //    }
        //}

        static void Main()
        {
            TaskScheduler.UnobservedTaskException += new EventHandler<UnobservedTaskExceptionEventArgs>(TaskScheduler_UnobservedTaskException);
            Task t = new Task(() =>
            {
                throw new Exception("任务并行编码中产生的未知异常");
            });
            t.Start();
            Console.ReadKey();
            t.Dispose();
            t = null;
            //GC.Collect(0);
            Console.WriteLine("主线程马上结束");
            Console.ReadKey();
        }

        static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            foreach (Exception item in e.Exception.InnerExceptions)
            {
                Console.WriteLine("异常类型：{0}{1}来自于：{2}{3}异常内容：{4}", item.GetType(), Environment.NewLine, item.Source, Environment.NewLine, item.Message);
            }
            //将异常标识为已经观察到
            e.SetObserved();
        }

    }
}
