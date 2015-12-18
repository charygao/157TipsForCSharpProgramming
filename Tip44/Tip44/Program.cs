using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip44
{
    class Program
    {
        public delegate T GetEmployeeHanlder<T>(string name);

        static void Main()
        {
            GetEmployeeHanlder<Employee> getAEmployee = GetAManager;
            Employee e = getAEmployee("Mike");
        }

        static Manager GetAManager(string name)
        {
            Console.WriteLine("我是经理: " + name);
            return new Manager() { Name = name };
        }

        static Employee GetAEmployee(string name)
        {
            Console.WriteLine("我是雇员: " + name);
            return new Employee() { Name = name };
        }

    }

    interface ISalary<T>
    {
        void Pay();
    }

    class BaseSalaryCounter<T> : ISalary<T>
    {
        public void Pay()
        {
            Console.WriteLine("Pay base salary");
        }
    }

    class Employee
    {
        public string Name { get; set; }
    }
    class Programmer : Employee
    {
    }
    class Manager : Employee
    {
    }

}
