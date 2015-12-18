using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip61
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static int TestIntReturnBelowFinally()
        {
            int i;
            try
            {
                i = 1;
            }
            finally
            {
                i = 2;
                Console.WriteLine("\t将int结果改为2，finally执行完毕");
            }
            return i;
        }

        private static int TestIntReturnInTry()
        {
            int i;
            try
            {
                return i = 1;
            }
            finally
            {
                i = 2;
                Console.WriteLine("\t将int结果改为2，finally执行完毕");
            }
        }

        static User TestUserReturnInTry()
        {
            User user = new User() { Name = "Mike", BirthDay = new DateTime(2010, 1, 1) };
            try
            {
                return user;
            }
            finally
            {
                user.Name = "Rose";
                user.BirthDay = new DateTime(2010, 2, 2);
                Console.WriteLine("\t将user.Name改为Rose");
            }
        }

        private static User TestUserReturnInTry2()
        {
            User user = new User() { Name = "Mike", BirthDay = new DateTime(2010, 1, 1) };
            try
            {
                return user;
            }
            finally
            {
                user.Name = "Rose";
                user.BirthDay = new DateTime(2010, 2, 2);
                user = null;
                Console.WriteLine("\t将user置为anull");
            }
        }


    }

    class User
    {

        public string Name { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
