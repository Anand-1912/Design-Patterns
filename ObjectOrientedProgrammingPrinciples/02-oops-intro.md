

### **What is OOP (Object-Oriented Programming)?**  
**Object-Oriented Programming (OOP)** is a programming paradigm based on the concept of **objects**, which are instances of **classes**. 

It helps in organizing code in a modular, reusable, and scalable manner.

---

### **Key Concepts of OOP**
OOP is built on **four main principles**:

1. **Encapsulation** 🛡️  
   - Bundling data (variables) and behavior (methods) together in a **class**.  
   - Restricts direct access to some details using **access modifiers** (e.g., `private`, `public`).  
   - Example:  
     ```csharp
     class Car {
         private string brand; // Encapsulated field
         
         public void SetBrand(string b) { 
             brand = b; 
         }
         public string GetBrand() { 
             return brand; 
         }
     }
     ```

2. **Inheritance** 🔗  
   - Enables a **child class** to acquire properties and behavior from a **parent class**.  
   - Promotes code **reusability** and **hierarchical structure**.  
   - Example:
     ```csharp
     class Vehicle {  
         public void Move() { Console.WriteLine("Vehicle is moving"); }  
     }  
     class Car : Vehicle { }  
     ```

3. **Polymorphism** 🎭  
   - The ability of a method to take **multiple forms** (overloading and overriding).  
   - Example:  
     ```csharp
     class Shape {
         public virtual void Draw() { Console.WriteLine("Drawing a shape"); }
     }
     class Circle : Shape {
         public override void Draw() { Console.WriteLine("Drawing a Circle"); }
     }
     ```

4. **Abstraction** 🎭🔍  
   - Hides **complex implementation** and exposes only the necessary parts.  
   - Achieved using **abstract classes** and **interfaces**.  
   - Example:
     ```csharp
     abstract class Animal {
         public abstract void MakeSound();  
     }
     class Dog : Animal {
         public override void MakeSound() { Console.WriteLine("Bark!"); }
     }
     ```

---

### **Why Use OOP?**
✅ **Modularity** – Code is divided into smaller, manageable parts.  
✅ **Reusability** – Inheritance allows reuse of existing code.  
✅ **Scalability** – Makes it easier to maintain and extend applications.  
✅ **Security** – Encapsulation protects data from unintended access.


