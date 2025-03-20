using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Console_3.CompileTimePolymorphsim
{
    using System;

    class Calculator
    {
        // Adds two numbers (integers)
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Adds three numbers
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Adds two double numbers
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    class Program
    {
        public static void Main()
        {
            Calculator calc = new Calculator();
            Console.WriteLine(calc.Add(5, 10));          // Calls Add(int, int)
            Console.WriteLine(calc.Add(5, 10, 15));      // Calls Add(int, int, int)
            Console.WriteLine(calc.Add(5.5, 2.5));       // Calls Add(double, double)
        }
    }

}
