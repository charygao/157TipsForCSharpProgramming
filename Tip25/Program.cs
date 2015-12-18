using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tip25
{
    class Program
    {
        static List<Student> listStudent = new List<Student>()
            {
                new Student(){ Name = "Mike", Age = 1},
                new Student(){ Name = "Rose", Age = 2}
            };

        static void Main(string[] args)
        {
            StudentTeamA teamA = new StudentTeamA();
            Thread t1 = new Thread(() =>
            {
                teamA.Students = listStudent;
                Thread.Sleep(3000);
                Console.WriteLine(listStudent.Count); //模拟对
                //集合属性进行一些运算
            });
            t1.Start();
            Thread t2 = new Thread(() =>
            {
                listStudent = null;   //模拟在别的地方对list1而
                //不是属性本身赋值为null
            });
            t2.Start();
        }
    }

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class StudentTeamA
    {
        public List<Student> Students { get; set; }
    }

    //class Program
    //{
    //    static List<Student> listStudent = new List<Student>()
    //        {
    //            new Student(){ Name = "Mike", Age = 1},
    //            new Student(){ Name = "Rose", Age = 2}
    //        };
        
    //    static void Main(string[] args)
    //    {
    //        StudentTeamA teamA2 = new StudentTeamA();
    //        teamA2.Students.Add(new Student() { Name = "Steve", Age = 3 });
    //        teamA2.Students.AddRange(listStudent);
    //        Console.WriteLine(teamA2.Students.Count);
    //        //也可以像下面这样实现
    //        StudentTeamA teamA3 = new StudentTeamA(listStudent);
    //        Console.WriteLine(teamA3.Students.Count);
    //    }

    //class Student
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}

    //class StudentTeamA
    //{
    //    public List<Student> Students { get; private set; }

    //    public StudentTeamA()
    //    {
    //        Students = new List<Student>();
    //    }

    //    public StudentTeamA(IEnumerable<Student> studentList)
    //        : this()
    //    {
    //        Students.AddRange(studentList);
    //    }
    //}


}
