using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip3
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstType firstType = new FirstType() { Name = "First Type" };
            SecondType secondType = (SecondType)firstType;         //转型成功
            //secondType = firstType as SecondType;     //编译期转型失败，编译不通过

            Console.Read();
        }

        static void DoWithSomeType(object obj)
        {
            //SecondType secondType = (SecondType)obj;
            SecondType secondType = obj as SecondType;
            if (secondType != null)
            {
                // do someting
            }
        }

        //static void DoWithSomeType(object obj)
        //{
        //    if (obj is SecondType)
        //    {
        //        SecondType secondType = obj as SecondType;
        //        //do something
        //    }
        //}
    }

    class FirstType
    {
        public string Name { get; set; }
    }

    class SecondType
    {
        public string Name { get; set; }
        public static explicit operator SecondType(FirstType firstType)
        {
            SecondType secondType = new SecondType() { Name = "转型自：" + firstType.Name };
            return secondType;
        }
    }

    //class FirstType
    //{
    //    public string Name { get; set; }
    //}

    //class SecondType : FirstType
    //{
    //}


}
