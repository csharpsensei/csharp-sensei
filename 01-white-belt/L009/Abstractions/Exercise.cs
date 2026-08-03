namespace HowInheritanceWorks.Abstractions;

/// <summary>
/// <c>abstract</c> is <c>virtual</c> with the body taken away.
///
/// A virtual method says "here is a reasonable answer, replace it if you like".
/// An abstract method says "there is no reasonable answer here — you must
/// supply one", and the compiler enforces it: a class that does not override
/// <see cref="Repetitions"/> will not compile.
///
/// The class itself cannot be instantiated. `new Exercise(...)` is a compiler
/// error, not a runtime one, and that is the point: there is no such thing as
/// "an exercise" in general, only push-ups and squats and burpees.
///
/// Note that an abstract class can still have ordinary members with real
/// bodies. <see cref="Summary"/> below is written once and inherited by every
/// exercise there will ever be.
/// </summary>
public abstract class Exercise
{
    public string Name { get; }

    protected Exercise(string name) => Name = name;

    // No body. No braces. A semicolon, and a promise.
    public abstract int Repetitions();

    // An abstract class is still a class. This is shared, finished code.
    public string Summary() => $"{Name}: {Repetitions()} reps";
}
