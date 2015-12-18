using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip38
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Action> lists = new List<Action>();
            for (int i = 0; i < 5; i++)
            {
                Action t = () =>
                {
                    Console.WriteLine(i.ToString());
                };
                lists.Add(t);
            }
            foreach (Action t in lists)
            {
                t();
            }
        }

        //static void Main(string[] args)
        //{
        //    List<Action> lists = new List<Action>();
        //    TempClass tempClass = new TempClass();
        //    for (tempClass.i = 0; tempClass.i < 5; tempClass.i++)
        //    {
        //        Action t = tempClass.TempFuc;
        //        lists.Add(t);
        //    }
        //    foreach (Action t in lists)
        //    {
        //        t();
        //    }
        //}

        //class TempClass
        //{
        //    public int i;
        //    public void TempFuc()
        //    {
        //        Console.WriteLine(i.ToString());
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    List<Action> lists = new List<Action>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        int temp = i;
        //        Action t = () =>
        //        {
        //            Console.WriteLine(temp.ToString());
        //        };
        //        lists.Add(t);
        //    }
        //    foreach (Action t in lists)
        //    {
        //        t();
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    List<Action> lists = new List<Action>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        TempClass tempClass = new TempClass();
        //        tempClass.i = i;
        //        Action t = tempClass.TempFuc;
        //        lists.Add(t);
        //    }
        //    foreach (Action t in lists)
        //    {
        //        t();
        //    }
        //}

        //class TempClass
        //{
        //    public int i;
        //    public void TempFuc()
        //    {
        //        Console.WriteLine(i.ToString());
        //    }
        //}


    }
}
