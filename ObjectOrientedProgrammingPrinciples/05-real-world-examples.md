### **Real-World Examples of OOP Concepts**  

Now, let’s see how **OOP (Object-Oriented Programming)** is applied in real-world scenarios. I'll cover **modularity, reusability, and scalability** with **practical examples**.

---

## **Example 1: Banking System (Encapsulation & Modularity)**
### **Scenario:**  
A bank maintains **customer accounts**. Each account has a **balance** that should be **secured** and only modified through valid transactions.

### **How OOP Helps?**  
- **Encapsulation** ensures that the balance is **not directly accessible** but can be modified using **methods** like `Deposit()` and `Withdraw()`.  
- **Modularity** keeps the **Account** class independent, so we can extend it later without affecting other parts of the system.

🔹 **Code Example:**
```csharp
class BankAccount {
    private double balance; // Encapsulation: balance is private

    public void Deposit(double amount) {
        if (amount > 0) {
            balance += amount;
            Console.WriteLine($"Deposited: ${amount}, New Balance: ${balance}");
        }
    }

    public void Withdraw(double amount) {
        if (amount > 0 && amount <= balance) {
            balance -= amount;
            Console.WriteLine($"Withdrawn: ${amount}, Remaining Balance: ${balance}");
        } else {
            Console.WriteLine("Insufficient balance!");
        }
    }
}
```
```csharp
BankAccount acc = new BankAccount();
acc.Deposit(500);
acc.Withdraw(200);
```
👉 **Benefit:** The balance is **securely managed** through encapsulated methods.

---

## **Example 2: E-Commerce Website (Reusability & Inheritance)**
### **Scenario:**  
An **e-commerce website** sells different types of **products** like **Electronics, Clothing, and Books**. All products share **common attributes** like `Name` and `Price`, but **each product type** has **specific features**.

### **How OOP Helps?**  
- **Reusability**: Instead of writing separate code for each product type, we **inherit from a common `Product` class**.  
- **Inheritance** ensures that **all products automatically get common features**, and we can **extend functionality without duplication**.

🔹 **Code Example:**
```csharp
class Product {
    public string Name { get; set; }
    public double Price { get; set; }

    public virtual void DisplayInfo() {
        Console.WriteLine($"Product: {Name}, Price: ${Price}");
    }
}

// Derived Classes (Inheriting from Product)
class Electronics : Product {
    public string Brand { get; set; }

    public override void DisplayInfo() {
        Console.WriteLine($"Electronics: {Name}, Brand: {Brand}, Price: ${Price}");
    }
}

class Clothing : Product {
    public string Size { get; set; }

    public override void DisplayInfo() {
        Console.WriteLine($"Clothing: {Name}, Size: {Size}, Price: ${Price}");
    }
}
```
```csharp
Electronics laptop = new Electronics { Name = "Laptop", Brand = "Dell", Price = 1200 };
laptop.DisplayInfo();

Clothing tshirt = new Clothing { Name = "T-Shirt", Size = "M", Price = 25 };
tshirt.DisplayInfo();
```
👉 **Benefit:** The **common features are reused**, and **new product types** can be added easily.

---

## **Example 3: Ride-Sharing App (Scalability & Polymorphism)**
### **Scenario:**  
A ride-sharing app like **Uber** offers different **types of rides** (Economy, Premium, and Electric). Each ride has **different pricing and behavior**, but they all follow the **same ride process**.

### **How OOP Helps?**  
- **Scalability**: New ride types can be **added without modifying existing code**.  
- **Polymorphism**: The `CalculateFare()` method behaves **differently** for each ride type.

🔹 **Code Example:**
```csharp
abstract class Ride {
    public string PickupLocation { get; set; }
    public string DropLocation { get; set; }
    
    public abstract double CalculateFare(double distance);
}

// Different ride types implementing their own fare calculation
class EconomyRide : Ride {
    public override double CalculateFare(double distance) {
        return distance * 5; // $5 per km
    }
}

class PremiumRide : Ride {
    public override double CalculateFare(double distance) {
        return distance * 10; // $10 per km
    }
}
```
```csharp
Ride myRide = new EconomyRide();
Console.WriteLine("Fare: $" + myRide.CalculateFare(10)); // Economy ride for 10 km

myRide = new PremiumRide();
Console.WriteLine("Fare: $" + myRide.CalculateFare(10)); // Premium ride for 10 km
```
👉 **Benefit:** **New ride types** can be added **without modifying existing code**.

---

## **Example 4: Online Payment System (Interfaces & Scalability)**
### **Scenario:**  
An **online payment system** supports multiple payment methods: **Credit Card, PayPal, and Cryptocurrency**. Each payment type **has different rules** but should be **processed uniformly**.

### **How OOP Helps?**  
- **Interfaces** ensure that all payment types **follow the same structure**.
- **Scalability** allows **new payment methods to be added** without affecting existing ones.

🔹 **Code Example:**
```csharp
interface IPayment {
    void ProcessPayment(double amount);
}

// Implementing different payment types
class CreditCardPayment : IPayment {
    public void ProcessPayment(double amount) {
        Console.WriteLine($"Processing Credit Card Payment of ${amount}");
    }
}

class PayPalPayment : IPayment {
    public void ProcessPayment(double amount) {
        Console.WriteLine($"Processing PayPal Payment of ${amount}");
    }
}

// New payment method added without modifying existing code
class CryptoPayment : IPayment {
    public void ProcessPayment(double amount) {
        Console.WriteLine($"Processing Cryptocurrency Payment of ${amount}");
    }
}
```
```csharp
IPayment payment = new CreditCardPayment();
payment.ProcessPayment(100);

payment = new CryptoPayment();
payment.ProcessPayment(200);
```
👉 **Benefit:** The system is **scalable**—we can **add new payment methods** without modifying old code.

---

## **Conclusion: How OOP Makes Systems Better**
| **OOP Concept** | **Real-World Example** | **How It Helps?** |
|---------------|-----------------|---------------|
| **Encapsulation** | Bank Account System | Prevents unauthorized access to data |
| **Inheritance** | E-Commerce Product System | Reuses common product features |
| **Polymorphism** | Ride-Sharing App | Supports different ride behaviors dynamically |
| **Abstraction & Interfaces** | Online Payment System | Allows easy expansion with new payment methods |

✅ **OOP makes software more structured, maintainable, and scalable!** 🚀  

Would you like examples for a specific industry (e.g., healthcare, finance, gaming)? 😊