namespace DelegatesStudyingConsoleApp.Classes;

// Defines a Worker class to simulate some task-performing entity
public static class Worker
{
    // Method that takes an Action<string> delegate as a parameter
    // 'Action<string>' is a built-in delegate type that represents a method 
    // taking a string parameter and returning void
    public static void Process(string message, Action<string> callback)
    {
        // Simulate some work being done by printing a status message
        Console.WriteLine("Processing...");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine(message);
        Console.WriteLine($"                        : {DateTime.Now.ToString("hh:mm:ss tt")}");
        Console.WriteLine("--------------------------------------------------");
        // Invoke the callback delegate, passing "All set!" as the argument
        // This calls whatever method was passed to Process when it’s done
        callback("All set!");
        callback("Would you like to do this again?!");
    }
}