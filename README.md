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
A **delegate** is a type that holds references to methods with a matching signature. It’s like a type-safe function pointer, enabling methods to be passed as parameters, stored in variables, or invoked dynamically—complete with multicasting support. Below, we’ll see them in action, from basic callbacks to complex event systems.

## 📌 Key Scenarios Covered
1. 📜 **Declaring and Using Delegates** - Basic setup and invocation.
2. 🎛️ **Handling Events** - Managing event-driven programming.
3. 🔄 **Implementing Callbacks** - Passing methods for flexible execution.
4. 🏆 **Using Multicast Delegates** - Calling multiple methods at once.
5. 🎯 **Leveraging LINQ & Functional Programming** - Using `Func` and `Action`.
6. ⚙️ **Supporting Async Programming** - Callbacks for async tasks.

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


## 🔍 FileSearch Class - A Practical Demonstration
### ✨ Overview
The `FileSearch` class is a comprehensive example showcasing the power of **delegates and events** in a real-world file search operation. It demonstrates how to use **multicasting delegates, recursion, error handling, and event-driven programming** effectively.

### 🏗️ Class Implementation
The `FileSearch` class defines two key delegate events:
- **FileFoundHandler** - Triggered when a file is discovered.
- **SearchErrorHandler** - Triggered when an error occurs during the search process.

```csharp
public class FileSearch
{
    public delegate void FileFoundHandler(string fileName);
    public delegate void SearchErrorHandler(string errorMessage);
    public event FileFoundHandler FileFound;
    public event SearchErrorHandler SearchFailed;

    public void Search(string directorySearch)
    {
        if (string.IsNullOrEmpty(directorySearch) || !Directory.Exists(directorySearch))
        {
            string error = $"Invalid directory: {directorySearch}";
            Console.WriteLine(error);
            SearchFailed?.Invoke(error);
            return;
        }

        try
        {
            ProcessDirectory(directorySearch);
        }
        catch (Exception e)
        {
            string error = $"Error during search: {e.Message}";
            Console.WriteLine(error);
            SearchFailed?.Invoke(error);
        }
    }

    private void ProcessDirectory(string dir)
    {
        foreach (var aFile in Directory.GetFiles(dir))
        {
            FileFound?.Invoke(aFile);
        }
        foreach (var subDir in Directory.GetDirectories(dir))
        {
            ProcessDirectory(subDir);
        }
    }
}
```

### 🔬 Usage Example
```csharp
class Program
{
    static void Main()
    {
        FileSearch fs = new FileSearch();

        fs.FileFound += LogFileDetails;
        fs.FileFound += FilterTextFiles;
        fs.FileFound += CountFiles;
        
        fs.SearchFailed += LogError;
        fs.SearchFailed += AlertUser;

        Console.WriteLine("Searching a valid directory...");
        fs.Search(@"C:\\TestFolder");

        Console.WriteLine("\nSearching an invalid directory...");
        fs.Search(@"C:\\NonExistentFolder");
    }

    static void LogFileDetails(string fileName)
    {
        Console.WriteLine($"Found file: {fileName} (Size: {new FileInfo(fileName).Length} bytes)");
    }

    static void FilterTextFiles(string fileName)
    {
        if (Path.GetExtension(fileName).Equals(".txt", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Text file detected: {fileName}");
        }
    }

    static int fileCount = 0;
    static void CountFiles(string fileName)
    {
        fileCount++;
        Console.WriteLine($"Total files found so far: {fileCount}");
    }

    static void LogError(string errorMessage)
    {
        Console.WriteLine($"ERROR LOG: {errorMessage}");
    }

    static void AlertUser(string errorMessage)
    {
        Console.WriteLine($"ALERT: Search failed - {errorMessage}");
    }
}
```

### 🔥 Features Demonstrated
1. **Multicasting Events** - Multiple methods handle `FileFound` and `SearchFailed` events.
2. **Recursive Search** - `ProcessDirectory` ensures nested directories are processed.
3. **Error Handling** - Handles invalid directories and exceptions gracefully.
4. **Practical Use Cases** - Logging, filtering, and counting files using event-driven programming.
5. **Subscribing Actions to Observables** - Handlers are subscribed to the `FileFound` and `SearchFailed` events using `+=`, demonstrating the power of **delegates and event-driven programming** in C#.


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
Gerson Motta Jr - Exploring C# with .NET 9 🚀

