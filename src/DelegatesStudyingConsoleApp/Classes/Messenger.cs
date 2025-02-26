namespace DelegatesStudyingConsoleApp.Classes;

// Defines a custom delegate type called Notify that represents methods 
// taking a string parameter and returning void. This will be used for event handling.
public delegate void Notify(string message);

// A class to simulate a messaging system that uses events
public class Messenger
{
    // Declares an event called OnMessageSent based on the Notify delegate.
    // Events are a special use of delegates that allow subscribers to "listen" for something to happen.
    public event Notify OnMessageSent;

    // Method to send a message, triggering the event if there are subscribers
    public void Send(string msg)
    {
        // The ?. operator checks if OnMessageSent has any subscribers (is not null).
        // If it does, Invoke calls all subscribed methods, passing the msg string as an argument.
        OnMessageSent?.Invoke(msg);
    }
}