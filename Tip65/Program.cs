using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip65
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = (Exception)e.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + error.Message);
        }

    }

    #region 以下为winform
        //    [STAThread]
        //static void Main()
        //{
        //    Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);
        //    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        //    AppDomain.CurrentDomain.UnhandledException +=
        //        new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        //    Application.Run(new ErrorHandlerForm());

        //}

        //private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        //{
        //    try
        //    {
        //        string errorMsg = "Windows窗体线程异常 : \n\n";
        //        MessageBox.Show(errorMsg + t.Exception.Message + Environment.NewLine + t.Exception.StackTrace);
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            MessageBox.Show("不可恢复的Windows窗体异常，应用程序将退出！");
        //        }
        //        finally
        //        {
        //            Application.Exit();
        //        }
        //    }
        //}

        //private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    try
        //    {
        //        Exception ex = (Exception)e.ExceptionObject;
        //        string errorMsg = "非窗体线程异常 : \n\n";
        //        MessageBox.Show(errorMsg + ex.Message + Environment.NewLine + ex.StackTrace);
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            MessageBox.Show("不可恢复的非Windows窗体线程异常，应用程序将退出！");
        //        }
        //        finally
        //        {
        //            Application.Exit();
        //        }
        //    }
        //}

    #endregion

    #region 以下为WPF
    //public App()
    //    {
    //        this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(Application_DispatcherUnhandledException);
    //        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
    //    }

    //    void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    //    {
    //        try
    //        {
    //            Exception ex = e.ExceptionObject as Exception;
    //            string errorMsg = "非WPF窗体线程异常 : \n\n";
    //            MessageBox.Show(errorMsg + ex.Message + Environment.NewLine + ex.StackTrace);
    //        }
    //        catch
    //        {
    //            try
    //            {
    //                MessageBox.Show("不可恢复的WPF窗体线程异常，应用程序将退出！");
    //            }
    //            finally
    //            {
    //                Application.Current.Shutdown();
    //            }
    //        }
    //    }

    //    private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    //    {
    //        try
    //        {
    //            Exception ex = e.Exception;
    //            string errorMsg = "WPF窗体线程异常 : \n\n";
    //            MessageBox.Show(errorMsg + ex.Message + Environment.NewLine + ex.StackTrace);
    //        }
    //        catch
    //        {
    //            try
    //            {
    //                MessageBox.Show("不可恢复的WPF窗体线程异常，应用程序将退出！");
    //            }
    //            finally
    //            {
    //                Application.Current.Shutdown();
    //            }
    //        } 
    //        e.Handled = true;
    //    }

    #endregion

}
