using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Tip49
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class DerivedSampleClass : SampleClass
    {
        //子类的非托管资源
        private IntPtr derivedNativeResource = Marshal.AllocHGlobal(100);
        //子类的托管资源
        private AnotherResource derivedManagedResource = new AnotherResource();
        //定义自己的是否释放的标识变量
        private bool derivedDisposed = false;

        /// <summary>
        /// 非密封类修饰用protected virtual
        /// 密封类修饰用private
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (derivedDisposed)
            {
                return;
            }
            if (disposing)
            {
                // 清理托管资源
                if (derivedManagedResource != null)
                {
                    derivedManagedResource.Dispose();
                    derivedManagedResource = null;
                }
            }
            // 清理非托管资源
            if (derivedNativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(derivedNativeResource);
                derivedNativeResource = IntPtr.Zero;
            }
            //调用父类的清理代码
            base.Dispose(disposing);
            //让类型知道自己已经被释放
            derivedDisposed = true;
        }
    }

    public class SampleClass : IDisposable
    {
        //演示创建一个非托管资源
        private IntPtr nativeResource = Marshal.AllocHGlobal(100);
        //演示创建一个托管资源
        private AnotherResource managedResource = new AnotherResource();
        private bool disposed = false;

        /// <summary>
        /// 实现IDisposable中的Dispose方法
        /// </summary>
        public void Dispose()
        {
            //必须为true
            Dispose(true);
            //通知垃圾回收机制不再调用终结器（析构器）
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 不是必要的，提供一个Close方法仅仅是为了更符合其他语言（如
        /// C++）的规范
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        /// <summary>
        /// 必须，防止程序员忘记了显式调用Dispose方法
        /// </summary>
        ~SampleClass()
        {
            //必须为false
            Dispose(false);
        }

        /// <summary>
        /// 非密封类修饰用protected virtual
        /// 密封类修饰用private
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                // 清理托管资源
                if (managedResource != null)
                {
                    managedResource.Dispose();
                    managedResource = null;
                }
            }
            // 清理非托管资源
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }
            //让类型知道自己已经被释放
            disposed = true;
        }

        public void SamplePublicMethod()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("SampleClass", "SampleClass is disposed");
            }
            //省略
        }
    }

    class AnotherResource : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
