using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Console_3.MethodHiding
{
    using System;

    class BaseClass
    {
        public void Show()  // Normal method in base class
        {
            Console.WriteLine("BaseClass Show() method");
        }

        public virtual void DoWork()  // Normal method in base class
        {
            Console.WriteLine("BaseClass DoWork() method");
        }
    }

    class DerivedClass : BaseClass
    {
        public new void Show()  // Hiding the base class method
        {
            Console.WriteLine("DerivedClass Show() method");
        }

        public override void DoWork() {
            Console.WriteLine("DerivedClass DoWork() method");
        }
    }

    class Program
    {
        public static void Main()
        {
            BaseClass baseObj = new BaseClass();
            DerivedClass derivedObj = new DerivedClass();
            BaseClass baseRefDerived = new DerivedClass(); // Base class reference to derived object

            // Hiding
            baseObj.Show();         // Output: BaseClass Show()
            derivedObj.Show();       // Output: DerivedClass Show()
            baseRefDerived.Show();   // Output: BaseClass Show() → Calls base class method!


            // Overriding
            baseObj.DoWork();       // Output: BaseClass DoWork()
            derivedObj.DoWork();     // Output: DerivedClass DoWork()
            baseRefDerived.DoWork(); // Output: DerivedClass DoWork() → Calls derived class method!
        }
    }

}
