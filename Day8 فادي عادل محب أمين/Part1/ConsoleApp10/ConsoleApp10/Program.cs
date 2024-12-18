//Question 1 Start:
using System;

namespace ConsoleApp10
{
    public interface IVehicle
    {
        void StartEngine();
        void StopEngine();
    }

    public class Car : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Car engine started.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Car engine stopped.");
        }
    }

    public class Bike : IVehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Bike engine started.");
        }

        public void StopEngine()
        {
            Console.WriteLine("Bike engine stopped.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicle vehicle1 = new Car();
            IVehicle vehicle2 = new Bike();

            Console.WriteLine("Using the Car object:");
            vehicle1.StartEngine();
            vehicle1.StopEngine();

            Console.WriteLine("\nUsing the Bike object:");
            vehicle2.StartEngine();
            vehicle2.StopEngine();
        }
    }
}


/*Why Code Against an Interface?
Coding against an interface rather than a concrete class provides several
benefits:

Flexibility: Interfaces allow you to change the implementation without
altering the code that uses the interface.

Decoupling: It reduces dependencies between classes, making the code easier to
maintain and test.

Polymorphism: Interfaces enable polymorphic behavior, allowing different
implementations to be used interchangeably.
*/


//Question 1 End:





//Question 2 Start:

using System;

namespace ConsoleApp10
{
    public abstract class Shape
    {
        public abstract double GetArea();

        public void Display()
        {
            Console.WriteLine("The area is: " + GetArea());
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea()
        {
            return Width * Height;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shape myRectangle = new Rectangle(5, 7);
            Shape myCircle = new Circle(3);

            myRectangle.Display();
            myCircle.Display();
        }
    }
}


/*When to Prefer an Abstract Class Over an Interface
Abstract Class: Use when you want to provide common functionality
(e.g., Display() method) and enforce certain methods to be implemented by
derived classes.

Interface: Use when you want to define a contract that multiple classes
can implement, without providing any common functionality.
*/

//Question 2 End:








//Question 3 Start:
using System;

namespace ConsoleApp10
{
    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99 },
                new Product { Id = 2, Name = "Smartphone", Price = 499.99 },
                new Product { Id = 3, Name = "Tablet", Price = 299.99 }
            };

            Array.Sort(products);

            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }
    }
}


/*How Does Implementing IComparable Improve Flexibility in Sorting?
Implementing the IComparable interface improves flexibility in sorting by:

Custom Sorting Logic: It allows you to define custom sorting logic within the
class itself, making it easier to sort objects based on specific attributes.

Consistency: Ensures that the sorting logic is consistent and reusable across
different parts of the application.

Ease of Use: Simplifies the sorting process by allowing you to use built-in
sorting methods like Array.Sort() without needing to provide a separate
comparison delegate.
*/

//Question 3 End:














//Question 4 Start:
using System;

namespace ConsoleApp10
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }

        public Student(Student other)
        {
            Id = other.Id;
            Name = other.Name;
            Grade = other.Grade;
        }

        public Student(int id, string name, double grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student originalStudent = new Student(1, "Alice", 90.5);

            Student shallowCopy = originalStudent;

            Student deepCopy = new Student(originalStudent);

            originalStudent.Grade = 95.0;

            Console.WriteLine($"Original Student Grade: {originalStudent.Grade}");
            Console.WriteLine($"Shallow Copy Student Grade: {shallowCopy.Grade}");
            Console.WriteLine($"Deep Copy Student Grade: {deepCopy.Grade}");
        }
    }
}


/*Primary Purpose of a Copy Constructor in C#
The primary purpose of a copy constructor in C# is to create a new instance
of a class that is a deep copy
of an existing instance. This means that the new object is a separate instance
with its own copy of the data, rather than just a reference to the same data.
This is particularly useful when you want to ensure that changes to
the original object do not affect the copied object, and vice versa.
It helps in maintaining data integrity and avoiding
unintended side effects in your program.
*/


//Question 4 End:






//Question 5 Start:
using System;

namespace ConsoleApp10
{
    public interface IWalkable
    {
        void Walk();
    }

    public class Robot : IWalkable
    {
        // Robot's own method
        public void Walk()
        {
            Console.WriteLine("Robot is walking using its own method.");
        }

