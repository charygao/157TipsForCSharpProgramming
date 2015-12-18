using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Tip66
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                Thread t = new Thread((ThreadStart)delegate
                {
                    throw new Exception("多线程异常");
                });
                t.Start();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + Environment.NewLine + error.StackTrace);
            }

            //Thread t = new Thread((ThreadStart)delegate
            //{
            //    try
            //    {
            //        throw new Exception("多线程异常");
            //    }
            //    catch (Exception error)
            //    {
            //        MessageBox.Show("工作线程异常：" + error.Message + Environment.NewLine + error.StackTrace);
            //    }
            //});
            //t.Start();

            //Thread t = new Thread((ThreadStart)delegate
            //{
            //    try
            //    {
            //        throw new Exception("非窗体线程异常");
            //    }
            //    catch (Exception ex)
            //    {
            //        this.BeginInvoke((Action)delegate
            //        {
            //            throw ex;
            //        });
            //    }
            //});
            //t.Start();

            //WPF中做法
            //Thread t = new Thread((ThreadStart)delegate
            //{
            //    try
            //    {
            //        throw new Exception("非窗体线程异常");
            //    }
            //    catch (Exception ex)
            //    {
            //        this.Dispatcher.Invoke((Action)delegate
            //        {
            //            throw ex;
            //        });
            //    }
            //});
            //t.Start();

        }
    }
}
