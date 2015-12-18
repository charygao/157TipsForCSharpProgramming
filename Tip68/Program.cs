using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tip68
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new PaperEncryptException("加密试卷失败", "学生ID：123456");
            }
            catch (PaperEncryptException err)
            {

                Console.WriteLine(err.Message);
            }

        }
    }

    [global::System.Serializable]
    public class PaperEncryptException : Exception, ISerializable
    {
        private readonly string _paperInfo;
        public PaperEncryptException() { }
        public PaperEncryptException(string message) : base(message) { }
        public PaperEncryptException(string message, Exception inner) : base(message, inner) { }
        public PaperEncryptException(string message, string paperInfo)
            : base(message)
        {
            _paperInfo = paperInfo;
        }
        public PaperEncryptException(string message, string paperInfo, Exception inner)
            : base(message, inner)
        {
            _paperInfo = paperInfo;
        }
        protected PaperEncryptException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public override string Message
        {
            get
            {
                return base.Message + " " + _paperInfo;
            }
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Args", _paperInfo);
            base.GetObjectData(info, context);
        }
    }

}
