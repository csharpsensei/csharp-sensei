public class Drill
{
    public string Name { get; }

    public Drill(string name, int minutes)
    {
        Name = name;
        Minutes = minutes;
    }
}

// Everything every drill has. Written once.
