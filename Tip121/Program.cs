using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Tip121
{
    class Program
    {
        static void Main()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            SampleClass sample = new SampleClass();
            Console.WriteLine("代码成功运行...");
        }
    }

    [PrincipalPermission(SecurityAction.Demand, Role = @"Administrator")]
    //[PrincipalPermission(SecurityAction.Demand, Role = @"Users")]
    class SampleClass
    {

    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
    //        SampleClass sample = new SampleClass();
    //        sample.SampleMethod();
    //        sample.SampleMethodSec();
    //        Console.WriteLine("代码成功运行...");
    //    }
    //}

    //class SampleClass
    //{
    //    public void SampleMethod()
    //    {
    //        Console.WriteLine("执行方法SampleMethod");
    //    }

    //    [PrincipalPermission(SecurityAction.Demand, Role = @"Administrator")]
    //    //[PrincipalPermission(SecurityAction.Demand, Role = @"Users")]
    //    public void SampleMethodSec()
    //    {
    //        Console.WriteLine("执行方法SampleMethodSec");
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        GenericIdentity examIdentity = new GenericIdentity("ExamUser");
    //        //String[] Users = { "Teacher", "Student" };
    //        String[] Users = { "Student" };
    //        GenericPrincipal MyPrincipal = new GenericPrincipal(examIdentity, Users);
    //        Thread.CurrentPrincipal = MyPrincipal;
    //        ScoreProcessor score = new ScoreProcessor();
    //        score.Update();
    //    }
    //}

    //class ScoreProcessor
    //{
    //    public void Update()
    //    {
    //        try
    //        {
    //            PrincipalPermission MyPermission = new PrincipalPermission("ExamUser", "Teacher");
    //            MyPermission.Demand();
    //            //省略
    //            Console.WriteLine("修改成绩成功");
    //        }
    //        catch (SecurityException e)
    //        {
    //            Console.WriteLine(e.Message);
    //        }
    //    }
    //}

}
