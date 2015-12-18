using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Tip31
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            var temp = (from c in list where c.Age == 20 select c).ToList();
            Console.WriteLine(list.IteratedNum.ToString());
            list.IteratedNum = 0;
            var temp2 = (from c in list where c.Age >= 20 select c).First();
            Console.WriteLine(list.IteratedNum.ToString());

            //MyList list = new MyList();
            //var temp = (from c in list select c).Take(2).ToList();
            //Console.WriteLine(list.IteratedNum.ToString());
            //list.IteratedNum = 0;
            //var temp2 = (from c in list where c.Name == "Mike" select c).ToList();
            //Console.WriteLine(list.IteratedNum.ToString());

        }
    }

    class MyList : IEnumerable<Person>
    {
        //为了演示需要，模拟了一个元素集合
        List<Person> list = new List<Person>()
            {
                new Person(){ Name = "Mike", Age = 20 },
                new Person(){ Name = "Mike", Age = 30 },
                new Person(){ Name = "Rose", Age = 25 },
                new Person(){ Name = "Steve", Age = 30 },
                new Person(){ Name = "Jessica", Age = 20 }
            };

        /// <summary>
        /// 迭代次数属性
        /// </summary>
        public int IteratedNum { get; set; }

        public Person this[int i]
        {
            get { return list[i]; }
            set { this.list[i] = value; }
        }

        #region IEnumerable<Person> 成员

        public IEnumerator<Person> GetEnumerator()
        {
            foreach (var item in list)
            {
                //没遍历一个元素就加1
                IteratedNum++;
                yield return item;
            }
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
