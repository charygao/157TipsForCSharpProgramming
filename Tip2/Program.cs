using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Tip2
{
    class Program
    {
        static void Main(string[] args)
        {
            //可空类型
            //以下两种写法效果一样
            Nullable<int> i1 = 22;
            int? i2 = null;
            int j = 123;

            if (i1.HasValue)
            {
                j = i1.Value;
            }
            else
            {
                j = 0;
            }
            //下面一句效果等同于上面if语句
            j = i2 ?? 0;

            Ip ip = "192.168.0.96";
            Console.WriteLine(ip.ToString());

            Animal animal;
            Dog dog = new Dog();
            animal = dog;       //隐式转化，因为Dog就是Animal。
            //dog = animal;     //编译不通过
            dog = (Dog)animal;  //必须存在一个显式转换

        }
    }

    class Ip
    {
        IPAddress value;

        public Ip(string ip)
        {
            value = IPAddress.Parse(ip);
        }
        public static implicit operator Ip(string ip)
        {
            Ip iptemp = new Ip(ip);
            return iptemp;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }

    class Animal
    {

    }

    class Dog : Animal
    {

    }

    class Cat : Animal
    {

    }

}
