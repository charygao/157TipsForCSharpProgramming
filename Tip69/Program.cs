using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip69
{
    class Program
    {
        static void Main(string[] args)
        {
            Method3();
        }

        static void Method1()
        {
            ClassShouldDisposeBase c = null;
            try
            {
                c = new ClassShouldDisposeBase("Method1");
                Method2();
            }
            finally
            {
                c.Dispose();
            }

        }

        static void Method2()
        {
            ClassShouldDisposeBase c = null;
            try
            {
                c = new ClassShouldDisposeBase("Method2");
            }
            finally
            {
                c.Dispose();
            }
        }

        static void Method3()
        {
            ClassShouldDisposeBase c = null;
            try
            {
                c = new ClassShouldDisposeBase("Method3");
                Method4();
            }
            catch
            {
                Console.WriteLine("在Method3中捕获了异常。");
            }
            finally
            {
                c.Dispose();
            }

        }

        static void Method4()
        {
            ClassShouldDisposeBase c = null;
            try
            {
                c = new ClassShouldDisposeBase("Method4");
                throw new Exception();
            }
            catch
            {
                Console.WriteLine("在Method4中捕获了异常。");
                throw;
            }
            finally
            {
                c.Dispose();
            }
        }

    }

    class ClassShouldDisposeBase : IDisposable
    {
        string _methodName;
        public ClassShouldDisposeBase(string methodName)
        {
            _methodName = methodName;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine("在方法：" + _methodName + "中被释放！");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //执行基本的清理代码
            }
        }

        ~ClassShouldDisposeBase()
        {
            this.Dispose(false);
        }
    }

}
