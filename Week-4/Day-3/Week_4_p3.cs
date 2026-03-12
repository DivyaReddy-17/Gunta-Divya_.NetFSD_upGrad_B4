/*Week_4_Day_3_Hands_on_Gunta_Divya
 * using System.Security.Principal;

Scenario:
A bank wants to develop a simple console-based application to manage customer bank accounts. The system should protect account balance information and allow controlled access using properties.
Requirements:
1.Create a BankAccount class with private fields for account number and balance.
2.Use properties to allow controlled access to account number and balance.
3.Implement Deposit and Withdraw methods with proper validation.
4.Prevent withdrawal if balance is insufficient.
Technical Constraints:
• Use private fields with public properties.
• Apply encapsulation and data hiding.
• No direct access to balance field from outside the class.
Expectations:
• Demonstrate correct use of access modifiers.
• Validate negative deposit or withdrawal amounts.
• Display updated balance after each transaction.
Learning Outcome:
• Understand encapsulation using properties.
• Apply data hiding effectively.
• Implement validation logic inside class methods.
Sample Input: 
Deposit = 5000, Withdraw = 2000
Sample Output: 
Current Balance = 3000
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Day_3_p3
{
    //Here we are creating the class named BankAccount
    class BankAccount
    {
        //Private Fields
        private int accountnumber;
        private double balance;
        //This is a property is used to accessing private fields.
        public int AccountNumber
        {
            get { return accountnumber; }
            set { accountnumber = value; }
        }
        public double Balance
        {
            get { return balance; }
        }
        //Here I am creating the Deposit method and checking for other conditions.
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid Deposit amount");
            }
            else
            {
                balance += amount;
                Console.WriteLine($"After the amount is deposited the balance amount is = {balance}");

            }
        }
        //Withdraw the amount method
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("pls enter a crct amount to withdraw");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Insufficient fund");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"After the amount is withdraw the balance amount is = {balance}");
            }
        }
    }
    internal class Week_4_p3
    {
        static void Main(string[] args)
        {
            BankAccount objBank = new BankAccount();
            //Console.WriteLine("Enter the account number");
            //int AccountNumber = Convert.ToInt32(Console.ReadLine());
            //objBank.AccountNumber = AccountNumber;

            Console.WriteLine("Enter the amount to be desposit");
            double Amount = Convert.ToDouble(Console.ReadLine());
            objBank.Deposit(Amount);
            Console.WriteLine("Enter the amount to be Withdraw");
            double Wd_amount = Convert.ToDouble(Console.ReadLine());
            objBank.Withdraw(Wd_amount);
            Console.WriteLine($"Current Balance = {objBank.Balance}");

        }
    }
}
