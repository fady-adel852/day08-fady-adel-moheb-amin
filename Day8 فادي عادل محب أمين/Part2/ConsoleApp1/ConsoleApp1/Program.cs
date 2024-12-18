// Create a Shape Series

using System;

public interface IShapeSeries
{
    int CurrentShapeArea { get; set; }
    void GetNextArea();
    void ResetSeries();
}

public class SquareSeries : IShapeSeries
{
    private int _sideLength = 1;
    public int CurrentShapeArea { get; set; }

    public void GetNextArea()
    {
        CurrentShapeArea = _sideLength * _sideLength;
        _sideLength++;
    }

    public void ResetSeries()
    {
        _sideLength = 1;
        CurrentShapeArea = 0;
    }
}

public class CircleSeries : IShapeSeries
{
    private int _radius = 1;
    public int CurrentShapeArea { get; set; }

    public void GetNextArea()
    {
        CurrentShapeArea = (int)(Math.PI * _radius * _radius);
        _radius++;
    }

    public void ResetSeries()
    {
        _radius = 1;
        CurrentShapeArea = 0;
    }
}

public class Program
{
    public static void PrintTenShapes(IShapeSeries series)
    {
        for (int i = 0; i < 10; i++)
        {
            series.GetNextArea();
            Console.WriteLine($"Shape {i + 1} Area: {series.CurrentShapeArea}");
        }
    }

    public static void Main()
    {
        IShapeSeries squareSeries = new SquareSeries();
        IShapeSeries circleSeries = new CircleSeries();

        Console.WriteLine("Square Series:");
        PrintTenShapes(squareSeries);

        Console.WriteLine("\nCircle Series:");
        PrintTenShapes(circleSeries);
    }
}

//==========================================================================

//Implement Sorting for Shapes


using System;
using System.Collections.Generic;

public class Shape : IComparable<Shape>
{
    public string Name { get; set; }
    public double Area { get; set; }

    public int CompareTo(Shape other)
    {
        if (other == null) return 1;
        return this.Area.CompareTo(other.Area);
    }
}

public class Program
{
    public static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Shape { Name = "Square", Area = 25 },
            new Shape { Name = "Circle", Area = 78.5 },
            new Shape { Name = "Rectangle", Area = 50 },
            new Shape { Name = "Square", Area = 16 },
            new Shape { Name = "Circle", Area = 28.27 }
        };

        shapes.Sort();

        Console.WriteLine("Shapes sorted by area in ascending order:");
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.Name} with area {shape.Area}");
        }
    }
}




//=======================================================================

//Extend the Shape Hierarchy




using System;

public abstract class GeometricShape
{
    public double Dimension1 { get; set; }
    public double Dimension2 { get; set; }

    public abstract double CalculateArea();
    public abstract double Perimeter { get; }
}

public class Triangle : GeometricShape
{
    public override double CalculateArea()
    {
        return 0.5 * Dimension1 * Dimension2;
    }

    public override double Perimeter
    {
        get
        {
            // Assuming it's a right-angled triangle for simplicity
            double hypotenuse = Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2);
            return Dimension1 + Dimension2 + hypotenuse;
        }
    }
}

public class Rectangle : GeometricShape
{
    public override double CalculateArea()
    {
        return Dimension1 * Dimension2;
    }

    public override double Perimeter
    {
        get
        {
            return 2 * (Dimension1 + Dimension2);
        }
    }
}

public class Program
{
    public static void Main()
    {
        GeometricShape triangle = new Triangle { Dimension1 = 3, Dimension2 = 4 };
        GeometricShape rectangle = new Rectangle { Dimension1 = 5, Dimension2 = 6 };

        Console.WriteLine($"Triangle Area: {triangle.CalculateArea()}, Perimeter: {triangle.Perimeter}");
        Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea()}, Perimeter: {rectangle.Perimeter}");
    }
}







//============================================================================

// Implement Your Own Sorting





using System;
using System.Collections.Generic;

public class Shape
{
    public string Name { get; set; }
    public double Area { get; set; }
}

public class Program
{
    public static void SelectionSort(int[] numbers)
    {
        int n = numbers.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = numbers[minIndex];
            numbers[minIndex] = numbers[i];
            numbers[i] = temp;
        }
    }

    public static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Shape { Name = "Square", Area = 25 },
            new Shape { Name = "Circle", Area = 78.5 },
            new Shape { Name = "Rectangle", Area = 50 },
            new Shape { Name = "Square", Area = 16 },
            new Shape { Name = "Circle", Area = 28.27 }
        };

        int[] shapeAreas = new int[shapes.Count];
        for (int i = 0; i < shapes.Count; i++)
        {
            shapeAreas[i] = (int)shapes[i].Area;
        }

        SelectionSort(shapeAreas);

        Console.WriteLine("Shape areas sorted in ascending order:");
        foreach (var area in shapeAreas)
        {
            Console.WriteLine(area);
        }
    }
}





//==========================================================================

// Implement Factory Pattern





using System;

public abstract class GeometricShape
{
    public double Dimension1 { get; set; }
    public double Dimension2 { get; set; }

    public abstract double CalculateArea();
    public abstract double Perimeter { get; }
}

public class Triangle : GeometricShape
{
    public override double CalculateArea()
    {
        return 0.5 * Dimension1 * Dimension2;
    }

    public override double Perimeter
    {
        get
        {
            // Assuming it's a right-angled triangle for simplicity
            double hypotenuse = Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2);
            return Dimension1 + Dimension2 + hypotenuse;
        }
    }
}

public class Rectangle : GeometricShape
{
    public override double CalculateArea()
    {
        return Dimension1 * Dimension2;
    }

    public override double Perimeter
    {
        get
        {
            return 2 * (Dimension1 + Dimension2);
        }
    }
}

public class ShapeFactory
{
    public GeometricShape CreateShape(string shapeType, double dim1, double dim2)
    {
        switch (shapeType.ToLower())
        {
            case "triangle":
                return new Triangle { Dimension1 = dim1, Dimension2 = dim2 };
            case "rectangle":
                return new Rectangle { Dimension1 = dim1, Dimension2 = dim2 };
            default:
                throw new ArgumentException("Invalid shape type");
        }
    }
}

public class Program
{
    public static void Main()
    {
        ShapeFactory factory = new ShapeFactory();

        GeometricShape triangle = factory.CreateShape("triangle", 3, 4);
        GeometricShape rectangle = factory.CreateShape("rectangle", 5, 6);

        Console.WriteLine($"Triangle Area: {triangle.CalculateArea()}, Perimeter: {triangle.Perimeter}");
        Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea()}, Perimeter: {rectangle.Perimeter}");
    }
}