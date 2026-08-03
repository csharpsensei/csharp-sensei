public class Drill
{
    public virtual string Describe()
        => $"{Name} — {Minutes} minutes";
}

// virtual is not "this can be called".
// Every method can be called.
// It means: a subclass may replace this.
