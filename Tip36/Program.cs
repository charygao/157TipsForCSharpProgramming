using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip36
{
    class Program
    {
        delegate int AddHandler(int i, int j);
        delegate void PrintHandler(string msg);

        static void Main(string[] args)
        {
            //AddHandler add = Add;
            //PrintHandler print = Print;
            //print(add(1, 2).ToString());

            Func<int, int, int> add = Add;
            Action<string> print = Print;
            print(add(1, 2).ToString());

        }

        static int Add(int i, int j)
        {
            return i + j;
        }

        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
