using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Tip72
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        private void buttonStartAThread_Click(object sender, EventArgs e)
        {
            Thread tWork = new Thread(() =>
            {
                label1.Text = "线程启动..." + Environment.NewLine;
                label1.Text += "开始处理一些实际的工作" + Environment.NewLine;
                //省略工作代码
                label1.Text += "我开始等待别的线程给我信号，才愿意继续下去" + Environment.NewLine;
                autoResetEvent.WaitOne();
                label1.Text += "我继续做一些工作，然后结束了！";
                //省略工作代码
            });
            tWork.IsBackground = true;
            tWork.Start();

            //Thread tClient = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        //等3秒，3秒没有信号，显示断开
            //        //有信号，则显示更新
            //        bool re = autoResetEvent.WaitOne(3000);
            //        if (re)
            //        {
            //            label1.Text = string.Format("时间：{0}，{1}", DateTime.Now.ToString(), "保持连接状态");
            //        }
            //        else
            //        {
            //            label1.Text = string.Format("时间：{0}，{1}", DateTime.Now.ToString(), "断开，需要重启");
            //        }
            //    }
            //});
            //tClient.IsBackground = true;
            //tClient.Start();

        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            //给在autoResetEvent上等待的线程一个信号
            autoResetEvent.Set();
        }

        private void StartThread1()
        {
            Thread tWork1 = new Thread(() =>
            {
                label1.Text = "线程1启动..." + Environment.NewLine;
                label1.Text += "开始处理一些实际的工作" + Environment.NewLine;
                //省略工作代码
                label1.Text += "我开始等待别的线程给我信号，才愿意继续下去" + Environment.NewLine;
                autoResetEvent.WaitOne();
                label1.Text += "我继续做一些工作，然后结束了！";
                //省略工作代码
            });
            tWork1.IsBackground = true;
            tWork1.Start();
        }

        private void StartThread2()
        {
            Thread tWork2 = new Thread(() =>
            {
                label2.Text = "线程2启动..." + Environment.NewLine;
                label2.Text += "开始处理一些实际的工作" + Environment.NewLine;
                //省略工作代码
                label2.Text += "我开始等待别的线程给我信号，才愿意继续下去" + Environment.NewLine;
                autoResetEvent.WaitOne();
                label2.Text += "我继续做一些工作，然后结束了！";
                //省略工作代码
            });
            tWork2.IsBackground = true;
            tWork2.Start();
        }

    }
}
