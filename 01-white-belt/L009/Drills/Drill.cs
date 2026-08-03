namespace HowInheritanceWorks.Drills;

/// <summary>
/// The base class. Everything every drill has, written once.
///
/// Two things here are worth reading slowly:
///
/// * <see cref="Minutes"/> is <c>protected</c>. That access modifier exists
///   for exactly this situation — a derived class may read it, and nothing
///   outside the family can. <c>private</c> would hide it from the subclasses
///   that need it; <c>public</c> would hand it to everybody.
///
/// * <see cref="Describe"/> and <see cref="CaloriesBurned"/> are
///   <c>virtual</c>. That is not "this can be called". Every method can be
///   called. It means "a derived class is allowed to replace this, and when it
///   does, the replacement runs even when the caller is holding a
///   <see cref="Drill"/> reference and knows nothing about the subclass."
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

    public virtual string Describe() => $"{Name} — {Minutes} minutes";

    public virtual int CaloriesBurned() => Minutes * 6;

    // object already gave every class a ToString(). The default returns the
    // type name, which is never what you want in a log line. This is the first
    // override most people write, usually without noticing it is one.
    public override string ToString() => Describe();
}
