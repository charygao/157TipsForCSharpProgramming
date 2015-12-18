using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tip14
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee mike = new Employee() { IDCode = "NB123", Age = 30, Department = new Department() { Name = "Dep1" } };
            Employee rose = mike.Clone() as Employee;
            Console.WriteLine(rose.IDCode);
            Console.WriteLine(rose.Age);
            Console.WriteLine(rose.Department);
            Console.WriteLine("开始改变Mike的值：");
            mike.IDCode = "NB456";
            mike.Age = 60;
            mike.Department.Name = "Dep2";
            Console.WriteLine(rose.IDCode);
            Console.WriteLine(rose.Age);
            Console.WriteLine(rose.Department);

        }
    }

    class Employee : ICloneable
    {
        public string IDCode { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }

    class Department
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }

    //class Employee : ICloneable
    //{
    //    public string IDCode { get; set; }
    //    public int Age { get; set; }
    //    public Department Department { get; set; }

    //    #region ICloneable 成员

    //    public object Clone()
    //    {
    //        using (Stream objectStream = new MemoryStream())
    //        {
    //            IFormatter formatter = new BinaryFormatter();
    //            formatter.Serialize(objectStream, this);
    //            objectStream.Seek(0, SeekOrigin.Begin);
    //            return formatter.Deserialize(objectStream) as Employee;
    //        }
    //    }
    //    #endregion
    //}

    //[Serializable]
    //class Employee : ICloneable
    //{
    //    public string IDCode { get; set; }
    //    public int Age { get; set; }
    //    public Department Department { get; set; }

    //    #region ICloneable 成员

    //    public object Clone()
    //    {
    //        return this.MemberwiseClone();
    //    }

    //    #endregion

    //    public Employee DeepClone()
    //    {
    //        using (Stream objectStream = new MemoryStream())
    //        {
    //            IFormatter formatter = new BinaryFormatter();
    //            formatter.Serialize(objectStream, this);
    //            objectStream.Seek(0, SeekOrigin.Begin);
    //            return formatter.Deserialize(objectStream) as Employee;
    //        }
    //    }

    //    public Employee ShallowClone()
    //    {
    //        return Clone() as Employee;
    //    }
    //}

}
