using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Tip29
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataContext ctx = new DataContext("server=192.168.0.102;database=Temp;uid=sa;pwd=sa123");
            //Table<Person> persons = ctx.GetTable<Person>();
            //var temp1 = from p in persons where OlderThan20(p.Age) select p;
            //foreach (var item in temp1)
            //{
            //    Console.WriteLine(string.Format("Name:{0}\tAge:{1}", item.Name, item.Age));
            //}
        }

        private static void NewMethod3()
        {
            DataContext ctx = new DataContext("server=192.168.0.102;database=Temp;uid=sa;pwd=sa123");
            Table<Person> persons = ctx.GetTable<Person>();
            var temp1 = (from p in persons where p.Age > 20 select p).AsEnumerable<Person>();
            var temp2 = from p in temp1 where p.Name.IndexOf('e') > 0 select p;
            foreach (var item in temp2)
            {
                Console.WriteLine(string.Format("Name:{0}\tAge:{1}", item.Name, item.Age));
            }
        }

        private static void NewMethod1()
        {
            DataContext ctx = new DataContext("server=192.168.0.102;database=Temp;uid=sa;pwd=sa123");
            Table<Person> persons = ctx.GetTable<Person>();
            var temp1 = from p in persons where p.Age > 20 select p;
            var temp2 = from p in temp1 where p.Name.IndexOf('e') > 0 select p;
            foreach (var item in temp2)
            {
                Console.WriteLine(string.Format("Name:{0}\tAge:{1}", item.Name, item.Age));
            }
        }


        [Table(Name = "Person")]
        class Person
        {
            [Column]
            public string Name { get; set; }
            [Column]
            public int Age { get; set; }
        }

    }
}
