using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip42
{
    class Program
    {
        static void Main(string[] args)
        {
            ISalary<Programmer> s = new BaseSalaryCounter<Programmer>();
            PrintSalary(s);
        }

        //static void PrintSalary(ISalary<Employee> s)
        //{
        //    s.Pay();
        //}

        static void PrintSalary<T>(ISalary<T> s)
        {
            s.Pay();
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
