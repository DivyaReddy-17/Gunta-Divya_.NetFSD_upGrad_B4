/*Week_4_Day_4_Problem_2
 * using System.Buffers.Text;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;
Scenario:
Design a simple text editor undo feature using Stack (LIFO principle).
Requirements:
-Implement stack using arrays.
-Support push(add action) and pop(undo action).
-Display current state after each operation.
Technical Constraints:
-Only array - based stack implementation.
-Must follow LIFO order strictly.
- Handle empty stack condition.
Sample Input:
Actions: Type A, Type B, Type C, Undo, Undo
Sample Output:
Current State After Operations: Type A
Expectations:
-Correct LIFO implementation.
-Proper error handling.
-Clear logic structure.
Learning Outcome:
-Understand stack operations.
-Learn LIFO principle application.
- Implement stack using arrays.
*/






using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Day_4_Problem_2
{
    internal class Week4_Day4_Problem2
    {
        static string[] stack = new string[10];
        //here I am checking the stck is empty
        static int top = -1;
        //Here I am pusinh the action
        static void Push(string action)
        {
            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow! Cannot add more actions.");
                return;
            }

            stack[++top] = action;
            Console.WriteLine($"Action: {action}");
            Display();
        }
        static void Pop()
        {
            //here if the stack is empty no element is there for pop then it return stack underflow.
            if (top == -1)
            {
                Console.WriteLine("stack underflow");
                return;
            }
            //it will remove from top element.

            Console.WriteLine($"undo:{stack[top--]}");
            Display () ;
        }
        static void Display()
        {
            if (top == -1)
            {
                Console.WriteLine("current state is empty");
                return;
            }
            //if we remove the elements then here we are checking what is its current state.
            Console.Write("Current State: ");
            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            Push("Type A");
            Push("Type B");
            Push("Type C");
            Pop();
            Pop();

            Console.ReadLine();
        }




    }
}
