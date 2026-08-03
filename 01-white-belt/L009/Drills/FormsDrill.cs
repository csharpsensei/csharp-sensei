namespace HowInheritanceWorks.Drills;

/// <summary>
/// A derived class, and the smallest possible one: it adds a single field and
/// replaces one method.
///
/// Note what is NOT here. No Name property. No Minutes. No constructor body
/// setting them. Those came from <see cref="Drill"/> and are not repeated,
/// which is the entire point of the colon on the first line.
/// </summary>
public class FormsDrill : Drill
{
    private readonly int _formCount;

    // Constructors are the one thing a derived class does NOT inherit. This
    // one takes what it needs, keeps its own piece, and hands the rest up to
    // the base constructor with `base(...)`. The base runs FIRST — by the time
    // the line below it executes, Name and Minutes are already set.
    public FormsDrill(string name, int minutes, int formCount)
        : base(name, minutes)
    {
        _formCount = formCount;
    }

    public override string Describe()
        => $"{Name} — {_formCount} forms over {Minutes} minutes";

    // Forms are precise rather than hard. Fewer calories than the base rate,
    // and the base class does not need to know that.
    public override int CaloriesBurned() => Minutes * 4;
}
