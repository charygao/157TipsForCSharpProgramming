using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tip62
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            NestedExceptionSample nes = new NestedExceptionSample();
            try
            {
                nes.MethodWithTry();
            }
            catch (Exception error1)
            {
                MessageBox.Show(error1.StackTrace);
            }

            try
            {
                nes.MethodNoTry();
            }
            catch (Exception error2)
            {
                MessageBox.Show(error2.StackTrace);
            }

        }
    }

    class NestedExceptionSample2
    {
        internal void MethodWithTry()
        {
            try
            {
                Method1();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        internal void MethodNoTry()
        {
            Method1();
        }

        int Method1()
        {
            int i = 0;
            return 10 / i;
        }

    }

    public class NestedExceptionSample
    {
        public void MethodWithTry()
        {
            try
            {
                (new NestedExceptionSample2()).MethodWithTry();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void MethodNoTry()
        {
            (new NestedExceptionSample2()).MethodNoTry();
        }
    }

}
