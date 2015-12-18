using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip33
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyList.Func<int>());
            Console.WriteLine(MyList.Func<int>());
            Console.WriteLine(MyList.Func<string>());
        }

        class MyList
        {
            static int count;
            public static int Func<T>()
            {
                return count++;
            }
        }

    }
}
