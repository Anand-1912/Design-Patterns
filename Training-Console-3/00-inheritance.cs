using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Console_3.Version
{
    // Base class
    public class BankAccount
    {
        public string AccountHolder { get; set; } = null!;
        public decimal Balance { get; protected set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"{AccountHolder} deposited {amount:C}. New balance: {Balance:C}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"{AccountHolder} withdrew {amount:C}. Remaining balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine($"Insufficient funds for {AccountHolder}.");
            }
        }
    }

    // Derived class - SavingsAccount
    public class SavingsAccount : BankAccount
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
    public class CurrentAccount : BankAccount
    {
        public override void Withdraw(decimal amount)
        {
            Console.WriteLine("Overdraft feature allowed in Current Account.");
            Balance -= amount;
            Console.WriteLine($"{AccountHolder} withdrew {amount:C}. New balance: {Balance:C}");
        }
    }

    // Usage
    class Program
    {
        static void Main()
        {
            SavingsAccount savings = new SavingsAccount { AccountHolder = "John Doe", InterestRate = 5 };
            savings.Deposit(1000);
            savings.ApplyInterest();
            savings.Withdraw(200);

            CurrentAccount current = new CurrentAccount { AccountHolder = "Jane Smith" };
            current.Deposit(500);
            current.Withdraw(700);
        }
    }

}
