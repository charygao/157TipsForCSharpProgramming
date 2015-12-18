using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip30
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Salary> companySalary = new List<Salary>()
                {
                    new Salary() { Name = "Mike", BaseSalary = 3000, Bonus = 1000 },
                    new Salary() { Name = "Rose", BaseSalary = 2000, Bonus = 4000 },
                    new Salary() { Name = "Jeffry", BaseSalary = 1000, Bonus = 6000 },
                    new Salary() { Name = "Steve", BaseSalary = 4000, Bonus = 3000 }
                };
            Console.WriteLine("默认排序：");
            foreach (Salary item in companySalary)
            {
                Console.WriteLine(string.Format("Name:{0} \tBaseSalary:{1} \tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            }
            Console.WriteLine("BaseSalary排序：");
            var orderByBaseSalary = from s in companySalary orderby s.BaseSalary select s;
            foreach (Salary item in orderByBaseSalary)
            {
                Console.WriteLine(string.Format("Name:{0} \tBaseSalary:{1} \tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            }
            Console.WriteLine("Bonus排序：");
            var orderByBonus = from s in companySalary orderby s.Bonus select s;
            foreach (Salary item in orderByBonus)
            {
                Console.WriteLine(string.Format("Name:{0} \tBaseSalary:{1} \tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            }
        }

        class Salary
        {
            public string Name { get; set; }
            public int BaseSalary { get; set; }
            public int Bonus { get; set; }
        }

    }
}
