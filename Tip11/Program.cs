using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip11
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void ValueTypeOPEquals()
        {
            int i = 1;
            int j = 1;
            //True
            Console.WriteLine(i == j);
            j = i;
            //True
            Console.WriteLine(i == j);
        }

        static void ReferenceTypeOPEquals()
        {
            object a = 1;
            object b = 1;
            //False
            Console.WriteLine(a == b);
            b = a;
            //True
            Console.WriteLine(a == b);
        }

        static void ValueTypeEquals()
        {
            int i = 1;
            int j = 1;
            //True
            Console.WriteLine(i.Equals(j));
            j = i;
            //True
            Console.WriteLine(i.Equals(j));
        }

        static void ReferenceTypeEquals()
        {
            object a = new Person("NB123");
            object b = new Person("NB123");
            //False
            Console.WriteLine(a.Equals(b));
            b = a;
            //True
            Console.WriteLine(a.Equals(b));
        }

    }

    class Person
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
    }

}
