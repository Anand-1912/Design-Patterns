using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Console_3
{
    // Base class
    public class BankAccount(string accountHolder)
    {
        protected string accountHolder = accountHolder;
        public decimal Balance { get; protected set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"{accountHolder} deposited {amount:C}. New balance: {Balance:C}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"{accountHolder} withdrew {amount:C}. Remaining balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine($"Insufficient funds for {accountHolder}.");
            }
        }
    }

    // Derived class - SavingsAccount
    public class SavingsAccount(string accountHolder) : BankAccount(accountHolder)
    {
        public decimal InterestRate { get; set; }

        public void ApplyInterest()
        {
            decimal interest = Balance * InterestRate / 100;
            Balance += interest;
            Console.WriteLine($"Interest applied. New balance: {Balance:C}");
        }
    }

    // Derived class - CurrentAccount
    public class CurrentAccount(string accountHolder) : BankAccount(accountHolder)
    {
        public override void Withdraw(decimal amount)
        {
            Console.WriteLine("Overdraft feature allowed in Current Account.");
            Balance -= amount;
            Console.WriteLine($"{accountHolder} withdrew {amount:C}. New balance: {Balance:C}");
        }
    }

    // Usage
    class Program
    {
        static void Main()
        {
            SavingsAccount savings = new("John Doe") { InterestRate = 5 };
            savings.Deposit(1000);
            savings.ApplyInterest();
            savings.Withdraw(200);

            CurrentAccount current = new("Jane Smith");
            current.Deposit(500);
            current.Withdraw(700);
        }
    }

}