        // Explicit interface implementation
        void IWalkable.Walk()
        {
            Console.WriteLine("Robot is walking using IWalkable interface method.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Robot myRobot = new Robot();
            myRobot.Walk(); // Calls Robot's own method

            IWalkable walkableRobot = myRobot;
            walkableRobot.Walk(); // Calls IWalkable interface method
        }
    }
}


/*How Does Explicit Interface Implementation Help in Resolving Naming Conflicts?
Explicit interface implementation helps in
resolving naming conflicts by allowing a class
to implement interface methods without
exposing them as part of the class's public API. This means that the class
can have its own methods with the same names as the interface methods,
but they can be called differently depending on the context.
*/


//Question 5 End:






//Question 6 Start:
using System;

namespace ConsoleApp10
{
    public struct Account
    {
        private int accountId;
        private string accountHolder;
        private double balance;

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public string AccountHolder
        {
            get { return accountHolder; }
            set { accountHolder = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public Account(int id, string holder, double bal)
        {
            accountId = id;
            accountHolder = holder;
            balance = bal;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Account myAccount = new Account(1, "John Doe", 1000.50);

            Console.WriteLine($"Account ID: {myAccount.AccountId}");
            Console.WriteLine($"Account Holder: {myAccount.AccountHolder}");
            Console.WriteLine($"Balance: {myAccount.Balance}");

            // Modify the balance
            myAccount.Balance += 500.00;
            Console.WriteLine($"Updated Balance: {myAccount.Balance}");
        }
    }
}


/*Key Difference Between Encapsulation in Structs and Classes
The key difference between encapsulation in structs and classes lies in their
usage and behavior:

Structs: Value types that are typically used for small, lightweight objects.
They are stored on the stack and are copied by value. Encapsulation in structs
is used to ensure that the internal state of the struct is protected and can
only be accessed or modified through public properties.

Classes: Reference types that are used for more complex objects.
They are stored on the heap and are copied by reference. Encapsulation
in classes provides the same benefits as in structs, but classes also
support inheritance and polymorphism, which structs do not.
*/



/*Abstraction and Its Relation with Encapsulation
Abstraction is a guideline that focuses on exposing only the essential features
of an object while hiding the unnecessary details. It allows you to define
a clear interface for interacting with an object without needing to
understand its internal workings.

Relation with Encapsulation:

Encapsulation is a technique used to achieve abstraction.
By encapsulating the internal state and behavior of an object,
you hide its complexity and expose only what is necessary through public
methods and properties.

Abstraction defines what an object does, while encapsulation defines how
it does it. Together, they help in creating a clear and maintainable code
structure by separating the interface from the implementation.
*/



//Question 6 End:










//Question 7 Start:
using System;

namespace ConsoleApp10
{
    public interface ILogger
    {
        void Log(string message)
        {
            Console.WriteLine($"Default Log: {message}");
        }
    }

    public class ConsoleLogger : ILogger
    {
        void ILogger.Log(string message)
        {
            Console.WriteLine($"Console Log: {message}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.Log("This is a test message.");
        }
    }
}


/*How Do Default Interface Implementations Affect Backward Compatibility in C#?
Default interface implementations in C# allow you to add new methods
to an interface with a default behavior without breaking existing implementations.
This means that if you add a new method to an interface,
existing classes that implement the interface do not need to provide
an implementation for the new method immediately. This helps in maintaining
backward compatibility by allowing the interface to evolve over time
without forcing all implementing classes to be updated simultaneously.
*/

//Question 7 End:




//Question 8 Start:
using System;

namespace ConsoleApp10
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book()
        {
            Title = "Unknown Title";
            Author = "Unknown Author";
        }

        public Book(string title)
        {
            Title = title;
            Author = "Unknown Author";
        }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book();
            Console.WriteLine($"Title: {book1.Title}, Author: {book1.Author}");

            Book book2 = new Book("1984");
            Console.WriteLine($"Title: {book2.Title}, Author: {book2.Author}");

            Book book3 = new Book("To Kill a Mockingbird", "Harper Lee");
            Console.WriteLine($"Title: {book3.Title}, Author: {book3.Author}");
        }
    }
}


/*How Does Constructor Overloading Improve Class Usability?
Constructor overloading improves class usability by providing multiple ways
to create instances of a class, depending on the available information.
This flexibility allows users of the class to initialize objects in different ways,
making the class more versatile and easier to use. It also helps in reducing
the need for setting properties after object creation, leading to cleaner
and more readable code.
*/


//Question 8 End: