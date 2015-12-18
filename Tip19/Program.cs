using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList2 = new List<Person>()
            {
                new Person() { Name = "Rose", Age = 19 },
                new Person() { Name = "Steve", Age = 45 },
                new Person() { Name = "Jessica", Age = 20 },
            };

            var pTemp = from p in personList2 select new { p.Name, AgeScope = p.Age > 20 ? "Old" : "Young" };
            foreach (var item in pTemp)
            {
                Console.WriteLine(string.Format("{0}:{1}", item.Name, item.AgeScope));
            }

        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
