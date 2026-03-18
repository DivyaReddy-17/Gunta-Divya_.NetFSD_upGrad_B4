/*Level - 1 Problem 2: Asynchronous File Logger
Scenario:
An application writes logs to a file whenever an event occurs. Writing logs synchronously can slow down the application. Asynchronous file writing improves performance.

Requirements:
-Create an asynchronous method WriteLogAsync(string message).
- The method should simulate file writing using Task.Delay().
- Call this method multiple times to simulate logging different events.

Technical Constraints:
-Use async and await keywords.
- Use Task.Delay() to simulate file I/O.
- Use a console application.

Expectations:
-Logs should be written asynchronously.
- The main thread should remain responsive while logging operations occur.

Learning Outcome:
Students will learn how asynchronous operations improve performance when dealing with I/O operations.
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Day_3_Problem_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application started");
            Task l1 = WriteLogAsync("User logged in");
            Task l2 = WriteLogAsync("File Uploaded");
            Task l3 = WriteLogAsync("Payment Proceed");
            Console.WriteLine("Main thread is free to do other work");
            await Task.WhenAll(l1, l2, l3);
            Console.WriteLine("All logs written successfully");
        }
        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Log started:{message}");
            await Task.Delay(5000);
            Console.WriteLine($"Log completed :{message}");
        }
        
    }
}
