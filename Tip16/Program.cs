using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace Tip16
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewMethod();
            //int[] iArr = { 0, 1, 2, 3, 4, 5, 6 };
            //iArr = (int[])iArr.ReSize(10);

            ResizeArray();
            ResizeList();

        }

        private static void NewMethod()
        {
            int[] iArr = { 0, 1, 2, 3, 4, 5, 6 };
            ArrayList arrayListInt = ArrayList.Adapter(iArr);   //将数组转变为ArrayList
            arrayListInt.Add(7);
            List<int> listInt = iArr.ToList<int>();             //将数组转变为List<T>
            listInt.Add(7);
        }

        private static void ResizeArray()
        {
            int[] iArr = { 0, 1, 2, 3, 4, 5, 6 };
            Stopwatch watch = new Stopwatch();
            watch.Start();
            iArr = (int[])iArr.ReSize(10);
            watch.Stop();
            Console.WriteLine("ResizeArray: " + watch.Elapsed);
        }

        private static void ResizeList()
        {
            List<int> iArr = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });
            Stopwatch watch = new Stopwatch();
            watch.Start();
            iArr.Add(0);
            iArr.Add(0);
            iArr.Add(0);
            watch.Stop();
            Console.WriteLine("ResizeList: " + watch.Elapsed);
        }

    }


    public static class ClassForExtensions
    {
        public static Array ReSize(this Array array, int newSize)
        {
            Type t = array.GetType().GetElementType();
            Array newArray = Array.CreateInstance(t, newSize);
            Array.Copy(array, 0, newArray, 0, Math.Min(array.Length, newSize));
            return newArray;
        }
    }
}
