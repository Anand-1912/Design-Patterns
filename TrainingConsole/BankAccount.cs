using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingConsole
{
    class BankAccount
    {
        private double balance; // Encapsulation: balance is private

        public void Deposit(double amount)
        {
            FileLogger logger = new FileLogger();
            //Console.WriteLine("Depositing the amount " + amount);
            logger.Log("A deposit has been made with an amount" + amount);
        }

        public void Withdraw(double amount)
        {
            
        }
    }
}
