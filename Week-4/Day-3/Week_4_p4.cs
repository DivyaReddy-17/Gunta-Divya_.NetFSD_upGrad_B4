
/* Week_4_Day_3_Hands_on_Gunta_Divya
using Week_4_Day_3_p4;
Scenario:
A company wants to calculate employee salaries using inheritance.All employees have a base salary, but different roles calculate bonuses differently.
Requirements:
1.Create a base class Employee with Name and BaseSalary properties.
2. Create derived classes Manager and Developer.
3. Override a virtual method CalculateSalary().
4. Manager gets 20% bonus, Developer gets 10% bonus.
Technical Constraints:
• Use inheritance and method overriding.
• Apply polymorphism using base class reference.
• Use properties for salary details.
Expectations:
• Demonstrate runtime polymorphism.
• Avoid code duplication.
• Display final calculated salary.
Learning Outcome:
• Understand inheritance hierarchy.
• Implement polymorphism using virtual and override.
• Write reusable and extensible code.
Sample Input: 
BaseSalary = 50000
Sample Output: 
Manager Salary = 60000, Developer Salary = 55000
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Day_3_p4
{
    //Creating the class name called Employee
    class Employee
    {
        //Here I am giving the Name and BaseSalary through properties.
        public String Name { get; set; }
        public double BaseSalary { get; set; }
        //Creating a Method called Calculatesalary for parent
        public virtual double Calculatesalary()
        {
            return BaseSalary;
        }
    }
    //Here we are inheritance the Manager class by Override keyword  to hick increment of 20% to the basesalary.
    class Manager : Employee
    {
        public override double Calculatesalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }
    //Here we are inheritance the Developer class by Override keyword  to hick increment of 10% to the basesalary.

    class Developer : Employee
    {
        public override double Calculatesalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }

    internal class Week_4_p4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a BaseSalary");
            double salary=Convert.ToDouble(Console.ReadLine());
            //here I am creating the object with Emplyee but reference to be Manager.
            Employee manager = new Manager();
            manager.BaseSalary = salary;
            Employee developer = new Developer();
            developer.BaseSalary = salary;
            Console.WriteLine($"Manager Salary = {manager.Calculatesalary()}");
            Console.WriteLine($"Developer Salary = {developer.Calculatesalary()}");

        }
    }
}
