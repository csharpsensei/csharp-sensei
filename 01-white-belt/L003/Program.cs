
// A class that guards its own data with properties instead of exposing raw fields.
public class Temperature
{
    // Private backing field: the real storage, hidden inside the class.
    private double _celsius;

    // Property with validation. Reads/writes look like a field to callers,
    // but the setter can refuse bad data before it is ever stored.
    public double Celsius
    {
        get => _celsius;
        set
        {
            if (value < -273.15)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Temperature cannot go below absolute zero (-273.15 C).");
            }

            _celsius = value;
        }
    }

    // Computed, read-only property: no backing field, derived every time.
    public double Fahrenheit => _celsius * 9 / 5 + 32;
}

public class Person
{
    // Auto-property: the compiler writes the hidden backing field for you.
    public string Name { get; set; } = "";

    // Init-only: assignable once, at construction, then read-only for life.
    public string Id { get; init; } = "";
}

public static class Program
{
    public static void Main()
    {
        var temp = new Temperature();
        temp.Celsius = 25;
        Console.WriteLine($"{temp.Celsius} C = {temp.Fahrenheit} F");

        try
        {
            temp.Celsius = -300; // rejected by the setter's rule
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Rejected: {ex.Message}");
        }

        var person = new Person { Name = "Aiko", Id = "P-001" };
        person.Name = "Aiko Tanaka"; // allowed: Name has a set
        // person.Id = "P-002";      // compile error: Id is init-only
        Console.WriteLine($"{person.Id}: {person.Name}");
    }
}
















