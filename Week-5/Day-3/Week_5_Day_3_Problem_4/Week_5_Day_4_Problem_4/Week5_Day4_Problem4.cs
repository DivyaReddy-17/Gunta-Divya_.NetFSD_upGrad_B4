using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Day_4_Problem_4
{
    internal class Week5_Day4_Problem4
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            // Calculation
            double discountAmount = (price * discount) / 100;
            double finalPrice = price - discountAmount;

            // Output
            Console.WriteLine("\n--- Bill Details ---");
            Console.WriteLine($"Product: {productName}");
            Console.WriteLine($"Original Price: {price}");
            Console.WriteLine($"Discount: {discount}%");
            Console.WriteLine($"Final Price: {finalPrice}");

            Console.ReadLine();
        }
    }
    
}
