using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Tip73
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       AutoResetEvent autoSet = new AutoResetEvent(false);
        List<string> tempList = new List<string>() { "init0", "init1", "init2" };

        private void buttonStartThreads_Click(object sender, EventArgs e)
        {
            object syncObj = new object();

            Thread t1 = new Thread(() =>
            {
                //确保等待t2开始之后才运行下面的代码
                autoSet.WaitOne();
                lock (syncObj)
                {
                    foreach (var item in tempList)
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
            t1.IsBackground = true;
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                //通知t1可以执行代码
                autoSet.Set();
                //沉睡1秒是为了确保删除操作在t1的迭代过程中
                Thread.Sleep(1000);
                lock (syncObj)
                {
                    tempList.RemoveAt(1);
                }
            });
            t2.IsBackground = true;
            t2.Start();
        }

        //private void buttonStartThreads_Click(object sender, EventArgs e)
        //{
        //    SampleClass sample1 = new SampleClass();
        //    SampleClass sample2 = new SampleClass();
        //    sample1.StartT1();
        //    sample2.StartT2();
        //}

        //class SampleClass
        //{
        //    public static List<string> TempList = new List<string>() { "init0", "init1", "init2" };
        //    static AutoResetEvent autoSet = new AutoResetEvent(false);
        //    object syncObj = new object();

        //    public void StartT1()
        //    {
        //        Thread t1 = new Thread(() =>
        //        {
        //            //确保等待t2开始之后才运行下面的代码
        //            autoSet.WaitOne();
        //            lock (syncObj)
        //            {
        //                foreach (var item in TempList)
        //                {
        //                    Thread.Sleep(1000);
        //                }
        //            }
        //        });
        //        t1.IsBackground = true;
        //        t1.Start();
        //    }

        //    public void StartT2()
        //    {
        //        Thread t2 = new Thread(() =>
        //        {
        //            //通知t1可以执行代码
        //            autoSet.Set();
        //            //沉睡1秒是为了确保删除操作在t1的迭代过程中
        //            Thread.Sleep(1000);
        //            lock (syncObj)
        //            {
        //                TempList.RemoveAt(1);
        //            }
        //        });
        //        t2.IsBackground = true;
        //        t2.Start();
        //    }
        //}


    }
}
