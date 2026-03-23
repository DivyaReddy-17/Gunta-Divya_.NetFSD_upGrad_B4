/*using System.Buffers.Text;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;
Scenario:
An e-commerce system processes customer orders. Each order requires multiple steps such as payment verification, inventory check, and order confirmation. These steps involve delays and should be handled asynchronously.

Requirements:
-Create asynchronous methods:
  -VerifyPaymentAsync()
  - CheckInventoryAsync()
  - ConfirmOrderAsync()
- Simulate processing delays using Task.Delay().
- Execute steps asynchronously while maintaining the logical order of operations.

Technical Constraints:
-Use async and await.
- Use Task-based asynchronous methods.
- Implement using a console application.

Expectations:
-Each processing step should run asynchronously.
- The program should display messages indicating the progress of order processing.

Learning Outcome:
Students will understand how to design real-world workflows using asynchronous methods with async/await.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Day_4_Problem_3
{
        

    internal class Week5_Day4_Problem3
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Order processing started");
            try
            {
                await ProcessOrderAsync();
                Console.WriteLine("order processing completed successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }
            Console.ReadLine();
        }
        static async Task ProcessOrderAsync()
        {
            bool paymentStatus = await VerifyPaymentAsync();
            if (!paymentStatus)
            {
                Console.WriteLine("pyament failed order is cancelled");
                return;
            }
            bool inventorStatus = await CheckInventoryAsync();
            if (!inventorStatus)
            {
                Console.WriteLine("item out of stock,order is cancelled");
                return;
            }
            await ConfirmOrderAsync();
        }
        static async Task<bool> VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying payment...");
            await Task.Delay(2000); // Simulate delay
            Console.WriteLine("Payment verified.");
            return true;
        }
        static async Task<bool> CheckInventoryAsync()
        {
            Console.WriteLine("Checking inventory...");
            await Task.Delay(2000); // Simulate delay
            Console.WriteLine("Inventory available.");
            return true;
        }
        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming order...");
            await Task.Delay(1500); // Simulate delay
            Console.WriteLine("Order confirmed!");
        }
    }

}
