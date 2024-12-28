SOLID Principles
================

SOLID is an acronym for five principles that help software developers design maintainable and scalable code. 
These principles were introduced by Robert C. Martin in his 2000 paper "Design Principles and Design Patterns".

SOLID principles allows us to developer software that is easy to maintain, extend and test.

The SOLID principles are:

1. Single Responsibility Principle (SRP)
2. Open/Closed Principle (OCP)
3. Liskov Substitution Principle (LSP)
4. Interface Segregation Principle (ISP)
5. Dependency Inversion Principle (DIP)

Single Responsibility Principle (SRP)
--------------------------------------

The Single Responsibility Principle states that a class should have only one reason to change. 
In other words, a class should have only one responsibility.


Example that violates SRP:
```C#

public class User{

  public string Name { get; set; }
  public string EmailAddress { get; set; }
  public string Address { get; set; }

  public void Register(){
	// Register user

	// Send email
  }
}

```

In the above example, the User class has two other responsibilities: Registering a user and sending an email apart from storing user information.


Example that follows SRP:
```C#

public class User{
  public string Name { get; set; }
  public string EmailAddress { get; set; }
  public string Address { get; set; }
}

public class UserService{
 
 public UserServices(INotificationService notificationService){
   _notificationService = notificationService;
 }

 public void Register(User user){
	// Register user

	_notificationService.SendNotification(user);
  }
}

public interface INotificationService{
  void SendNotification(User user);
}

public class EmailNotificationService : INotificationService{
  public void SendNotification(User user){
	// Send email
  }
}

```

In the above example, the User class is responsible only for storing user information. The UserService class is responsible for registering a user and sending an email.

Open/Closed Principle (OCP)
----------------------------

The Open/Closed Principle states that Software entities such as Classes, Functions or Modules should be open for extension but closed for modification.

It encourages the use of Abstractions and Polymorphism to achieve this.

Example that violates OCP:
```C#

public enum ShapeType{
  Circle,
  Square
}

public class Shape{
  public ShapeType Type { get; set; }

  public double Radius { get; set; }

  public double Side { get; set; }

  public double Area(){
  switch(Type){
	case ShapeType.Circle:
	  return Math.PI * Radius * Radius;
	case ShapeType.Square:
	  return Side * Side;
	default:
	  return 0;
  }
}

```

In the above example, if we want to add a new shape, we need to modify the Shape class which violates the OCP.

Example that follows OCP:
```C#

public abstract class Shape{
  public abstract double Area();
}

public class Circle : Shape{
  public double Radius { get; set; }
  public override double Area(){
	return Math.PI * Radius * Radius;
  }
}

public class Square : Shape{
  public double Side { get; set; }
  public override double Area(){
	return Side * Side;
  }
}
```

In the above example, we have an abstract Shape class with an abstract Area method. 
We have Circle and Square classes that inherit from the Shape class and implement the Area method.
If we want to add a new shape, we can create a new class that inherits from the Shape class and implement the Area method.

Liskov Substitution Principle (LSP)
------------------------------------

The Liskov Substitution Principle states that objects of a superclass should be replaceable with objects of its subclasses without affecting the correctness of the program.

In other words, a subclass should be substitutable for its superclass.

Example that violates LSP:
```C#

public class Rectangle{
  public int Width { get; set; }
  public int Height { get; set; }
  public virtual int Area(){
	return Width * Height;
  }
}

public class Square : Rectangle{
  public override int Area(){
	return Width * Width;
  }
}
```

In the above example, a Square is a subclass of Rectangle. A Square is a rectangle with equal width and height.
The Square class overrides the Area method to calculate the area of a square.
However, a Square is not substitutable for a Rectangle because the Area method in the Square class behaves differently than the Area method in the Rectangle class.


Example that follows LSP:
```C#

public interface IShape{
  int Area();
}

public class Rectangle : IShape{
  public int Width { get; set; }
  public int Height { get; set; }
  public int Area(){
	return Width * Height;
  }
}

public class Square : IShape{
  public int Side { get; set; }
  public int Area(){
	return Side * Side;
  }
}
```

In the above example, we have an IShape interface with an Area method.
The Rectangle and Square classes implement the IShape interface and implement the Area method.
Now, a Square is substitutable for a Rectangle because both classes implement the IShape interface and have the same Area method.


Interface Segregation Principle (ISP)

-------------------------------------

The Interface Segregation Principle states that a client should not be forced to implement an interface that it does not use.

In other words, we should have small, specific interfaces instead of large, general interfaces.

Dependency Inversion Principle (DIP)

-------------------------------------

The Dependency Inversion Principle states that high-level modules should not depend on low-level modules. Both should depend on abstractions.

In other words, we should depend on abstractions, not concretions.

Example that violates DIP:
```C#


public class Engine{
  public void Start(){
	// Start engine
  }
}

public class Car{

	private readonly Engine _engine;
	public string Name	{ get; set; }
	public string Make	{ get; set; }
	public string Model	{ get; set; }
    
	public Car(){
		_engine = new Engine();
	}

	public void Start(){
		_engine.Start();
	}
}   

```

In the above example, the Car class depends on the Engine class and not on its abstraction. 
If we want to change the Engine class, we need to modify the Car class which violates the DIP.

Example that follows DIP:
```C#	

public interface IEngine{
  void Start();
}

public class ElectricEngine : IEngine{
  public void Start(){
	// Start engine
  }
}

public class GasEngine : IEngine{
  public void Start(){
	// Start engine
  }
}

public class Car{
	private readonly IEngine _engine;
	public string Name	{ get; set; }
	public string Make	{ get; set; }
	public string Model	{ get; set; }
	
	public Car(IEngine engine){
		_engine = engine;
	}
	public void Start(){
		_engine.Start();
	}
}   
```