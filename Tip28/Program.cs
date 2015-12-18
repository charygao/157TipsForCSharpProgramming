using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Tip28
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //var temp1 = from c in list where c > 5 select c;
            //var temp2 = (from c in list where c > 5 select c).ToList<int>();
            //list[0] = 11;
            //Console.Write("temp1: ");
            //foreach (var item in temp1)
            //{
            //    Console.Write(item.ToString() + " ");
            //}
            //Console.Write("\ntemp2: ");
            //foreach (var item in temp2)
            //{
            //    Console.Write(item.ToString() + " ");
            //}
            DataContext ctx = new DataContext("server=192.168.0.102;database=Temp;uid=sa;pwd=sa123");
            Table<Person> persons = ctx.GetTable<Person>();

            var temp1 = from p in persons where p.Age > 20 select p;
            //省略
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
