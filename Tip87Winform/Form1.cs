using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Tip87Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void buttonStartAsync_Click(object sender, EventArgs e)
        //{
        //    Task t = new Task(() =>
        //    {
        //        while (true)
        //        {
        //            label1.Text = DateTime.Now.ToString();
        //            Thread.Sleep(1000);
        //        }
        //        //while (true)
        //        //{
        //        //    if (label1.InvokeRequired)
        //        //        label1.BeginInvoke(new Action(() =>
        //        //        {
        //        //            label1.Text = DateTime.Now.ToString();
        //        //        }));
        //        //    else
        //        //        label1.Text = DateTime.Now.ToString();
        //        //    Thread.Sleep(1000);
        //        //}

        //    });
        //    //如果有异常，就启动一个新任务
        //    t.ContinueWith((task) =>
        //    {
        //        try
        //        {
        //            task.Wait();
        //        }
        //        catch (AggregateException ex)
        //        {
        //            foreach (Exception inner in ex.InnerExceptions)
        //            {
        //                MessageBox.Show(string.Format("异常类型：{0}{1}来自于：{2}{3}异常内容：{4}", inner.GetType(), Environment.NewLine, inner.Source, Environment.NewLine, inner.Message));
        //            }
        //        }
        //    }, TaskContinuationOptions.OnlyOnFaulted);
        //    t.Start();
        //}

        //用于表示主线程，在本例中就是UI线程
        Thread mainThread;

        bool CheckAccess()
        {
            return mainThread == Thread.CurrentThread;
        }

        void VerifyAccess()
        {
            if (!CheckAccess())
                throw new InvalidOperationException("调用线程无法访问此对象，因为另一个线程拥有此对象");
        }

        private void buttonStartAsync_Click(object sender, EventArgs e)
        {
            //当前线程就是主线程
            mainThread = Thread.CurrentThread;
            Task t = new Task(() =>
            {
                while (true)
                {
                    if (!CheckAccess())
                        label1.BeginInvoke(new Action(() =>
                        {
                            label1.Text = DateTime.Now.ToString();
                        }));
                    else
                        label1.Text = DateTime.Now.ToString();
                    Thread.Sleep(1000);
                }
            });
            //如果有异常，就启动一个新任务
            t.ContinueWith((task) =>
            {
                try
                {
                    task.Wait();
                }
                catch (AggregateException ex)
                {
                    foreach (Exception inner in ex.InnerExceptions)
                    {
                        MessageBox.Show(string.Format("异常类型：{0}{1}来自于：{2}{3}异常内容：{4}", inner.GetType(), Environment.NewLine, inner.Source, Environment.NewLine, inner.Message));
                    }
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            t.Start();
        }

    }
}
