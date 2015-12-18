using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip37
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<int, int, int> add = new Func<int, int, int>(Add);
            //Action<string> print = new Action<string>(Print);
            //print(add(1, 2).ToString());

            //Func<int, int, int> add = new Func<int, int, int>(delegate(int i, int j)
            //{
            //    return i + j;
            //});
            //Action<string> print = new Action<string>(delegate(string msg)
            //{
            //    Console.WriteLine(msg);
            //});
            //print(add(1, 2).ToString());   

            //Func<int, int, int> add = delegate(int i, int j)
            //{
            //    return i + j;
            //};
            //Action<string> print = delegate(string msg)
            //{
            //    Console.WriteLine(msg);
            //};
            //print(add(1, 2).ToString());

            Func<int, int, int> add = (i, j) =>
            {
                return i + j;
            };
            Action<string> print = (msg) =>
            {
                Console.WriteLine(msg);
            };
            print(add(1, 2).ToString());

            //第一种写法
            //return this.Find(new Predicate<Student>(delegate(Student target)
            //{
            //    if (target.Name == name)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}));
            //第二种写法
            //return this.Find(new Predicate<Student>((target) =>
            //    {
            //        if (target.Name == name)
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }));
            //第三种写法
            //return this.Find((target) =>
            //    {
            //        if (target.Name == name)
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    });
            //第四种写法
            //return this.Find( target => target.Name == name );

        }

        static int Add(int i, int j)
        {
            return i + j;
        }

        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
