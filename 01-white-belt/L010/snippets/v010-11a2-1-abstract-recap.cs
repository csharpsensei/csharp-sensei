public abstract class Exercise
{
    protected Exercise(string name) => Name = name;
    public string Name { get; }

    public void Warmup() => Console.WriteLine("...");
    public abstract void Perform();
}

// Fields, a constructor, real bodies.
// An interface has none of those.
