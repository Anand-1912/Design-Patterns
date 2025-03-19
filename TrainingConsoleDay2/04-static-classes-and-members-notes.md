## Static classes and members

### Static classes

- A static class is a class that cannot be instantiated.

- A static class is sealed and therefore cannot be inherited.

- A static class cannot contain instance constructors.

- A static class is used to contain static members such as fields, properties, and methods.

### Static members

- A static member is a member that belongs to the type itself, rather than to any instance of the type.

- A static member is shared among all instances of the type.

- You can access a static member only by using the type name. If you access the static member by an instance name, you get a compile-time error.

- Static members are initialized before the static field is accessed for the first time.

- you cannot access a non-static member from a static method but you can access a static member from a non-static method.

example:
```csharp	
public class Person
{
	private static int count = 0;
	public string Name;
	public Person(string name)
	{
		Name = name;
		count++;
	}
}
```