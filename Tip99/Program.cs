using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip99
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerSalary m = new ManagerSalary();
            m.SetSalary(new Employee());
        }

    }

    class Employee
    {
    }

    class Manager : Employee
    {
    }

    class Salary
    {
        public void SetSalary(Employee e)
        {
            Console.WriteLine("职员被设置了薪水。");
        }
    }

    class ManagerSalary : Salary
    {
        public void SetSalary(Manager m)
        {
            Console.WriteLine("经理被设置了薪水。");
        }
    }

}
