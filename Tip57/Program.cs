using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tip57
{
    class Program
    {
        static void Main()
        {
            Employee luminji = new Employee() { Name = "luminji", Salary = 2000 };
            BinarySerializer.SerializeToFile(luminji, @"c:\", "person.txt");
            Employee luminjiCopy = BinarySerializer.DeserializeFromFile<Employee>(@"c:\person.txt");
            Console.WriteLine(string.Format("姓名：{0}", luminjiCopy.Name));
            Console.WriteLine(string.Format("薪水：{0}", luminjiCopy.Salary));
        }
    }

    [Serializable]
    public class Person : ISerializable
    {
        public string Name { get; set; }

        public Person()
        {
        }

        protected Person(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
        }
    }

    [Serializable]
    public class Employee : Person, ISerializable
    {
        public int Salary { get; set; }

        public Employee()
        {
        }

        protected Employee(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Salary = info.GetInt32("Salary");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Salary", Salary);
        }
    }

    public class BinarySerializer
    {
        //将类型序列化为字符串
        public static string Serialize<T>(T t)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
                return System.Text.Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        //将类型序列化为文件
        public static void SerializeToFile<T>(T t, string path, string fullName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fullPath = string.Format(@"{0}\{1}", path, fullName);
            using (FileStream stream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
                stream.Flush();
            }
        }

        //将字符串反序列化为类型
        public static TResult Deserialize<TResult>(string s) where TResult : class
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(s);
            using (MemoryStream stream = new MemoryStream(bs))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as TResult;
            }
        }

        //将文件反序列化为类型
        public static TResult DeserializeFromFile<TResult>(string path) where TResult : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as TResult;
            }
        }
    }

}
