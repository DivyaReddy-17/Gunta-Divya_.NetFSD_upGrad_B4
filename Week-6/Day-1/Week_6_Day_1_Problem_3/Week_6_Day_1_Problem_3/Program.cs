/*using System.Runtime.Intrinsics.X86;
using Week_6_Day_1_Problem_3;

Scenario: Shape Area Calculator
A graphics application calculates the area of different shapes.
Any derived class should be able to replace the base class without breaking functionality.
Requirements:
1.Create a base class or interface:
•	Shape
2.	Derived classes:
•	Rectangle
•	Circle
3.	Each shape should implement:
•	CalculateArea()
4.A method should accept Shape object and calculate area.
Technical Constraints:
•	Use method overriding
•	Derived classes must not break base class behavior
Expectations:
Students should demonstrate that the program works correctly when:
•	Rectangle object is used
•	Circle object is used
Program Flow Diagram:
 

Learning Outcome:
Students will learn:
•	Meaning of substitutability
•	Importance of correct inheritance
•	How polymorphism supports LSP
*/
using Week_6_Day_1_Problem_3;

namespace Week_6_Day_1_Problem_3
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
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
        public override double CalculateArea()
        {
            return (Width * Height);
        }
    }
    public class Circle : Shape
    {
        public double Radious { get; set; }
        public Circle(double radious)
        {
            Radious = radious;
        }
        public override double CalculateArea()
        {
            return Math.PI * Radious * Radious;
        }
    }
    public class AreaCalculator
    {
        public static void PrintArea(Shape shape)
        {
            double area = shape.CalculateArea();
            Console.WriteLine($"the area of {shape.GetType().Name} is :{area:F2}");
        
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        Shape rectangle = new Rectangle(10, 5);
        Shape Circle = new Circle(7);
        AreaCalculator.PrintArea(rectangle);
        AreaCalculator.PrintArea(Circle);
        Console.ReadLine();
        }
    }
}
