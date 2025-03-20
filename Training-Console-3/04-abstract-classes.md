Which One to Use
Use an Abstract Class When:
✔ You want to provide some common implementation (e.g., a DisplayInfo() method).
✔ You expect future changes to behavior that should apply to all derived classes.
✔ You need protected/private members or fields.

Use an Interface When:
✔ You only need method declarations, and classes should define their own behavior.
✔ You need multiple inheritance (since C# allows multiple interfaces, but not multiple base classes).
✔ You want to enforce a contract that multiple unrelated classes can implement.

If you need common logic → Use an abstract class.
If you only need a contract (method signatures) → Use an interface.
If you need both, use an interface along with an abstract class!

using System;

public interface IReportable
{
    void GenerateReport();  // Any class implementing this must define GenerateReport
}

public interface IRemoteWorker
{
    void WorkFromHome();  // Defines behavior for remote workers
}

// Abstract class defining common Employee properties
public abstract class Employee
{
    public string Name { get; set; }
    public int ID { get; set; }

    public Employee(string name, int id)
    {
        Name = name;
        ID = id;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Employee: {Name}, ID: {ID}");
    }

    public abstract double CalculateSalary(); // Must be implemented by all child classes
}

// Full-time employee (inherits from Employee and implements IReportable)
public class FullTimeEmployee : Employee, IReportable, IRemoteWorker
{
    public double MonthlySalary { get; set; }

    public FullTimeEmployee(string name, int id, double salary) : base(name, id)
    {
        MonthlySalary = salary;
    }

    public override double CalculateSalary() => MonthlySalary;

    public void GenerateReport()
    {
        Console.WriteLine($"{Name} (Full-Time) generated a performance report.");
    }

    public void WorkFromHome()
    {
        Console.WriteLine($"{Name} (Full-Time) is working remotely today.");
    }
}

// Contract employee (inherits from Employee but does NOT generate reports)
public class ContractEmployee : Employee, IRemoteWorker
{
    public double HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public ContractEmployee(string name, int id, double hourlyRate, int hoursWorked) 
        : base(name, id)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override double CalculateSalary() => HourlyRate * HoursWorked;

    public void WorkFromHome()
    {
        Console.WriteLine($"{Name} (Contract) is working remotely.");
    }
}

// Intern (inherits from Employee and implements IReportable)
public class Intern : Employee, IReportable
{
    public double Stipend { get; set; }

    public Intern(string name, int id, double stipend) : base(name, id)
    {
        Stipend = stipend;
    }

    public override double CalculateSalary() => Stipend;

    public void GenerateReport()
    {
        Console.WriteLine($"{Name} (Intern) submitted an internship report.");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Employee emp1 = new FullTimeEmployee("Alice", 101, 5000);
        Employee emp2 = new ContractEmployee("Bob", 102, 20, 160);
        Employee emp3 = new Intern("Charlie", 103, 1000);

        emp1.DisplayInfo();
        Console.WriteLine($"Salary: {emp1.CalculateSalary():C}");
        
        emp2.DisplayInfo();
        Console.WriteLine($"Salary: {emp2.CalculateSalary():C}");
        
        emp3.DisplayInfo();
        Console.WriteLine($"Salary: {emp3.CalculateSalary():C}");

        Console.WriteLine("\n**Report Generation**");
        if (emp1 is IReportable r1) r1.GenerateReport();
        if (emp3 is IReportable r2) r2.GenerateReport();

        Console.WriteLine("\n**Remote Work**");
        if (emp1 is IRemoteWorker w1) w1.WorkFromHome();
        if (emp2 is IRemoteWorker w2) w2.WorkFromHome();
    }
}
