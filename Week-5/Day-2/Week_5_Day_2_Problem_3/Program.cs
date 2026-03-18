/*Employee Performance Evaluator using Tuples and Pattern Matching(Level-1)
Scenario
A small company wants a simple program that evaluates an employee's performance based on two inputs: monthly sales amount and customer feedback rating.
The system should return both values together using a Tuple, and then determine the performance category using pattern matching.
This will help management quickly identify whether an employee is a High Performer, Average Performer, or Needs Improvement.
Requirements


1.	Accept the following inputs from the user:
o Employee Name
o	Monthly Sales Amount
o	Customer Feedback Rating (1–5)
2.	Create a method that returns Sales Amount and Rating together using a Tuple.
3.Use pattern matching with switch expression or switch statement to categorize performance:
o High Performer → Sales ≥ 100000 AND Rating ≥ 4
o	Average Performer → Sales ≥ 50000 AND Rating ≥ 3
o	Needs Improvement → All other cases
4.	Display:
o Employee Name
o	Sales Amount
o	Rating
o	Performance Category
Technical Constraints
•	The method must return multiple values using Tuple.
•	Pattern matching must be used for performance classification.
•	Avoid using multiple nested if-else statements.
•	Input values must be numeric and valid.
Expectations
•	Students should demonstrate how to create and return tuples from a method.
•	Students should use pattern matching to simplify conditional logic.
•	Output should be clearly formatted.
Example Output:
Employee Name: Rahul
Sales Amount: 120000
Rating: 4
Performance: High Performer
Learning Outcome
After completing this problem, students will be able to:
•	Understand how tuples return multiple values from methods.
•	Apply pattern matching to simplify complex conditions.
•	Write cleaner and more readable decision logic in C#.
*/



using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Day_2_Problem_3
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter employee name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter sales amount");
            double salesamount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("enter rating from(1-5)");
            int rating = Convert.ToInt32(Console.ReadLine());
            var performanceData = GetData(salesamount, rating);
            if (rating < 1 || rating>5)
                {
                Console.WriteLine("Invalid Rating");
                return;
            }
            string category = performanceData switch
            {
                (>= 100000,>= 4)=> "High Performer",
                (>= 50000,>= 3) => "Average performer",
                _ => "Needs Improvement"
            };
            Console.WriteLine("Employee performance report");
            Console.WriteLine($"Employee Name:{name}");
            Console.WriteLine($"Salesamount:{performanceData.salesamount}");
            Console.WriteLine($"Rating:{performanceData.rating}");
            Console.WriteLine($"Performance:{category}");
        }
        static (double salesamount,int rating)GetData(double salesamount, int rating)
        {
            return (salesamount,rating);
        }
    }
}
