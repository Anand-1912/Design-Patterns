using System.Reflection.Metadata.Ecma335;

namespace Training_Console_3.OrderOfExecution
{
    internal class InitialiseOrderExample
    {
        public int _data = Set_data();
        private static int Set_data()
        {
            Console.WriteLine("field initialiser called...");
            return 1;
        }       
        public InitialiseOrderExample() {

            Console.WriteLine("Constructor called...");
            _data = 2;
        }
    }

    public class Program
    {
        public static void Main()
        {
            InitialiseOrderExample obj = new();
        }
    }
}
