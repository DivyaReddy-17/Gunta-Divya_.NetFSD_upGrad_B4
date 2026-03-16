/*Week_4_Day_5_Hands_on_Gunta_Divya
 * using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

Scenario:
A calculator application must perform division operations safely. If the user enters an invalid value or tries to divide by zero, the system should handle the error gracefully instead of crashing.
Requirements:
1.Create a class Calculator.
2.Create a method Divide(int numerator, int denominator).
3.	Use try-catch-finally blocks to handle errors.
4.	If the denominator is zero, display an appropriate error message.
5.	Ensure the program continues execution after handling the error.
Technical Constraints:
1.Use try-catch-finally blocks for exception handling.
2.Handle DivideByZeroException.
3.Ensure the finally block always executes.
Expectations:
•	Demonstrate proper use of try-catch-finally blocks.
•	Display meaningful error messages.
•	Ensure program stability even when errors occur.
Learning Outcome:
•	Understand basic exception handling.
•	Use try-catch-finally blocks effectively.
•	Handle runtime errors safely.
Sample Input:
Numerator = 20
 Denominator = 0
Sample Output:
Error: Cannot divide by zero
 Operation completed safely
*/

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Day_5
{
    //creating calss name as Calculator
    class Calculator
    {
        //method name is Divide by passing parameters like numerator and denomenator
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine("Result" + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Can not devide by Zero");
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }
    internal class Week_4_Day_5_Problem1
    {
        static void Main(string[] args)
        {
            Calculator objCalcultaor = new Calculator();
            Console.WriteLine("enter numerator");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter denominator");
            int den = Convert.ToInt32(Console.ReadLine());
            //we are calling the method of divide my passing the arguements like num,den
            objCalcultaor.Divide(num, den);

        }
    }
}

