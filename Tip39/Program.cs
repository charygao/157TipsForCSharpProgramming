using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip39
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    class FileUploader
    {
        public delegate void FileUploadedHandler(int progress);
        public FileUploadedHandler FileUploaded;
        
        public void Upload()
        {
            int fileProgress = 100;
            while (fileProgress > 0)
            {
                //传输代码，省略
                fileProgress--;
                if (FileUploaded != null)
                {
                    FileUploaded(fileProgress);
                }
            }
        }
    }

}
