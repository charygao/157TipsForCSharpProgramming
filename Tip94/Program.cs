using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tip94
{
    class Program
    {
        static void Main(string[] args)
        {
            TestShape();
            TestDerive();
            TestDerive2();
        }

        private static void TestShape()
        {
            Console.WriteLine("TestShape\tStart");
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Circle());
            shapes.Add(new Rectangle());
            shapes.Add(new Triangle());
            shapes.Add(new Diamond());
            foreach (Shape s in shapes)
            {
                s.MethodVirtual();
                s.Method();
            }
            Console.WriteLine("TestShape\tEnd\n");
        }

        private static void TestDerive()
        {
            Console.WriteLine("TestDerive\tStart");
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();
            Triangle triangel = new Triangle();
            Diamond diamond = new Diamond();
            circle.MethodVirtual();
            circle.Method();
            rectangle.MethodVirtual();
            rectangle.Method();
            triangel.MethodVirtual();
            triangel.Method();
            diamond.MethodVirtual();
            diamond.Method();
            Console.WriteLine("TestShape\tEnd\n");
        }

        private static void TestDerive2()
        {
            Console.WriteLine("TestDerive2\tStart");
            Circle circle = new Circle();
            PrintShape(circle);
            Rectangle rectangle = new Rectangle();
            PrintShape(rectangle);
            Triangle triangel = new Triangle();
            PrintShape(triangel);
            Diamond diamond = new Diamond();
            PrintShape(diamond);
            Console.WriteLine("TestDerive2\tEnd\n");
        }

        static void PrintShape(Shape sharpe)
        {
            sharpe.MethodVirtual();
            sharpe.Method();
        }


        public class Shape
        {
            public virtual void MethodVirtual()
            {
                Console.WriteLine("base MethodVirtual call");
            }

            public void Method()
            {
                Console.WriteLine("base Method call");
            }
        }

        class Circle : Shape
        {
            public override void MethodVirtual()
            {
                Console.WriteLine("circle override MethodVirtual");
            }
        }

        class Rectangle : Shape
        {

        }

        class Triangle : Shape
        {
            public new void MethodVirtual()
            {
                Console.WriteLine("triangle new MethodVirtual");
            }

            public new void Method()
            {
                Console.WriteLine("triangle new Method");
            }
        }

        class Diamond : Shape
        {
            public void MethodVirtual()
            {
                Console.WriteLine("Diamond default MethodVirtual");
            }

            public void Method()
            {
                Console.WriteLine("Diamond default Method");
            }
        }

    }
}
