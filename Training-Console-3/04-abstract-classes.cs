namespace Training_Console_3.Abstraction
{
    // Abstract class
    public abstract class Employee
    {
        public string Name { get; set; } = null!;
        public int ID { get; set; }

        // Abstract method (must be implemented by derived classes)
        public abstract double CalculateSalary();

        // Concrete method (can be used directly)
        public void DisplayInfo()
        {
            Console.WriteLine($"Employee: {Name}, ID: {ID}");
        }
    }

    // Derived class - Full-Time Employee
    public class FullTimeEmployee : Employee
    {
        public double MonthlySalary { get; set; }

        public override double CalculateSalary()
        {
            return MonthlySalary;
        }
    }

    // Derived class - Contract Employee
    public class ContractEmployee : Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }

    // Usage
    public class Program
    {
        public static void Main()
        {
            Employee emp1 = new FullTimeEmployee { Name = "Alice", ID = 101, MonthlySalary = 5000 };
            Employee emp2 = new ContractEmployee { Name = "Bob", ID = 102, HourlyRate = 20, HoursWorked = 160 };

            emp1.DisplayInfo();
            Console.WriteLine($"Salary: {emp1.CalculateSalary():C}");

            emp2.DisplayInfo();
            Console.WriteLine($"Salary: {emp2.CalculateSalary():C}");
        }
    }

}
