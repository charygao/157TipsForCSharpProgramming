using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip1
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static void NewMethod1()
        {
            string s1 = "abc";
            s1 = "123" + s1 + "456";    //以上两行代码创建了3个
            //字符串对象，并执行了一次string.Contact方法
        }
        #region IL代码如下:
        /*
        .method private hidebysig static void NewMethod1() cil managed
        {
            .maxstack 3
            .locals init (
                [0] string str)
            L_0000: nop 
            L_0001: ldstr "abc"
            L_0006: stloc.0 
            L_0007: ldstr "123"
            L_000c: ldloc.0 
            L_000d: ldstr "456"
            L_0012: call string [mscorlib]System.String::Concat(string, string, string)
            L_0017: stloc.0 
            L_0018: ret 
        }
        */
	    #endregion

        private static void NewMethod6()
        {
            string re6 = 9 + "456";     //该代码发生一次装箱，并调
            //用一次string.Contact方法
        }
        #region IL代码
        /*
         .method private hidebysig static void NewMethod6() cil managed
        {
            .maxstack 2
            .locals init (
                [0] string str)
            L_0000: nop 
            L_0001: ldc.i4.s 9
            L_0003: box int32
            L_0008: ldstr "456"
            L_000d: call string [mscorlib]System.String::Concat(object, object)
            L_0012: stloc.0 
            L_0013: ret 
        }
         */
        
        #endregion

        private static void NewMethod2()
        {
            string re2 = "123" + "abc" + "456"; //该代码等效于 
            //string re2 = "123abc456";
        }
        #region IL代码
        /*
         .method private hidebysig static void NewMethod2() cil managed
        {
            .maxstack 1
            .locals init (
                [0] string str)
            L_0000: nop 
            L_0001: ldstr "123abc456"
            L_0006: stloc.0 
            L_0007: ret 
        }
         */
        
        #endregion


        private static void NewMethod9()
        {
            const string a = "t";
            string re1 = "abc" + a;     //因为a是一个常量，所以
            //该代码等效于 string re1 = "abc" + "t"; 
            //最终等效于string re1 = "abct";
        }
        #region IL代码
        /*
         .method private hidebysig static void NewMethod9() cil managed
        {
            .maxstack 1
            .locals init (
                [0] string str)
            L_0000: nop 
            L_0001: ldstr "abct"
            L_0006: stloc.0 
            L_0007: ret 
        }
         */
        
        #endregion


        private static void NewMethod8()
        {
            string a = "t";
            a += "e";
            a += "s";
            a += "t";
        }
        #region IL代码
        /*
         method private hidebysig static void NewMethod8() cil managed
        {
            .maxstack 2
            .locals init (
                [0] string str)
            L_0000: nop 
            L_0001: ldstr "t"
            L_0006: stloc.0 
            L_0007: ldloc.0 
            L_0008: ldstr "e"
            L_000d: call string [mscorlib]System.String::Concat(string, string)
            L_0012: stloc.0 
            L_0013: ldloc.0 
            L_0014: ldstr "s"
            L_0019: call string [mscorlib]System.String::Concat(string, string)
            L_001e: stloc.0 
            L_001f: ldloc.0 
            L_0020: ldstr "t"
            L_0025: call string [mscorlib]System.String::Concat(string, string)
            L_002a: stloc.0 
            L_002b: ret 
        }

         */
        
        #endregion


        private static void NewMethod7()
        {
            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            string result = a + b + c + d;
        }

        #region IL代码
        /*
          .method private hidebysig static void NewMethod7() cil managed
        {
            .maxstack 4
            .locals init (
                [0] string str,
                [1] string str2,
                [2] string str3,
                [3] string str4,
                [4] string str5)
            L_0000: nop 
            L_0001: ldstr "t"
            L_0006: stloc.0 
            L_0007: ldstr "e"
            L_000c: stloc.1 
            L_000d: ldstr "s"
            L_0012: stloc.2 
            L_0013: ldstr "t"
            L_0018: stloc.3 
            L_0019: ldloc.0 
            L_001a: ldloc.1 
            L_001b: ldloc.2 
            L_001c: ldloc.3 
            L_001d: call string [mscorlib]System.String::Concat(string, string, string, string)
            L_0022: stloc.s str5
            L_0024: ret 
        }
         */
        
        #endregion


        private static void NewMethod10()
        {
            //为了演示必要，定义了4个变量
            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            StringBuilder sb = new StringBuilder(a);
            sb.Append(b);
            sb.Append(c);
            sb.Append(d);
            //再次提示，是运行时，所以没有使用下面的代码
            //StringBuilder sb = new StringBuilder("t");
            //sb.Append("e");
            //sb.Append("s");
            //sb.Append("t");
            string result = sb.ToString();
        }
        #region IL代码
        /*
         .method private hidebysig static void NewMethod10() cil managed
{
    .maxstack 2
    .locals init (
        [0] string str,
        [1] string str2,
        [2] string str3,
        [3] string str4,
        [4] class [mscorlib]System.Text.StringBuilder builder,
        [5] string str5)
    L_0000: nop 
    L_0001: ldstr "t"
    L_0006: stloc.0 
    L_0007: ldstr "e"
    L_000c: stloc.1 
    L_000d: ldstr "s"
    L_0012: stloc.2 
    L_0013: ldstr "t"
    L_0018: stloc.3 
    L_0019: ldloc.0 
    L_001a: newobj instance void [mscorlib]System.Text.StringBuilder::.ctor(string)
    L_001f: stloc.s builder
    L_0021: ldloc.s builder
    L_0023: ldloc.1 
    L_0024: callvirt instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    L_0029: pop 
    L_002a: ldloc.s builder
    L_002c: ldloc.2 
    L_002d: callvirt instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    L_0032: pop 
    L_0033: ldloc.s builder
    L_0035: ldloc.3 
    L_0036: callvirt instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    L_003b: pop 
    L_003c: ldloc.s builder
    L_003e: callvirt instance string [mscorlib]System.Object::ToString()
    L_0043: stloc.s str5
    L_0045: ret 
}
         */
        
        #endregion


        private static void NewMethod11()
        {
            //为了演示必要，定义了4个变量
            string a = "t";
            string b = "e";
            string c = "s";
            string d = "t";
            string.Format("{0}{1}{2}{3}", a, b, c, d);
        }

        #region IL代码
        /*
.method private hidebysig static void NewMethod11() cil managed
{
    .maxstack 4
    .locals init (
        [0] string str,
        [1] string str2,
        [2] string str3,
        [3] string str4,
        [4] object[] objArray)
    L_0000: nop 
    L_0001: ldstr "t"
    L_0006: stloc.0 
    L_0007: ldstr "e"
    L_000c: stloc.1 
    L_000d: ldstr "s"
    L_0012: stloc.2 
    L_0013: ldstr "t"
    L_0018: stloc.3 
    L_0019: ldstr "{0}{1}{2}{3}"
    L_001e: ldc.i4.4 
    L_001f: newarr object
    L_0024: stloc.s objArray
    L_0026: ldloc.s objArray
    L_0028: ldc.i4.0 
    L_0029: ldloc.0 
    L_002a: stelem.ref 
    L_002b: ldloc.s objArray
    L_002d: ldc.i4.1 
    L_002e: ldloc.1 
    L_002f: stelem.ref 
    L_0030: ldloc.s objArray
    L_0032: ldc.i4.2 
    L_0033: ldloc.2 
    L_0034: stelem.ref 
    L_0035: ldloc.s objArray
    L_0037: ldc.i4.3 
    L_0038: ldloc.3 
    L_0039: stelem.ref 
    L_003a: ldloc.s objArray
    L_003c: call string [mscorlib]System.String::Format(string, object[])
    L_0041: pop 
    L_0042: ret 
}
         */
        
        #endregion

    }
}
