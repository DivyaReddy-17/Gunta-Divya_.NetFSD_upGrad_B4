/*Scenario
You are developing a console-based application in .NET 8 for a school. The application should evaluate a student’s marks and assign a grade based on predefined rules.

Requirements

• Accept student name and marks (0-100).
• Use if-else statements to determine grade.
• Display grade as A, B, C, D or Fail.
• Handle invalid input using conditional checks.
Technical Constraints
• Use C# (.NET 8 Console Application).
• Use appropriate data types (string, int).
• Use if-else control flow.
• Do not use advanced concepts like classes or LINQ.

Sample Input

Enter Name: Rahul
Enter Marks: 78
Sample Output
Student: Rahul
Grade: B

Expectations

Program should correctly evaluate grade and handle edge cases like marks below 0 or above 100.
Learning Outcome
Understand variables, data types, input/output handling and if-else control statements in C#.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Upd
{
    internal class Week_4_Day_1_p1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Pls enter a correct name");
            }
            else
            {

                Console.WriteLine("Enter Marks(0-100):");
                string marks = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(marks))
                {
                    Console.WriteLine("pls enter marks from 0 to 100");
                }
                else
                {
                    int mark = Convert.ToInt32(marks);

                    if (mark < 0 || mark > 100)
                    {
                        Console.WriteLine("Invalid marks and space pls enter a marks between 0-100");

                    }
                    else
                    {
                        string grade;
                        if (mark >= 90)
                        {
                            grade = "A";
                        }
                        else if (mark >= 75)
                        {
                            grade = "B";

                        }
                        else if (mark >= 60)
                        {
                            grade = "C";
                        }
                        else if (mark >= 50)
                        {
                            grade = "D";
                        }
                        else
                        {
                            grade = "Fail";
                        }
                        Console.WriteLine("Student:" + name);
                        Console.WriteLine("Grade:" + grade);

                    }
                }
                Console.ReadLine();

            }

        }
    }
}

