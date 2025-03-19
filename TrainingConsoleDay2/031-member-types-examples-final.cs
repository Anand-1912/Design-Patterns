using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingConsoleDay2
{
    using System;
    using System.Collections.Generic;

    class BankAccount
    {
        // 🔹 Fields
        private decimal _balance = 0;
        private string _accountHolder = "";
        private List<Transaction> _transactions = new List<Transaction>();

        // 🔹 Constants
        public const string BankName = "Global Bank";
        public const decimal MinBalance = 100;

        // 🔹 Properties (Encapsulation)
        public decimal Balance
        {
            get => _balance;
            private set
            {
                _balance = value;
                if (_balance < MinBalance)
                {
                    OnBalanceLow?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public string AccountHolder
        {
            get => _accountHolder;
            set => _accountHolder = value;
        }

        // 🔹 Event
        public event EventHandler? OnBalanceLow;

        // 🔹 Constructor (Default)
        public BankAccount()
        {
            _balance = MinBalance;
            Console.WriteLine("New account created with minimum balance.");
        }

        // 🔹 Constructor (Parameterized)
        public BankAccount(string name, decimal initialDeposit)
        {
            _accountHolder = name;
            _balance = initialDeposit;
            Console.WriteLine($"Account created for {name} with balance: ${initialDeposit}");
        }

        // 🔹 Method: Deposit Money
        public void Deposit(decimal amount)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, "Deposit"));
            Console.WriteLine($"Deposited: ${amount}. New Balance: ${Balance}");
        }

        // 🔹 Method: Withdraw Money
        public void Withdraw(decimal amount)
        {
            if (Balance - amount >= MinBalance)
            {
                Balance -= amount;
                _transactions.Add(new Transaction(amount, "Withdraw"));
                Console.WriteLine($"Withdrew: ${amount}. New Balance: ${Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance! Maintain minimum balance.");
            }
        }

        // 🔹 Method: Show Account Details
        public void ShowDetails()
        {
            Console.WriteLine($"Account Holder: {_accountHolder}");
            Console.WriteLine($"Bank: {BankName}");
            Console.WriteLine($"Balance: ${Balance}");
        }

        // 🔹 Indexer: Access Transaction History
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < _transactions.Count)
                    return _transactions[index].ToString();
                return "Invalid transaction index.";
            }
        }

        // 🔹 Operator Overloading: Merge Two Accounts
        public static BankAccount operator +(BankAccount acc1, BankAccount acc2)
        {
            return new BankAccount($"{acc1.AccountHolder} & {acc2.AccountHolder}", acc1.Balance + acc2.Balance);
        }

        // 🔹 Operator Overloading: Compare Two Accounts
        public static bool operator ==(BankAccount acc1, BankAccount acc2)
        {
            return acc1.Balance == acc2.Balance;
        }

        public static bool operator !=(BankAccount acc1, BankAccount acc2)
        {
            return !(acc1 == acc2);
        }

        // 🔹 Finalizer (Destructor)
        ~BankAccount()
        {
            Console.WriteLine($"Account {_accountHolder} is being closed.");
        }

        // 🔹 Nested Type: Transaction Record
        public class Transaction
        {
            public decimal Amount { get; }
            public string Type { get; }
            public DateTime Date { get; }

            public Transaction(decimal amount, string type)
            {
                Amount = amount;
                Type = type;
                Date = DateTime.Now;
            }

            public override string ToString()
            {
                return $"{Date}: {Type} of ${Amount}";
            }
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    //class Program
    //{
    //    static void Main()
    //    {
    //        BankAccount acc1 = new BankAccount("Alice", 500);
    //        acc1.OnBalanceLow += (sender, e) => Console.WriteLine("Warning: Low Balance!");

    //        acc1.Deposit(200);
    //        acc1.Withdraw(650);
    //        acc1.ShowDetails();

    //        Console.WriteLine("Transaction History:");
    //        Console.WriteLine(acc1[0]);  // Access first transaction

    //        BankAccount acc2 = new BankAccount("Bob", 700);
    //        BankAccount mergedAcc = acc1 + acc2;  // Merge two accounts

    //        Console.WriteLine($"Merged Account Balance: ${mergedAcc.Balance}");

    //        if (acc1 == acc2)
    //            Console.WriteLine("Both accounts have the same balance.");
    //    }
    //}

}
