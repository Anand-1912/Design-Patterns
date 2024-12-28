Object Oriented Programming Principles
======================================

1. Encapsulation
2. Inheritance
3. Polymorphism
4. Abstraction
5. Composition
6. Coupling

Encapsulation
-------------

	- Bundling the data / attributes and the methods / functions that operate on the data into a single unit called Class.
	- Class is a blueprint for creating objects (instances).
	- Encapsulation is the technique of making the fields in a class private (thus hiding internal details) and providing access to the fields via public methods.

	```C#

	public class BadBankAccount
	{
		public string AccountNumber;
		public string AccountHolderName;
		public double Balance;
	}

	BadBankAccount account = new BadBankAccount();
	account.AccountNumber = "123456";
	account.AccountHolderName = "John Doe";
	account.Balance = 1000.00;  // This is bad because we are exposing the fields directly and anyone can change the values.
	

	public class BankAccount
	{
		private string accountNumber;
		private string accountHolderName;
		private double balance;
		public string AccountNumber
		{
			get { return accountNumber; }
			set { accountNumber = value; }
		}
		public string AccountHolderName
		{
			get { return accountHolderName; }
			set { accountHolderName = value; }
		}
		public double Balance
		{
			get { return balance; }
			set { balance = value; }
		}

		public void Deposit(double amount)
		{ 
			if(amount > 0)
				balance += amount;
			else
				throw new ArgumentException("Amount should be greater than zero");
		}

		public void Withdraw(double amount)
		{
			if(amount > 0 && amount <= balance)
				balance -= amount;
			else
				throw new ArgumentException("Amount should be greater than zero and less than balance");
		}
	}
	```C#

Abstraction
-----------
	- Abstraction is a process of hiding the implementation details and showing only functionality to the user.
	- Abstraction lets you focus on what the object does instead of how it does it.
	- Abstraction is achieved using abstract classes and interfaces.
	- Abstract class is a class that can't be instantiated. It is used to provide a common interface for all its subclasses.
    - Reduces the complexity by hiding unnecessary details.

	```C#

	public class BadEmailService{
		
		public void SendEmail(string to, string subject, string body)
		{
			// Code to send email
		}

		public void Connect()
		{
			// Code to connect to email server
		}

		public void Disconnect()
		{
			// Code to disconnect from email server
		}

		public void Authenticate()
		{
			// Code to authenticate
		}
	}

	BadEmailService emailService = new BadEmailService();
	emailService.Connect();
	emailService.Authenticate();
	emailService.SendEmail("john.doe@gmail.com", "Test Email", "This is a test email");
	emailService.Disconnect();

	// In the above example, the user should not be able to call Connect, Authenticate and Disconnect methods directly.
	// These methods should be hidden from the user and should be called internally by the SendEmail method.
	// This is where Abstraction comes into play.

	// Abstraction
	public class EmailService{
		
		public void SendEmail(string to, string subject, string body)
		{
			Connect();
			Authenticate();
			// Code to send email
			Disconnect();
		}
		private void Connect()
		{
			// Code to connect to email server
		}
		private void Disconnect()
		{
			// Code to disconnect from email server
		}
		private void Authenticate()
		{
			// Code to authenticate
		}
	}

	EmailService emailService = new EmailService();
	emailService.SendEmail("john.doe@gmail.com", "Test Email", "This is a test email");

	```C#

