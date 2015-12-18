using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Tip10
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList companySalary = new ArrayList();
            companySalary.Add(new Salary() { Name = "Mike", BaseSalary = 3000 });
            companySalary.Add(new Salary() { Name = "Rose", BaseSalary = 2000 });
            companySalary.Add(new Salary() { Name = "Jeffry", BaseSalary = 1000 });
            companySalary.Add(new Salary() { Name = "Steve", BaseSalary = 4000 });
            companySalary.Sort();
            foreach (Salary item in companySalary)
            {
                Console.WriteLine(item.Name + "\t BaseSalary: " + item.BaseSalary.ToString());
            }

            //ArrayList companySalary = new ArrayList();
            //companySalary.Add(new Salary() { Name = "Mike", BaseSalary = 3000, Bonus = 1000 });
            //companySalary.Add(new Salary() { Name = "Rose", BaseSalary = 2000, Bonus = 4000 });
            //companySalary.Add(new Salary() { Name = "Jeffry", BaseSalary = 1000, Bonus = 6000 });
            //companySalary.Add(new Salary() { Name = "Steve", BaseSalary = 4000, Bonus = 3000 });
            //companySalary.Sort(new BonusComparer());    //提供一个非默认的比较器
            //foreach (Salary item in companySalary)
            //{
            //    Console.WriteLine(string.Format("Name:{0} \tBaseSalary:{1} \tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
            //}

        }
    }

    class Salary : IComparable
    {
        public string Name { get; set; }
        public int BaseSalary { get; set; }
        public int Bonus { get; set; }

        #region IComparable 成员

        public int CompareTo(object obj)
        {
            Salary staff = obj as Salary;
            if (BaseSalary > staff.BaseSalary)
            {
                return 1;
            }
            else if (BaseSalary == staff.BaseSalary)
            {
                return 0;
            }
            else
            {
                return -1;
            }
            //return BaseSalary.CompareTo(staff.BaseSalary);
        }

        #endregion
    }

    class BonusComparer : IComparer
    {
        #region IComparer 成员

        public int Compare(object x, object y)
        {
            Salary s1 = x as Salary;
            Salary s2 = y as Salary;
            return s1.Bonus.CompareTo(s2.Bonus);
        }

        #endregion
    }

        //static void Main(string[] args)
        //{
        //    List<Salary> companySalary = new List<Salary>()
        //        {
        //            new Salary() { Name = "Mike", BaseSalary = 3000, Bonus = 1000 },
        //            new Salary() { Name = "Rose", BaseSalary = 2000, Bonus = 4000 },
        //            new Salary() { Name = "Jeffry", BaseSalary = 1000, Bonus = 6000 },
        //            new Salary() { Name = "Steve", BaseSalary = 4000, Bonus = 3000 }
        //        };
        //    companySalary.Sort(new BonusComparer());    //提供一个非默认的比较器
        //    foreach (Salary item in companySalary)
        //    {
        //        Console.WriteLine(string.Format("Name:{0} \tBaseSalary:{1} \tBonus:{2}", item.Name, item.BaseSalary, item.Bonus));
        //    }
        //}

        //class Salary : IComparable<Salary>
        //{
        //    public string Name { get; set; }
        //    public int BaseSalary { get; set; }
        //    public int Bonus { get; set; }

        //    #region IComparable<Salary> 成员

        //    public int CompareTo(Salary other)
        //    {
        //        return BaseSalary.CompareTo(other.BaseSalary);
        //    }

        //    #endregion
        //}

        //class BonusComparer : IComparer<Salary>
        //{
        //    #region IComparer<Salary> 成员

        //    public int Compare(Salary x, Salary y)
        //    {
        //        return x.Bonus.CompareTo(y.Bonus);
        //    }

        //    #endregion
        //}


}
