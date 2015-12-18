using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tip53
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Method1();
            Method2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void Method1()
        {
            SimpleClass s = new SimpleClass("method1");
            s = null;
        }
        private void Method2()
        {
            SimpleClass s = new SimpleClass("method2");
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Thread t = new Thread((ThreadStart)Method1);
        //    t.IsBackground = true;
        //    t.Start();
        //    Thread t2 = new Thread((ThreadStart)Method2);
        //    t2.IsBackground = true;
        //    t2.Start();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    GC.Collect();
        //}

        //private void Method1()
        //{
        //    SimpleClass s = new SimpleClass("method1");
        //    s = null;
        //    while (true)
        //    {
        //        Thread.Sleep(1000);
        //    }
        //}
        //private void Method2()
        //{
        //    SimpleClass s = new SimpleClass("method2");
        //    while (true)
        //    {
        //        Thread.Sleep(1000);
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    SimpleClass s = new SimpleClass("test");
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    GC.Collect();
        //}


    }

    class SimpleClass
    {
        string m_text;

        public SimpleClass(string text)
        {
            m_text = text;
        }

        ~SimpleClass()
        {
            MessageBox.Show(string.Format("SimpleClass Disposed, tag:{0}", m_text));
        }
    }

    //class SimpleClass
    //{
    //    static AnotherSimpleClass asc = new AnotherSimpleClass();
    //    string m_text;

    //    public SimpleClass(string text)
    //    {
    //        m_text = text;
    //    }

    //    ~SimpleClass()
    //    {
    //        //asc = null;
    //        MessageBox.Show(string.Format("SimpleClass Disposed, tag:{0}", m_text));
    //    }
    //}

    //class AnotherSimpleClass
    //{
    //    ~AnotherSimpleClass()
    //    {
    //        MessageBox.Show("AnotherSimpleClass Disposed");
    //    }
    //}

}
