using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip101
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Student student = new Student();
    //        Console.WriteLine(StudentConverter.GetSexString(student));
    //    }
    //}

    //public static class StudentConverter
    //{
    //    public static string GetSexString(Student student)
    //    {
    //        return student.GetSex() == true ? "男" : "女";
    //    }
    //}

    public class Student
    {
        public bool GetSex()
        {
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine(student.GetSexString());
        }
    }

    public static class StudentExtension
    {
        public static string GetSexString(this Student student)
        {
            return student.GetSex() == true ? "男D" : "女?";
        }
    }

}
