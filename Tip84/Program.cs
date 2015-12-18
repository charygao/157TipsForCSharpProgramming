using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip84
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var query = from p in intList select p;
            Console.WriteLine("以下是LINQ顺序输出：");
            foreach (int item in query)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("以下是PLINQ并行输出：");
            var queryParallel = from p in intList.AsParallel() select p;
            foreach (int item in queryParallel)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
