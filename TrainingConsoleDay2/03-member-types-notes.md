## Member types

### fields

- A field is a variable of any type that is declared directly in a class or struct

- A class or struct may have *instance fields, static fields, or both* 

- If you have a class T, with an instance field F, you can create two objects of type T, and modify the value of F in each object without affecting the value in the other object. 

- By contrast, a static field belongs to the type itself, and is shared among all instances of that type.

- You can access the static field only by using the type name. If you access the static field by an instance name, you get CS0176 compile-time error.

- use local variables when a variable has to be scoped only with in a method.

- Backing fields -  declare private or protected accessibility for fields. 
  Data that your type exposes to client code should be provided through methods, properties, and indexers.

- Accessing public fields using dot operator

- instance fields vs static fields, readonly, required.

- readonly fields can be assigned a value either at the declaration or in the constructor of the class in which they are defined.

- ```csharp
  public class Person
  {
	  public readonly string Name;
	  public Person(string name)
	  {
		  Name = name;
	  }
  }
  ```

### constants

- A constant is a *field* that is declared with the const modifier. They are immutable values which are known at compile time and do not change for the life of the program.

- Constants are by default static, and you cannot define a constant as static.

- only built-in types (excluding System.Object) can be declared as constants. for classes, structs, arrays, or other user-defined types, you must use *readonly*.


```csharp
public class MathClass
{
	public const double PI = 3.14159;
}
```

### properties

- A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field.

- Properties appear as public data members, but they're implemented as special methods called accessors.

- Properties enable a class to expose a public way of getting and setting values, while hiding implementation or verification code.

examples:
```csharp
public class Person
{
	private string name;
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
}

class Employee
{
    private int _salary;

    public int Salary
    {
        get { return _salary; }
        set
        {
            if (value < 0) throw new Exception("Salary cannot be negative!");
            _salary = value;
        }
    }
}
```

- init, private set, public get, readonly, required.

examples:
```csharp
public class Person
{
	public string Name { get; private set; }
}
```

- computed properties
 
examples:
```csharp
public class Person
{
    public Person() { }

    [SetsRequiredMembers]
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public required string FirstName { get; init; }
    public required string LastName { get; init; }

    private string? _fullName;
    public string FullName
    {
        get
        {
            if (_fullName is null)
                _fullName = $"{FirstName} {LastName}";
            return _fullName;
        }
    }
}
```

- auto-implemented properties
examples:
- ```csharp
  public class Person
  {
      public string Name { get; set; }
  }
  ```

  ### Methods

  - A method is a code block that contains a series of statements. A program causes the statements to be executed by calling the method and specifying any required method arguments.

  - paramaters and arguments

  - return types

 ### Constructors

 - A constructor is a method called by the runtime when an instance of a class or a struct is created

 - A constructor is a method with the same name as its type. Its method signature can include an optional access modifier, the method name, and its parameter list; it doesn't include a return type. 

 - A class or struct can have multiple constructors that take different arguments. Constructors enable you to ensure that instances of the type are valid when created

 - static constructors