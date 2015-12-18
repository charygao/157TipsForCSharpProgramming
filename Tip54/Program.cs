using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tip54
{
    class Program
    {
        static void Main()
        {
            Person mike = new Person() { Age = 21, Name = "Mike" };
            mike.NameChanged += new EventHandler(mike_NameChanged);
            BinarySerializer.SerializeToFile(mike, @"c:\", "person.txt");
            Person p = BinarySerializer.DeserializeFromFile<Person>(@"c:\person.txt");
            p.Name = "Rose";
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Age.ToString());
        }

        static void mike_NameChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Name Changed");
        }
    }

    [Serializable]
    class Person
    {
        private string name;
        public int Age { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (NameChanged != null)
                {
                    NameChanged(this, null);
                }
                name = value;
            }
        }
        public event EventHandler NameChanged;
    }

    //[Serializable]
    //class Person
    //{
    //    private string name;
    //    public string Name
    //    {
    //        get
    //        {
    //            return name;
    //        }
    //        set
    //        {
    //            if (NameChanged != null)
    //            {
    //                NameChanged(this, null);
    //            }
    //            name = value;
    //        }
    //    }

    //    public int Age { get; set; }

    //    [NonSerialized]
    //    private Department department;
    //    public Department Department
    //    {
    //        get
    //        {
    //            return department;
    //        }
    //        set
    //        {
    //            department = value;
    //        }
    //    }

    //    [field: NonSerialized]
    //    public event EventHandler NameChanged;
    //}


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
