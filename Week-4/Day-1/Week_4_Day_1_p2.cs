using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Upd
{
    internal class Week_4_Day_1_p2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a first number");
            string input1=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input1))
            {
                Console.WriteLine("enter a crct value");
                    return;
            }

            double a = Convert.ToDouble(input1);
            Console.WriteLine("Enter a second number");
            string input2=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input2))
            {
                Console.WriteLine("pls enter a crct value");
                return;
            }
            double b = Convert.ToDouble(input2);
            Console.WriteLine("Enter a operator (+,-,*,/)");
            string op=Console.ReadLine();
            Char check = Convert.ToChar(op);
            double result = check switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => a / b,
                _ => double.NaN

            };
                if(double.IsNaN(result))
                {
                Console.WriteLine("pls enter a crct one");
                return;
                }
                else
            {
                Console.WriteLine("Result:", +result);
            }
            
        }
    }
}
