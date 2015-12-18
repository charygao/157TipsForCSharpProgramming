using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip6
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample sample = new Sample(200);
            //sample.ReadOnlyValue = 300;         //无法对只读的字段赋值(构造函数或变量初始值指定项中除外)
            Sample2 sample2 = new Sample2(new Student() { Age = 10 });
            //sample2.ReadOnlyValue = new Student() { Age = 20 };     //无法对只读的字段赋值(构造函数或变量初始值指定项中除外)
            sample2.ReadOnlyValue.Age = 20;

            Console.Read();
        }

        class Sample
        {
            public readonly int ReadOnlyValue;

            public Sample(int value)
            {
                ReadOnlyValue = value;
            }
        }

        class Sample2
        {
            public readonly Student ReadOnlyValue;

            public Sample2(Student value)
            {
                ReadOnlyValue = value;
            }
        }

    }
}
