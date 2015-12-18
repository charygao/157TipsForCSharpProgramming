using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip23
{
    class Program
    {
        static void Main(string[] args)
        {
            Employees1 employees1 = new Employees1() 
            {
                new Employee(){ Name = "Mike" },
                new Employee(){ Name = "Rose" }
            };
            IList<Employee> employees = employees1;
            employees.Add(new Employee() { Name = "Steve" });
            foreach (var item in employees1)
            {
                Console.WriteLine(item.Name);
            }
        }

        class Employee
        {
            public string Name { get; set; }
        }

        class Employees1 : List<Employee>
        {
            public new void Add(Employee item)
            {
                item.Name += " Changed!";
                base.Add(item);
            }
        }

        //static void Main(string[] args)
        //{
        //    Employees2 employees2 = new Employees2() 
        //    {
        //        new Employee(){ Name = "Mike" },
        //        new Employee(){ Name = "Rose" }
        //    };
        //    ICollection<Employee> employees = employees2;
        //    employees.Add(new Employee() { Name = "Steve" });
        //    foreach (var item in employees2)
        //    {
        //        Console.WriteLine(item.Name);
        //    }
        //}

        //class Employees2 : IEnumerable<Employee>, ICollection<Employee>
        //{
        //    List<Employee> items = new List<Employee>();

        //    #region IEnumerable<Employee> 成员

        //    public IEnumerator<Employee> GetEnumerator()
        //    {
        //        return items.GetEnumerator();
        //    }

        //    #endregion

        //    #region ICollection<Employee> 成员

        //    public void Add(Employee item)
        //    {
        //        item.Name += " Changed!";
        //        items.Add(item);
        //    }

        //    //省略

        //    #endregion
        //}


    }
}
