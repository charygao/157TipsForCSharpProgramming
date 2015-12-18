using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip32
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class MyList<T>
    {
        T[] items;

        public T this[int i]
        {
            get { return items[i]; }
            set { this.items[i] = value; }
        }

        public int Count
        {
            get { return items.Length; }
        }

        ///省略其他方法
    }

}
