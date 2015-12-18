using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip26
{
    class Program
    {
        static void Main(string[] args)
        {
            //为了演示需要companyList并不从数据库读取，而是直接赋值
            List<Company> companyList = new List<Company>()
            {
                new Company(){ ComanyID = 0, Name = "Micro" },
                new Company(){ ComanyID = 1, Name = "Sun" }
            };
            //为了演示需要personList并不从数据库读取，而是直接赋值
            List<Person> personList = new List<Person>()
            {
                new Person(){ Name = "Mike", CompanyID = 1 },
                new Person(){ Name = "Rose", CompanyID = 0 },
                new Person(){ Name = "Steve", CompanyID = 1 }
            };

            var personWithCompanyList = from person in personList
                                        join company in companyList on person.CompanyID equals company.ComanyID
                                        select new { PersonName = person.Name, CompanyName = company.Name };
            foreach (var item in personWithCompanyList)
            {
                Console.WriteLine(string.Format("{0}\t:{1}", item.PersonName, item.CompanyName));
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int CompanyID { get; set; }
    }

    class Company
    {
        public int ComanyID { get; set; }
        public string Name { get; set; }
    }

}
