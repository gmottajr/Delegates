# 🎯 Delegates in C# - A Deep Dive

## 🚀 Overview
This repository explores the powerful concept of **delegates** in C#, specifically in the context of **.NET 9**. Delegates are a core feature of C#, enabling flexible, type-safe method references, and playing a crucial role in event-driven programming, callbacks, and functional programming paradigms.

## 🎯 Purpose
The purpose of this repository is to provide:
- 📌 A comprehensive understanding of **delegates in C#**.
- 🔥 Real-world **use cases** for delegates, including event handling, callbacks, and LINQ.
- 🛠️ Practical **code examples** demonstrating different delegate scenarios.
- ⚡ Insights into how **.NET 9** enhances delegate usage.

## 🤔 What Are Delegates?
A **delegate** is a type that represents references to methods with a specific signature. It allows methods to be passed as parameters, assigned to variables, and invoked dynamically. Think of it as a type-safe function pointer with additional capabilities like multicasting.

## 📌 Key Scenarios Covered
1. 📜 **Basic Delegate Usage** - Declaring and invoking delegates.
2. 🎛️ **Event Handling** - Using delegates to manage event-driven programming.
3. 🔄 **Callbacks** - Passing methods as parameters for flexible execution.
4. 🏆 **Multicast Delegates** - Invoking multiple methods using a single delegate.
5. 🎯 **Delegates in LINQ & Functional Programming** - Using built-in delegate types like `Func<T>` and `Action<T>`.
6. ⚙️ **Asynchronous Programming with Delegates** - Defining callbacks for async operations.

## 🔁 Callbacks and Observables with Delegates
One of the primary uses of delegates is implementing **callbacks**, where a method is passed as a parameter and invoked at a later time. This is particularly useful in **asynchronous programming** and event-driven architectures. Additionally, delegates integrate seamlessly with **Observables** in reactive programming (like in `System.Reactive`), allowing for real-time event streaming and handling. Observables combined with delegates help manage **data streams**, ensuring efficient handling of events and updates in applications.

### 💡 Example: Using Observables with Delegates
Here’s a simple implementation of an observable pattern using **Reactive Extensions (Rx)**:

```csharp
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

class Program
{
    static void Main()
    {
        // Create an observable sequence
        var subject = new Subject<string>();

        // Subscribe to the observable
        subject.Subscribe(message => Console.WriteLine($"Received: {message}"));

        // Emit values
        subject.OnNext("Hello, Observables!");
        subject.OnNext("Delegates make it powerful!");
    }
}
```
This example demonstrates how **delegates** and **observables** work together to handle data streams dynamically.

## 💻 Code Examples
The repository includes multiple examples showcasing delegates in action. Here's a quick preview:

```csharp
// Define a delegate type
delegate int MathOperation(int a, int b);

class Program
{
    static int Add(int x, int y) => x + y;
    static int Multiply(int x, int y) => x * y;

    static void Main()
    {
        MathOperation operation = Add;
        Console.WriteLine(operation(5, 3)); // Output: 8

        operation = Multiply;
        Console.WriteLine(operation(5, 3)); // Output: 15
    }
}
```

## 🚀 Running the Code
### 🔧 Prerequisites
- Install **.NET 9 SDK** (Ensure you have the latest version installed).
- Clone this repository:
  ```sh
  git clone https://github.com/your-username/delegates-in-csharp.git
  cd delegates-in-csharp
  ```
- Build and run the examples:
  ```sh
  dotnet run
  ```

## 🤝 Contributions
Feel free to **fork**, **open issues**, or **submit pull requests** to improve this repository.

## 📜 License
This project is licensed under the **MIT License**.

## 👨‍💻 Author
[Gerson Motta Jr] - Exploring C# with .NET 9 🚀

