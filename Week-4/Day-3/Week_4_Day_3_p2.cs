/*Week_4_Day_3_Hands_on_Gunta_Divya
 * Scenario:
A bank wants to manage customer accounts securely using encapsulation.
Requirements:
1.Create class BankAccount.
2.Private field: balance.
3.Public methods: Deposit(double amount), Withdraw(double amount).
4.Method GetBalance() to return balance.
5. Prevent withdrawal if insufficient balance.
Technical Constraints:
1.Balance must be private.
2.Access balance only through public methods.
3.Use appropriate return types.
Expectations:
Proper use of encapsulation and object-oriented principles.
Learning Outcome:
Understand encapsulation, access modifiers, and secure data handling.
Sample Input: 
Deposit 1000, Withdraw 300
Sample Output: 
Current Balance = 700
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Day_3_p2
{
    //Here I am creating the classname is BankAccount
    class BankAccount
    { 
        private double balance;
            //Method to be deposit the amount
            public void Deposit(double amount)
        {
            balance += amount;
        }
        //Amount to be withdraw from balance.if your entered amount is greater than that of that  balance amount it shows insufficient balance is an error.
        //Otherwise the amount is discharged from that balance.
        public void Withdraw(double amount)
        {
            if(amount>balance)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                balance-=amount;
            }

        }
        //Here I am writing the method to return the balance.
        public double GetBalance()
        {
            return balance;

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount objAccount=new BankAccount();
            Console.WriteLine("Enter the amount to be deposit");
            double amount=Convert.ToDouble(Console.ReadLine());
            //Here I am calling the Deposit method to entering amount
            objAccount.Deposit(amount);
            Console.WriteLine("Enter the amount to be withdraw");
            double wd_amount = Convert.ToDouble(Console.ReadLine());
            //here I am calling the Withdraw method to Withdraw the amount from balance.
            objAccount.Withdraw(wd_amount);
            Console.WriteLine($"Current Balance= {objAccount.GetBalance()}");
        }
    }
}
