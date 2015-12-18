using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip8
{
    class Program
    {
        static void Main(string[] args)
        {
            Week week = Week.ValueTemp;
            Console.WriteLine(week);
            Console.WriteLine(week == Week.Wednesday);

        }

        private static void NewMethod2()
        {
            Temp temp1 = Temp.Value1;
            Temp temp2 = Temp.Value2;
            Console.WriteLine(temp1 == temp2);
            Console.WriteLine(temp1.Equals(temp2));
            Console.WriteLine(temp1.CompareTo(temp2));
            Console.WriteLine(temp1 == Temp.Value1);
            Console.WriteLine(temp1 == Temp.Value2);
        }

    }

    enum Week
    {
        Monday = 1,
        Tuesday = 2,
        ValueTemp,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    enum Temp
    {
        Value1 = 1,
        Value2 = 1
    }

    //[Flags]
    //enum Week
    //{
    //    None = 0x0,
    //    Monday = 0x1,
    //    Tuesday = 0x2,
    //    Wednesday = 0x4,
    //    Thursday = 0x8,
    //    Friday = 0x10,
    //    Saturday = 0x20,
    //    Sunday = 0x40
    //}

    //class MyClass
    //{
    //    Week week = Week.Thursday | Week.Sunday;
    //}    

}
