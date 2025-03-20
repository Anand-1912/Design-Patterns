using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Console_3.TypeCasting
{
    using System;

    class Distance
    {
        public int Meters { get; set; }

        // Implicit conversion from int to Distance (static)
        public static implicit operator Distance(int meters)
        {
            return new Distance { Meters = meters };
        }

        // Explicit conversion from Distance to int (static)
        public static explicit operator int(Distance d)
        {
            return d.Meters;
        }
    }

    class Program
    {
        public static void Main()
        {
            // Implicit conversion: int to Distance
            Distance d1 = 100;  // Uses implicit operator
            Console.WriteLine($"Distance in Meters: {d1.Meters}");  // Output: 100

            // Explicit conversion: Distance to int
            int meters = (int)d1;  // Uses explicit operator
            Console.WriteLine($"Meters: {meters}");  // Output: 100
        }
    }

}
