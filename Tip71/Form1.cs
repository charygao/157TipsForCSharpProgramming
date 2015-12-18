using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Tip71
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetPage_Click(object sender, EventArgs e)
        {
            var request = HttpWebRequest.Create("http://www.sina.com.cn");
            request.BeginGetResponse(this.AsyncCallbackImpl, request);
        }

        public void AsyncCallbackImpl(IAsyncResult ar)
        {
            WebRequest request = ar.AsyncState as WebRequest;
            var response = request.EndGetResponse(ar);
            var stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                var content = reader.ReadLine();
                //textBoxPage.Text = content;
                if (textBoxPage.InvokeRequired)
                    textBoxPage.BeginInvoke(new Action(() =>
                    {
                        textBoxPage.Text = content;
                    }));
                else
                    textBoxPage.Text = content;
            }
        }

    }
}
