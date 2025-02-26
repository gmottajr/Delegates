// See https://aka.ms/new-console-template for more information

using System.Linq;
using System.Collections;
using System.Threading;

using DelegatesStudyingConsoleApp.Classes;

void ShowRollResult(List<short> diceResults)
{
    // Join the list into a readable string for output
    Console.WriteLine($"Rolled: {string.Join(" and ", diceResults)}");
}

// Callback to check if there are any doubles in the roll
void CheckForDoubles(List<short> diceResults)
{
    // Use Distinct to see if there are fewer unique values than total dice (indicating doubles)
    if (diceResults.Distinct().Count() < diceResults.Count)
    {
        // Find duplicates by grouping and filtering
        var doubles = diceResults.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);
        Console.WriteLine($"Doubles found: {string.Join(", ", doubles)}");
    }
}


Console.WriteLine("Hello, World!");
var msgNova = Console.ReadLine();
Worker.Process(msgNova, msg => Console.WriteLine(msg)); // Output: All set!
Console.WriteLine("Enter next message:");
var msg2 = Console.ReadLine();
Worker.DoWork(msg2 + " - \n  " + msgNova, msg => Console.WriteLine(msg));

// Create an instance of Messenger to work with
Messenger messenger = new Messenger();

// Subscribe the DisplayMessage method to the OnMessageSent event.
// The += operator adds this method to the list of callbacks the event will trigger.
// This is where the delegate behind the event links to a specific action.
messenger.OnMessageSent += DisplayMessage;

// Call Send with a message, which triggers the OnMessageSent event,
// causing DisplayMessage to run and print the message.
messenger.Send("Gotchaaaaa!!! Hello, world!"); // Output: Received: Hello, world!

// Create an instance of DiceCaster
DiceCaster caster = new DiceCaster();

// Subscribe multiple behaviors to the OnDiceCast event
caster.OnCast += ShowRollResult;    // Display the raw roll
caster.OnCast += CheckForDoubles;   // Check for any doubles
caster.OnCast += CalculateTotal;    // Show the total

// Cast 2 dice and see the results
Console.WriteLine("Casting 2 dice...");
caster.Cast(2);

// Cast 4 dice to show flexibility with more dice
Console.WriteLine("\nCasting 4 dice...");
caster.Cast(4);
var searcher = new FileSearch();
searcher.FileFound += Receiver;
searcher.FileFound += ReceiverThreading;
Task.Run(() => searcher.Search("/Volumes/LadoB/Programacao"));

// A static method that matches the Notify delegate signature (takes a string, returns void).
// This is the callback that gets executed when the OnMessageSent event fires.
void DisplayMessage(string msg)
{
    // Simply prints the received message with a "Received:" prefix for clarity
    Console.WriteLine($"Received: {msg}");
}

// Callback to calculate and display the total of all dice
void CalculateTotal(List<short> diceResults)
{
    int total = diceResults.Select(x => (int)x).Sum();
    Console.WriteLine($"Total roll value: {total}");
}

void Receiver(string filename)
{
    Console.WriteLine($"Receiving file: {filename}");
}

void ReceiverThreading(string filename)
{
    Task.Run(() =>
    {
        Console.WriteLine($"Receiving - 2 - file at: {DateTime.Now.ToString("HH:mm:ss")}");
        Receiver(filename);
        Thread.Sleep(5000);
        Console.WriteLine($"**********************************");
    });
}