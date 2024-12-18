using System;

namespace Question3inpart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Rect();
            Console.WriteLine($"Area: {shape.CalcArea()}");
            Console.WriteLine($"Perimeter: {shape.Perimeter}");
        }
    }

    abstract class Shape
    {
        public double Dim01 { get; set; }
        public double Dim02 { get; set; }

        public abstract double CalcArea();
        public abstract double Perimeter { get; }
    }

    abstract class RectBase : Shape
    {
        public override double CalcArea()
        {
            return Dim01 * Dim02;
        }
    }

    class Rect : RectBase
    {
        public override double Perimeter
        {
            get { return (Dim01 + Dim02) * 2; }
        }
    }

    class Square : RectBase
    {
        public override double Perimeter
        {
            get { return Dim01 * 4; }
        }
    }
}


/*This code demonstrates abstraction by defining an abstract class Shape with
abstract methods and properties, and then implementing
these in derived classes Rect and Square. The Main method creates
an instance of Rect, sets its dimensions, and prints the area and perimeter.
*/

/*Abstraction in C# means you can hide the unnecessary details and show only
the essential features. For example, if you have a class called Shape with
properties like Dim01 and Dim02, and methods like CalcArea and Perimeter,
you can make this class abstract so that you cannot create objects directly
from it. Instead, you can inherit from this class in another class like Rect
or Square and implement these methods there.
*/