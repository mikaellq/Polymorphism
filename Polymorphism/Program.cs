using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Shape
    {
        // A few example members
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // Virtual method
        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }

    class Circle : Shape
    {
        public override void Draw()
        {
            // Code to draw a circle...
            Console.WriteLine("Drawing a circle");
            base.Draw();
        }
    }
    class Rectangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a rectangle...
            Console.WriteLine("Drawing a rectangle");
            base.Draw();
        }
    }
    class Triangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a triangle...
            Console.WriteLine("Drawing a triangle");
            base.Draw();
        }
    }

    public class BaseClass
    {
        public string DoWork() { return "In baseclass"; }
        public virtual string WorkProperty
        {
            get { return "Baseclass WorkProperty"; }
        }
    }
    public class DerivedClass : BaseClass
    {
        public new string DoWork() { return "In derived class"; }
        public override string WorkProperty
        {
            get { return "Derived class' WorkProperty"; }
        }
    }

    class Base_Class
    {
        public void Method1()
        {
            Console.WriteLine("Base - Method1");
        }
    }

    class Derived_Class : Base_Class
    {
        public void Method2()
        {
            Console.WriteLine("Derived - Method2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Polymorphism at work #1: a Rectangle, Triangle and Circle
            // can all be used whereever a Shape is expected. No cast is
            // required because an implicit conversion exists from a derived 
            // class to its base class.
            var shapes = new List<Shape>
        {
            new Rectangle(),
            new Triangle(),
            new Circle()
        };

            // Polymorphism at work #2: the virtual method Draw is
            // invoked on each of the derived classes, not the base class.
            int i = 0;
            foreach (var shape in shapes)
            {
                shape.Height = i++ * 123 + 123;
                Console.WriteLine(shape.Height);
                shape.Draw();
            }

            BaseClass test = new DerivedClass(); // Baseclass test inherits from derived class
            Console.WriteLine($"Is in: {test.WorkProperty}");
            Console.WriteLine($"Is in: {test.DoWork()}");

            Base_Class bc = new Base_Class();
            Derived_Class dc = new Derived_Class();
            Base_Class bcdc = new Derived_Class();

            bc.Method1();
            dc.Method1();
            dc.Method2();
            bcdc.Method1();

            // Keep the console open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }

    /* Output:
        Drawing a rectangle
        Performing base class drawing tasks
        Drawing a triangle
        Performing base class drawing tasks
        Drawing a circle
        Performing base class drawing tasks
     */

}
