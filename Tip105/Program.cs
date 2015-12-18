using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip105
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public sealed class Singleton
    {
        static Singleton instance = null;
        static readonly object padlock = new object();

        Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }

}
