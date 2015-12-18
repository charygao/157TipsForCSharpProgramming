using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person() { FirstName = "Jessica", LastName = "Hu", IDCode = "NB123" };
            //Console.WriteLine(person.ToString());
            //PersonFomatter pFormatter = new PersonFomatter();
            //Console.WriteLine(pFormatter.Format("Ch", person, null));
            //Console.WriteLine(pFormatter.Format("Eg", person, null));
            //Console.WriteLine(pFormatter.Format("ChM", person, null));

            Person person = new Person() { FirstName = "Jessica", LastName = "Hu", IDCode = "NB123" };
            Console.WriteLine(person.ToString());
            PersonFomatter pFormatter = new PersonFomatter();
            //第一类格式化输出语法
            Console.WriteLine(pFormatter.Format("Ch", person, null));
            Console.WriteLine(pFormatter.Format("Eg", person, null));
            Console.WriteLine(pFormatter.Format("ChM", person, null));
            //第二类格式化输出语法，也更简洁
            Console.WriteLine(person.ToString("Ch", pFormatter));
            Console.WriteLine(person.ToString("Eg", pFormatter));
            Console.WriteLine(person.ToString("ChM", pFormatter));

            Console.Read();
        }
    }

    //class Person : IFormattable
    //{
    //    public string IDCode { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }

    //    //实现接口IFormattable的方法ToString
    //    public string ToString(string format, IFormatProvider formatProvider)
    //    {
    //        switch (format)
    //        {
    //            case "Ch":
    //                return this.ToString();
    //            case "Eg":
    //                return string.Format("{0} {1}", FirstName, LastName);
    //            default:
    //                return this.ToString();
    //        }
    //    }

    //    //重写Object.ToString()
    //    public override string ToString()
    //    {
    //        return string.Format("{0} {1}", LastName, FirstName);
    //    }
    //}

    //class Person
    //{
    //    public string IDCode { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //}

    class Person : IFormattable
    {
        public string IDCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //实现接口IFormattable的方法ToString
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "Ch":
                    return this.ToString();
                case "Eg":
                    return string.Format("{0} {1}", FirstName, LastName);
                default:
                    //return this.ToString();
                    ICustomFormatter customFormatter = formatProvider as ICustomFormatter;
                    if (customFormatter == null)
                    {
                        return this.ToString();
                    }
                    return customFormatter.Format(format, this, null);

            }
        }

        //重写Object.ToString()
        public override string ToString()
        {
            return string.Format("{0} {1}", LastName, FirstName);
        }
    }


    class PersonFomatter : IFormatProvider, ICustomFormatter
    {

        #region IFormatProvider 成员

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        #endregion

        #region ICustomFormatter 成员

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Person person = arg as Person;
            if (person == null)
            {
                return string.Empty;
            }

            switch (format)
            {
                case "Ch":
                    return string.Format("{0} {1}", person.LastName, person.FirstName);
                case "Eg":
                    return string.Format("{0} {1}", person.FirstName, person.LastName);
                case "ChM":
                    return string.Format("{0} {1} : {2}", person.LastName, person.FirstName, person.IDCode);
                default:
                    return string.Format("{0} {1}", person.FirstName, person.LastName);
            }
        }

        #endregion
    }

}
