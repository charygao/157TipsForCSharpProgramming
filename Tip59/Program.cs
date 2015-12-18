using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip59
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private void SaveUser3(User user)
        {
            if (user.Age < 0)
            {
                throw new ArgumentOutOfRangeException("Age不能为负数。");
            }
            // 保存用户

        }

        private bool CheckAge(int age, ref string msg)
        {
            if (age < 0)
            {
                msg = "Age不能为负数。";
                return false;
            }
            else if (age > 100)
            {
                msg = "Age不能>100。";
                return false;
            }
            return true;
        }

    }

    class User
    {

        public int Age { get; set; }
    }
}
