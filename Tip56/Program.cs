using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Tip56
{
    class Program
    {
        static void Main()
        {
            Person luminji = new Person() { FirstName = "Minji", LastName = "Lu" };
            BinarySerializer.SerializeToFile(luminji, @"c:\", "person.txt");
            Person p = BinarySerializer.DeserializeFromFile<Person>(@"c:\person.txt");
            Console.WriteLine(p.FirstName);
            Console.WriteLine(p.LastName);
            Console.WriteLine(p.ChineseName);           
        }
    }

    [Serializable]
    public class Person : ISerializable
    {
        public string FirstName;
        public string LastName;
        public string ChineseName;

        public Person()
        {
        }

        protected Person(SerializationInfo info, StreamingContext context)
        {
            FirstName = info.GetString("FirstName");
            LastName = info.GetString("LastName");
            ChineseName = string.Format("{0} {1}", LastName, FirstName);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName);
            info.AddValue("LastName", LastName);
        }
    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        Person luminji = new Person() { FirstName = "Minji", LastName = "Lu" };
    //        BinarySerializer.SerializeToFile(luminji, @"c:\", "person.txt");
    //        PersonAnother p = BinarySerializer.DeserializeFromFile<PersonAnother>(@"c:\person.txt");
    //        Console.WriteLine(p.Name);
    //    }
    //}

    //[Serializable]
    //class PersonAnother : ISerializable
    //{
    //    public string Name { get; set; }

    //    protected PersonAnother(SerializationInfo info, StreamingContext context)
    //    {
    //        Name = info.GetString("Name");
    //    }

    //    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //    }
    //}

    //[Serializable]
    //public class Person : ISerializable
    //{
    //    public string FirstName;
    //    public string LastName;
    //    public string ChineseName;

    //    public Person()
    //    {
    //    }

    //    protected Person(SerializationInfo info, StreamingContext context)
    //    {
    //    }

    //    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.SetType(typeof(PersonAnother));
    //        info.AddValue("Name", string.Format("{0} {1}", LastName, FirstName));
    //    }
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
