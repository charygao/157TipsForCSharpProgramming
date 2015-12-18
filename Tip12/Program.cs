using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip12
{
    class Program
    {
        static Dictionary<Person, PersonMoreInfo> PersonValues = new Dictionary<Person, PersonMoreInfo>();
        static void Main(string[] args)
        {
            //string str1 = "NB0903100006";
            //string str2 = "NB0904140001";
            //Console.WriteLine(str1.GetHashCode());
            //Console.WriteLine(str2.GetHashCode());

            AddAPerson();
            Person mike = new Person("NB123");
            //Console.WriteLine(mike.GetHashCode());
            Console.WriteLine(PersonValues.ContainsKey(mike));

            Console.Read();
        }

        static void AddAPerson()
        {
            Person mike = new Person("NB123");
            PersonMoreInfo mikeValue = new PersonMoreInfo() { SomeInfo = "Mike's info" };
            PersonValues.Add(mike, mikeValue);
            //Console.WriteLine(mike.GetHashCode());
            Console.WriteLine(PersonValues.ContainsKey(mike));
        }

    }

    class Person : IEquatable<Person>
    {
        public string IDCode { get; private set; }

        public Person(string idCode)
        {
            this.IDCode = idCode;
        }

        public override bool Equals(object obj)
        {
            return IDCode == (obj as Person).IDCode;
        }

        public override int GetHashCode()
        {
            return (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "#" + this.IDCode).GetHashCode();
        }

        public bool Equals(Person other)
        {
            return IDCode == other.IDCode;
        }
    }

    class PersonMoreInfo
    {
        public string SomeInfo { get; set; }
    }
}
