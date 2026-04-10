/*using System.Runtime.Intrinsics.X86;
using Week_6_Day_1_Problem2;

Scenario: Discount Calculation System
An e - commerce system calculates discounts for different customer types:
•	Regular Customer
•	Premium Customer
•	VIP Customer
The system should allow adding new discount types without modifying existing code.

Requirements:
1.Create an abstract class or interface:
IDiscountStrategy
2.	Implement discount classes:
•	RegularCustomerDiscount
•	PremiumCustomerDiscount
•	VipCustomerDiscount
3.	Each class should implement a method:
CalculateDiscount(double amount)
Technical Constraints:
•	Use interface or abstract class
•	Existing classes should not be modified when adding new discounts
•	Follow Open for Extension, Closed for Modification
Expectations:
	Students should implement:
•	IDiscountStrategy
•	3 Discount Classes
•	A class that calculates the final price

Program Flow Diagram:
	 
Learning Outcome:
Students will understand:
•	Extending functionality without modifying existing code
•	Use of interfaces and polymorphism
•	Real-world use of Strategy Pattern
*/
namespace Week_6_Day_1_Problem2
{
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }
    public class RegularCustomerDiscount:IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return 0;
        }

    }
    public class PremiumCustomerDiscount:IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10;

        }
    }
    public class VipCustomerDiscount:IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20;
        }
    }
    public class PriceCalculator
    {
        private readonly IDiscountStrategy _discountStrategy;
        public PriceCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }
        public double CalculateFinalPrice(double amount)
        {
            double discount = _discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter an amount");
            double orderAmount=Convert.ToDouble(Console.ReadLine());
            //double orderAmount = 1000;
            IDiscountStrategy regularDiscount = new RegularCustomerDiscount();
            IDiscountStrategy PremiumDiscount = new PremiumCustomerDiscount();
            IDiscountStrategy vipDiscount = new VipCustomerDiscount();
            PriceCalculator regularCalculator = new PriceCalculator(regularDiscount);
            PriceCalculator premiumCalculator = new PriceCalculator(PremiumDiscount);
            PriceCalculator vipCalculator = new PriceCalculator(vipDiscount);
            Console.WriteLine($"order amount:{orderAmount}");
            Console.WriteLine($"regular customer final price:{regularCalculator.CalculateFinalPrice(orderAmount)}");
            Console.WriteLine($"VIP Customer Final Price:{vipCalculator.CalculateFinalPrice(orderAmount)}");
            Console.ReadLine();
        }
       
    }
}
