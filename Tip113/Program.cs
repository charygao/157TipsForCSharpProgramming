using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip112
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort salary = 65534;
            checked
            {
                salary = (ushort)(salary + 1);
                Console.WriteLine(string.Format("第一次加薪，工资总数：{0}", salary));
                salary = (ushort)(salary + 1);
                Console.WriteLine(string.Format("第二次加薪，工资总数：{0}", salary));
            }
        }

    }
}
