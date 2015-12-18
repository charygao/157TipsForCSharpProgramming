using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip41
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUploader fl = new FileUploader();
            fl.FileUploaded += Progress;
            fl.Upload();
        }

        static void Progress(object sender, FileUploadedEventArgs e)
        {
            Console.WriteLine(e.FileProgress);
        }
    }


    class FileUploader
    {
        public event EventHandler<FileUploadedEventArgs> FileUploaded;

        public void Upload()
        {
            FileUploadedEventArgs e = new FileUploadedEventArgs() { FileProgress = 100 };

            while (e.FileProgress > 0)
            {
                //传输代码，省略
                e.FileProgress--;
                if (FileUploaded != null)
                {
                    FileUploaded(this, e);
                }
            }
        }
    }
    class FileUploadedEventArgs : EventArgs
    {
        public int FileProgress { get; set; }
    }

}
