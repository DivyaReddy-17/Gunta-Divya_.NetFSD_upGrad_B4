/*Week_4_Day_3_Hands_On_Gunta_Divya
 * using Week_4_Day_3_p6;

Scenario:
A vehicle rental company wants a system where different vehicle types calculate rental charges differently.
Requirements:
1.Create a base class Vehicle with properties Brand and RentalRatePerDay.
2. Create derived classes Car and Bike.
3. Override CalculateRental(int days) method.
4. Car adds insurance charge of 500 per rental.
5. Bike offers 5% discount on total rental.
Technical Constraints:
• Use encapsulation with proper access modifiers.
• Apply runtime polymorphism.
• Validate number of rental days.
Expectations:
• Use base class reference to call overridden methods.
• Implement clean class hierarchy.
• Display final rental cost.
Learning Outcome:
• Master inheritance and polymorphism.
• Implement real-world OOP scenarios.
• Improve object-oriented design skills.
Sample Input: 
Car RentalRatePerDay = 2000, Days = 3
Sample Output: 
Total Rental = 6500
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Day_3_p6
{
    //Here I am creating the class named Vehicle.
    //here I am using the multilevel of inheritance.
    class Vehicle
    {
        //here I am providing rentalRatePerDat as private
        private double rentalRatePerDay;
        public string Brand { get; set; }
        //accessing through public
        public double RentalRatePerDay
        {
            get { return rentalRatePerDay; }
            set
            {
                if (value< 0)
                {
                    Console.WriteLine("Rental rate can't be nagative");
                }
                else
                {
                    rentalRatePerDay = value;
                }
            }
        }
        //Here I am creating the method named CalculateRental for calculations.
        public virtual double CalculateRental(int days)
        {
            return rentalRatePerDay * days;
        }
    }
    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if(days< 0)
            {
                Console.WriteLine("invalid number of days");
                return 0;
            }
            else
            {
                double total = RentalRatePerDay * days;
                return total + 500;
            }
        }
    }
    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if (days < 0)
            {
                Console.WriteLine("Invalid number of days");
                return 0;
            }
            else
            {
                double total = RentalRatePerDay * days;
                return total - (total * 0.05);
            }

        }
    }

        internal class Week_4_p6
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter car rental per day");
                double carrent = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter a number of days");
                int days = Convert.ToInt32(Console.ReadLine());
                Vehicle car = new Car();
                car.RentalRatePerDay = carrent;
                //car.CalculateRental(days);
                Console.WriteLine($"Total Rental = {car.CalculateRental(days)}");

            }
        }
    }

