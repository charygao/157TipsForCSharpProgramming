using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip92
{
    class Program
    {
        static void Main(string[] args)
        {
            Company microsoft = new Company();
            microsoft.Employees[0].Name = "Luminji";
            foreach (var item in microsoft.Employees)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }

        class Employee
        {
            public string Name { get; set; }
        }

        class Company
        {
            public Company()
            {
                Employees = new List<Employee>()
                {
                    new Employee(){ Name = "Bill Gates"}
                };
            }
            public IList<Employee> Employees { get; private set; }
        }

    }
}
