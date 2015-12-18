using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tip58
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            try
            {
                SaveUser(user);
            }
            catch (IOException)
            {
                //IO异常，通知当前用户
            }
            catch (UnauthorizedAccessException)
            {
                //权限失败，通知客户端管理员
            }
            catch (CommunicationException)
            {
                //网络异常，通知发送e-mail给网络管理员。
            }

        }

        private static int SaveUser1(User user)
        {
            if (!SaveToFile(user))
            {
                return 1;
            }
            if (!SaveToDataBase(user))
            {
                return 2;
            }
            return 0;
        }

        private static bool SaveUser2(User user, ref string errorMsg)
        {
            if (!SaveToFile(user))
            {
                errorMsg = "本地保存失败！";
                return false;
            }
            if (!SaveToDataBase(user))
            {
                errorMsg = "远程保存失败！";
                return false;
            }
            return true;
        }

        private static bool SaveToDataBase(User user)
        {
            throw new NotImplementedException();
        }

        private static bool SaveToFile(User user)
        {
            throw new NotImplementedException();
        }

        private static void SaveUser(User user)
        {
            SaveToFile(user);
            SaveToDataBase(user);
        }

    }

    class User
    {
    }

    [Serializable]
    public class CommunicationException : Exception
    {
        public CommunicationException() { }
        public CommunicationException(string message) : base(message) { }
        public CommunicationException(string message, Exception inner) : base(message, inner) { }
        protected CommunicationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
