/*using ConsoleApp1_oops;

Scenario:
A small retail shop wants a simple calculator application to perform addition and subtraction operations using reusable methods.
Requirements:
1.Create a class named Calculator.
2.Create methods Add(int a, int b) and Subtract(int a, int b).
3.Each method should return the result.
4. In Main(), create an object and call the methods.
5. Display the output.
Technical Constraints:
1.Use method parameters and return types properly.
2. Use appropriate access modifiers.
3. No global variables allowed.
Expectations:
Proper method definition, object creation, and method invocation.
Learning Outcome:
Understand functions, parameters, return types, classes, and objects.
Sample Input: 10 5
Sample Output: Addition = 15, Subtraction = 5

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_oops
{
    class Calculator
    {
        public int Add(int num1,int num2)
        {
            return num1 + num2; 
        }
        public int Subtract(int num1,int num2)
        {
            return num1-num2; 
        }
    }
    internal class Week_4_Day_2_p1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a first number");
            int input1= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a Second number");
            int input2= Convert.ToInt32(Console.ReadLine());
            Calculator obj1= new Calculator();
            //int sum = obj1.Add(input1,input2);
            //int diff = obj1.Subtract(input1,input2);
            Console.WriteLine($"Addition= " + obj1.Add(input1, input2));
            Console.WriteLine($"Subtraction= " + obj1.Subtract(input1,input2));
        }

    }
}
