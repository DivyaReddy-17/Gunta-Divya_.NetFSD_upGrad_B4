/*Scenario
A financial application needs to process multiple reports simultaneously to reduce waiting time. Instead of executing tasks sequentially, the system should run them concurrently using C# Tasks so that reports are generated faster.

Requirements


1.Create three methods:
a.GenerateSalesReport()
b.GenerateInventoryReport()
c.GenerateCustomerReport()
2.Each method should simulate processing time using Thread.Sleep() or Task.Delay().
3.Execute all three operations concurrently using Task.
4.Display a message when each report starts and when it finishes.
5.	Display a final message once all reports are completed.
Technical Constraints
•	Use Task class from System.Threading.Tasks.
•	Use Task.Run() to execute methods.
•	Use Task.WaitAll() or await Task.WhenAll() to wait for completion.
•	The program must run in a Console Application.
Expectations
The program should start multiple report-generation tasks simultaneously and display completion messages for each report along with a final message once all tasks are completed.
Learning Outcome
Students will learn:
•	How to create and run Tasks in C#
•	How to execute multiple operations concurrently
•	How to wait for multiple tasks to complete
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Week_5_Day_3_Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting report generation");
            Task salesTask = Task.Run(() => GenerateSalesReport());
            Task inventoryTask = Task.Run(() => GenerateInventoryReport());
            Task customerTask = Task.Run(() => GenerateCustomerReport());

            Task.WaitAll(salesTask, inventoryTask, customerTask);
            Console.WriteLine("All reports generated successfully");
        }
        static void GenerateSalesReport()
        {
            Console.WriteLine("Sales report started");
            Thread.Sleep(2000);
            Console.WriteLine("Sales report completed");

        }
        static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory report started");
            Thread.Sleep(2000);
            Console.WriteLine("Inventory report completed");
        }
        static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer report started");
            Thread.Sleep(2000);
            Console.WriteLine("Customer report completed");
        }

        
    }
}
