using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Tip55
{
    class Program
    {
        static void Main()
        {
            Person luminji = new Person() { FirstName = "Minji", LastName = "Lu", ChineseName = "Lu Minji" };
            BinarySerializer.SerializeToFile(luminji, @"c:\", "Person.txt");
            Person person = BinarySerializer.DeserializeFromFile<Person>(@"c:\Person.txt");
            Console.WriteLine(person.ChineseName);
        }
    }

    [Serializable]
    class Person
    {
        public string FirstName;
        public string LastName;
        [NonSerialized]
        public string ChineseName;

        [OnDeserializedAttribute]
        void OnSerialized(StreamingContext context)
        {
            ChineseName = string.Format("{0} {1}", LastName, FirstName);
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
