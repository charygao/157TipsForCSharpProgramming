using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Tip110
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(EnumHelper.GetDescription(Week.Monday));
        //}

        //enum Week
        //{
        //    [EnumDescription("星期一")]
        //    Monday,
        //    [EnumDescription("星期二")]
        //    Tuesday
        //}

        //[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
        //public sealed class EnumDescriptionAttribute : Attribute
        //{
        //    private string description;
        //    public string Description
        //    {
        //        get { return this.description; }
        //    }

        //    public EnumDescriptionAttribute(string description)
        //        : base()
        //    {
        //        this.description = description;
        //    }
        //}
        //public static class EnumHelper
        //{
        //    public static string GetDescription(Enum value)
        //    {
        //        if (value == null)
        //        {
        //            throw new ArgumentNullException("value");
        //        }
        //        string description = value.ToString();
        //        FieldInfo fieldInfo = value.GetType().GetField(description);
        //        EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
        //        if (attributes != null && attributes.Length > 0)
        //        {
        //            description = attributes[0].Description;
        //        }
        //        return description;
        //    }
        //}

        static void Main(string[] args)
        {
            Console.WriteLine(Week.Monday);
        }

        class Week
        {
            public static readonly Week Monday = new Week(0);
            public static readonly Week Tuesday = new Week(1);
            //省略

            private int _infoType;

            private Week(int infoType)
            {
                _infoType = infoType;
            }

            public override string ToString()
            {
                switch (_infoType)
                {
                    case 0:
                        return "星期一";
                    case 1:
                        return "星期二";
                    default:
                        throw new Exception("不正确的星期信息！");
                }
            }
        }

    }
}
