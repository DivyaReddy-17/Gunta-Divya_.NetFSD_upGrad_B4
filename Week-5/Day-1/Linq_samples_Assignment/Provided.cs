/*Week_5_Day_1_Hands_on_Gunta_Divya*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_samples_Assignment
{
    class Product
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProCategory { get; set; }
        public double ProMrp { get; set; }
    }

    internal class Provided
    {
        static void Main()
        {
            var products = GetProducts();

            //1.Write a LINQ query to search and display all products with category “FMCG”.
            Console.WriteLine("1.Displaying Products with category FMCG");
            var q1 = products.Where(p => p.ProCategory == "FMCG");
            foreach (var p in q1)
            {
                Console.WriteLine($"{p.ProCode} {p.ProName} {p.ProMrp}");
            }

            //2.Write a LINQ query to search and display all products with category “Grain”.
            Console.WriteLine("\n2.Displaying Products with category Grain");
            var q2 = products.Where(p => p.ProCategory == "Grain");
            foreach (var p in q2)
            {
                Console.WriteLine($"{p.ProCode} {p.ProName} {p.ProMrp}");
            }

            //3.Write a LINQ query to sort products in ascending order by product code.
            Console.WriteLine("\n3. Sorting products by Product Code");
            var q3 = products.OrderBy(p => p.ProCode);
            foreach (var p in q3)
            {
                Console.WriteLine($"{p.ProCode} {p.ProName}");
            }

            //4.Write a LINQ query to sort products in ascending order by product Category.
            Console.WriteLine("\n4.sort products in ascending order by product category");
            var q4 = products.OrderBy(p => p.ProCategory);
            foreach (var p in q4)
                Console.WriteLine($"{p.ProCategory} {p.ProName}");

            //5. Write a LINQ query to sort products in ascending order by product Mrp.
            Console.WriteLine("\n5. Sort products by ascending with MRP");
            var q5 = products.OrderBy(p => p.ProMrp);
            foreach (var p in q5)
                Console.WriteLine($"{p.ProName} {p.ProMrp}");

            //6. Write a LINQ query to sort products in descending order by product Mrp.
            Console.WriteLine("\n6. Sort by MRP Descending");
            var q6 = products.OrderByDescending(p => p.ProMrp);
            foreach (var p in q6)
                Console.WriteLine($"{p.ProName} {p.ProMrp}");

            //7. Write a LINQ query to display products group by product Category.
            Console.WriteLine("\n7. Group by Category");
            var q7 = products.GroupBy(p => p.ProCategory);
            foreach (var group in q7)
            {
                Console.WriteLine(group.Key);
                foreach (var p in group)
                    Console.WriteLine($"{p.ProName} {p.ProMrp}");
            }

            //8. Write a LINQ query to display products group by product Mrp.
            Console.WriteLine("\n8. Group by MRP");
            var q8 = products.GroupBy(p => p.ProMrp);
            foreach (var group in q8)
            {
                Console.WriteLine("Price: " + group.Key);
                foreach (var p in group)
                    Console.WriteLine($"   {p.ProName}");
            }

            //9. Write a LINQ query to display product detail with highest price in FMCG category.
            Console.WriteLine("\n9. Highest price in FMCG");
            var q9 = products
                     .Where(p => p.ProCategory == "FMCG")
                     .OrderByDescending(p => p.ProMrp)
                     .First();
            Console.WriteLine($"{q9.ProName} {q9.ProMrp}");

            //10. Write a LINQ query to display count of total products.
            Console.WriteLine("\n10. Total Products");
            var q10 = products.Count();
            Console.WriteLine(q10);

            //11. Write a LINQ query to display count of total products with category FMCG.
            Console.WriteLine("\n11. FMCG Products Count");
            var q11 = products.Count(p => p.ProCategory == "FMCG");
            Console.WriteLine(q11);

            //12.Write a LINQ query to display Max price.
            Console.WriteLine("\n12. Max Price");
            var q12 = products.Max(p => p.ProMrp);
            Console.WriteLine(q12);

            //13.Write a LINQ query to display Min price.
            Console.WriteLine("\n13. Min Price");
            var q13 = products.Min(p => p.ProMrp);
            Console.WriteLine(q13);

            //14.Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
            Console.WriteLine("\n14. All products below Rs.30?");
            var q14 = products.All(p => p.ProMrp < 30);
            Console.WriteLine(q14);

            //15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.
            Console.WriteLine("\n15. Any products below Rs.30?");
            var q15 = products.Any(p => p.ProMrp < 30);
            Console.WriteLine(q15);


            Console.ReadLine();
        }

        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001, ProName="Colgate-100gm", ProCategory="FMCG", ProMrp=55},
                new Product{ProCode=1002, ProName="Rice Bag", ProCategory="Grocery", ProMrp=850},
                new Product{ProCode=1003, ProName="Soap", ProCategory="FMCG", ProMrp=40},
                new Product{ProCode=1004, ProName="Shampoo", ProCategory="FMCG", ProMrp=120}
            };
        }

    }
}