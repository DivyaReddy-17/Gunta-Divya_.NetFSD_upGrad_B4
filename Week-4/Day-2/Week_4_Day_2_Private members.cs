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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_oops
{
    class Calculating
    {
        private int a;
        private int b;
        public void Readvalues()
        {
            Console.WriteLine("Enter a number");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a Second number");
            b =Convert.ToInt32(Console.ReadLine());
        }
        public int Add()
        {
            return a + b;
        }
        public int Subtract()
        {
            return a-b; 
        }
        
    }
    internal class Week_4_Day_2_Private_members
    {
        static void Main()
        {
            Calculating obj2= new Calculating();
            obj2.Readvalues();
            Console.WriteLine("sum =" + obj2.Add());
            Console.WriteLine("difference=" + obj2.Subtract());
        }

    }
}
