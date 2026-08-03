public abstract class Exercise
{
    public abstract int Repetitions();   // no body

    public string Summary()              // a real one
        => $"{Name}: {Repetitions()} reps";
}

// abstract = virtual with the body taken away.
// No default, and the compiler makes you supply one.
