namespace DelegatesStudyingConsoleApp.Classes;

/// Defines a delegate type for handling dice cast results.
/// Takes a List<int> of dice results to support variable numbers of dice.
public delegate void CastHandler(List<short> castResults);

/// A class representing a dice caster that throws a variable number of dice and notifies subscribers
public class DiceCaster
{
    // Event based on DiceCastHandler delegate; subscribers get the list of dice results
    public event CastHandler OnCast;
    
    // Random number generator for simulating dice rolls (1-6)
    private readonly Random _random = new Random();

    public void Cast(int totalDices)
    {
        var castResults = new List<short>();
        // Roll the specified total of dice, each giving a random number between 1 and 6
        for (int i = 0; i < totalDices; i++)
        {
            castResults.Add((short)_random.Next(1, 7));
        }
        
        // If there are subscribers to OnDiceCast, invoke the event with the list of results
        // The ?. ensures safety if no one’s subscribed
        OnCast?.Invoke(castResults);
    }
}