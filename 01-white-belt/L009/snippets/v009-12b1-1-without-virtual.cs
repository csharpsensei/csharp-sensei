public class Drill
{
    public string Describe()          // no virtual
        => $"{Name} — {Minutes} minutes";
}

Drill d = new FormsDrill("Kata", 45, 3);
d.Describe();

// Which one runs?
