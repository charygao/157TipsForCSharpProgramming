using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip43
{
    class Program
    {
        static void Main(string[] args)
        {
            ISalary<Programmer> s = new BaseSalaryCounter<Programmer>();
            ISalary<Manager> t = new BaseSalaryCounter<Manager>();
            PrintSalary(s);
            PrintSalary(t);
        }

        static void PrintSalary(ISalary<Employee> s)    //用法正确
        {
            s.Pay();
        }

        //static void Main()
        //{
        //    IList<Programmer> programmers = new List<Programmer>();
        //    IList<Manager> managers = new List<Manager>();
        //    PrintPersonName(programmers);
        //    PrintPersonName(managers);
        //}

        //static void PrintPersonName(IEnumerable<Employee> persons)
        //{
        //    foreach (Employee person in persons)
        //    {
        //        Console.WriteLine(person.Name);
        //    }
        //}

    }

    interface ISalary<out T>	//使用out关键字
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