Inheritance
-----------
	- Inheritance is a mechanism in which one object acquires all the properties and behaviors of a parent object.
	- It represents the IS-A relationship.
	- Inheritance is a way to reuse code and establish a relationship between classes.
	- Subclass inherits the properties and behaviors of the superclass and can add new properties and behaviors. 
	  They can also override the existing properties and behaviors.

	```C#

    public class BadCar
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }

		public int NumberOfDoors { get; set; }

		public void Start()
		{
			Console.WriteLine("Car is starting");
		}

		public void Stop()
		{
			Console.WriteLine("Car is stopping");
		}

		public void Drive()
		{
			Console.WriteLine("Car is being driven");
		}
	}

	public class BadBike
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }

		public string Type { get; set; }

		public void Start()
		{
			Console.WriteLine("Bike is starting");
		}

		public void Stop()
		{
			Console.WriteLine("Bike is stopping");
		}

		public void Drive()
		{
			Console.WriteLine("Bike is being driven");
		}
	}

	// The above code is bad because there is a lot of code duplication and the code is not reusable.

	// Inheritance

	public class Vehicle
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public void Start()
		{
			Console.WriteLine("Vehicle is starting");
		}
		public void Stop()
		{
			Console.WriteLine("Vehicle is stopping");
		}
		public void Drive()
		{
			Console.WriteLine("Vehicle is being driven");
		}
	}

	public class Car : Vehicle
	{
		public int NumberOfDoors { get; set; }
	}

	public class Bike : Vehicle
	{
		public string Type { get; set; }
	}

	```C#

	Polymorphism
	------------

	- Polymorphism is the ability of an object to take on many forms.
	- Polymorphism allows methods to do different things based on the object that it is acting upon.
	- Polymorphism is achieved by method overriding and method overloading.
	
	```C#


	public class Vehicle{
		
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }

		public virtual void Drive()
		{
			Console.WriteLine("Vehicle is being driven");
		}

		public virtual void Start()
		{
			Console.WriteLine("Vehicle is starting");
		}

		public virtual void Stop()
		{
			Console.WriteLine("Vehicle is stopping");
		}
	}

	public class Car : Vehicle
	{
		public int NumberOfDoors { get; set; }
		public override void Drive()
		{
			Console.WriteLine("Car is being driven");
		}
		public override void Start()
		{
			Console.WriteLine("Car is starting");
		}
		public override void Stop()
		{
			Console.WriteLine("Car is stopping");
		}
	}

	public class Bike : Vehicle
	{
		public string Type { get; set; }
		public override void Drive()
		{
			Console.WriteLine("Bike is being driven");
		}
		public override void Start()
		{
			Console.WriteLine("Bike is starting");
		}
		public override void Stop()
		{
			Console.WriteLine("Bike is stopping");
		}
	}

	public class Plane: Vehicle
	{
		public string Manufacturer { get; set; }

		public override void Drive()
		{
			Console.WriteLine("Plane is being driven");
		}
		public override void Start()
		{
			Console.WriteLine("Plane is starting");
		}
		public override void Stop()
		{
			Console.WriteLine("Plane is stopping");
		}
	}

	List<Vehicles> vehicles = new();

	vehicles.Add(new Car());
	vehicles.Add(new Bike());
	vehicles.Add(new Plane());

	foreach(var vehicle in vehicles)
	{
		vehicle.Start();
		vehicle.Drive();
		vehicle.Stop();
	}


	```C#

	Coupling
	--------

	- Coupling is the degree of dependency between two classes.
	- Loose coupling is desirable because it makes the code more maintainable and flexible.
	- Tight coupling is bad because it makes the code less maintainable and flexible.

	public class EmailSender{
	
	public void SendEmail(string message)
		{
			// Code to send email
		}
	}

	public class OrderProcessor{
			
		public void Process(Order order)
		{
			// Code to process order
			EmailSender emailSender = new EmailSender()
			emailSender.SendEmail($"Your order {order.Id} has been confirmed");
		}
	}	

	// The above code is tightly coupled because the OrderProcessor class is directly creating an instance of EmailSender class.

	// Loose coupling

	public interface INotificationService
	{
		void SendNotification(string message);
	}

	public class EmailSender : INotificationService
	{
		public void SendNotification(string message)
		{
			// Code to send email
		}
	}

	public class SmsSender : INotificationService
	{
		public void SendNotification(string message)
		{
			// Code to send SMS
		}
	}

	public class OrderProcessor
	{
		private INotificationService _notificationService;
		public OrderProcessor(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		public void Process(Order order)
		{
			// Code to process order
			_notificationService.SendNotification($"Your order {order.Id} has been confirmed");
		}
	}
	
	Order order_1 = new Order();
	OrderProcessor orderProcessor = new OrderProcessor(new EmailSender());
	orderProcessor.Process(order_1);

	Order order_2 = new Order();
	OrderProcessor orderProcessor = new OrderProcessor(new SmsSender());
	orderProcessor.Process(order_2);
	
	```C#


	Composition
	-----------

	- Composition is a design technique in object-oriented programming to implement has-a relationship between objects.
	- Composition is a way to combine objects or classes into more complex data structures or software designs.
	- Composition involves creating complex objects by combining simpler objects or components. In composition, objects are
	assembled together to form larger structures, with each component maintaining its own state and behavior.
	

	

	```C#