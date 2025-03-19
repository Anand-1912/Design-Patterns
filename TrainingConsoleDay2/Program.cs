
// value types example

// value types are stored in stack memory


using TrainingConsoleDay2;

int num1 = 10;
int num2 = num1; //assigning value of num1 to num2 and not reference

num1 = 20;

Console.WriteLine(num1);
Console.WriteLine(num2);


// passing value types to methods

int num3 = 30;
int num4 = 40;

static void Swap(int num3, int num4)
{
    int temp = num3;
    num3 = num4;
    num4 = temp;
}

Console.WriteLine("Before Swap");
Console.WriteLine(num3);
Console.WriteLine(num4);

Swap(num3, num4);

Console.WriteLine("After Swap");

Console.WriteLine(num3);
Console.WriteLine(num4);


// other value types
// byte, short, int, long, float, double, decimal, char, bool


////--------------------------------------------------------------------------------------------////



// reference types example

// reference types are stored in heap memory

Operands operands1 = new Operands();

operands1.num1 = 10;

operands1.num2 = 20;

Operands operands2 = operands1; //assigning reference of operands1 to operands2

Console.WriteLine("Before changing the value of num1");

Console.WriteLine($"{nameof(operands1)}:{operands1.num1}");
Console.WriteLine($"{nameof(operands2)}:{operands2.num1}");

operands1.num1 = 30;

Console.WriteLine("After changing the value of num1");

Console.WriteLine($"{nameof(operands1)}:{operands1.num1}");
Console.WriteLine($"{nameof(operands2)}:{operands2.num1}");

////--------------------------------------------------------------------------------------------////


// member types - fields, constants, properties, methods, events, constructors, finalizers, indexers, operators, nested types

// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/members



////--------------------------------------------------------------------------------------------////
// private constructors

///var myCar = new Car(); // Error: 'Car.Car()' is inaccessible due to its protection level

var myCar = Car.BuildMyCar()
    .WithMake(Make.Toyota)
    .WithModel(Model.Camry)
    .WithColor(Color.Black);

myCar.DisplayCarDetails();


////--------------------------------------------------------------------------------------------////
// Indexers

var wordDocument = WordDocument.CreateDocument(withNoOfPages: 5);

wordDocument[0] = "This is page 1";
wordDocument[1] = "This is page 2";
wordDocument[2] = "This is page 3";
wordDocument[3] = "This is page 4";
wordDocument[4] = "This is page 5";
wordDocument[5] = "This is page 6"; // Error: Pages exceeded.

////--------------------------------------------------------------------------------------------////
//final-example

BankAccount bankAccount = new(); // Default constructor

bankAccount.OnBalanceLow += SendEmail_OnBalanceLow;
bankAccount.OnBalanceLow += SendSMS_OnBalanceLow;

bankAccount.Deposit(1000);
bankAccount.Withdraw(500);
bankAccount.Withdraw(450);

void SendSMS_OnBalanceLow(object? sender, EventArgs e)
{
    var account = (BankAccount)sender!;

    Console.WriteLine($"Sending SMS to {account.AccountHolder} for low balance. The balance is {account.Balance}");
}

void SendEmail_OnBalanceLow(object? sender, EventArgs e)
{
    var account = (BankAccount)sender!;
    Console.WriteLine($"Sending Email to {account.AccountHolder} for low balance. The balance is {account.Balance}");
}