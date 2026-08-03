namespace HowInheritanceWorks.NonVirtual;

/// <summary>
/// A subclass with its own Describe, and no way to make it win.
/// DO NOT COPY THIS SHAPE.
/// </summary>
public class FormsDrill : Drill
{
    private readonly int _formCount;

    public FormsDrill(string name, int minutes, int formCount)
        : base(name, minutes)
    {
        _formCount = formCount;
    }

    // Nothing here is wrong. The base method simply did not give permission,
    // so this one can never run through a Drill reference.
    public new string Describe()
        => $"{Name} — {_formCount} forms over {Minutes} minutes";
}
