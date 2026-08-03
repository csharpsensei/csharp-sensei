namespace HowInheritanceWorks.Drills;

/// <summary>
/// The second derived class, and the one that shows <c>base.Method()</c>.
///
/// Overriding does not have to mean discarding. Here the base description is
/// still exactly right — it is just not the whole story — so this override
/// calls the version it replaced and adds to the answer.
/// </summary>
public class SparringDrill : Drill
{
    private readonly int _rounds;

    public SparringDrill(string name, int minutes, int rounds)
        : base(name, minutes)
    {
        _rounds = rounds;
    }

    // base.Describe() is the ONLY way to reach the method this one replaced.
    // Calling Describe() here would call this method again, forever.
    public override string Describe()
        => $"{base.Describe()}, {_rounds} rounds";

    public override int CaloriesBurned() => Minutes * 11;
}
