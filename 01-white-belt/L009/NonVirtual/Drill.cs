namespace HowInheritanceWorks.NonVirtual;

/// <summary>
/// The same class as <see cref="Drills.Drill"/> with one word removed:
/// Describe is NOT virtual.
///
/// It exists so demo 5 can show what that actually costs. The main Drill is
/// virtual — as it should be — so it cannot demonstrate the problem virtual
/// solves. Using the hiding class for that demo would have worked by accident
/// and pre-empted the trap in demo 7, which is a different lesson.
///
/// DO NOT COPY THIS SHAPE. It is the "before".
/// </summary>
public class Drill
{
    protected int Minutes { get; }

    public string Name { get; }

    public Drill(string name, int minutes)
    {
        Name = name;
        Minutes = minutes;
    }

    // No `virtual`. A subclass may write its own Describe, but it will only
    // run when the variable is declared as that subclass.
    public string Describe() => $"{Name} — {Minutes} minutes";
}
