using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingConsole
{
    public class Product
    {
        public string name = null!;

        string description = null!;

        string manufacturer = null!;
    }

    internal class Mobile: Product
    {
        string model = null!;
        string color  = null!  ;
        string imei = null!;
    }

    internal class Laptop: Product
    {
        string model = null!;
        string color = null!;
        string serialNumber = null!;
    }

    internal class Desktop : Product
    {
        string model = null!;
        string color = null!;
        string serialNumber = null!;
    }
}
