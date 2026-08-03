namespace HowInheritanceWorks.Drills;

/// <summary>
/// Three levels deep, and the last one. <c>sealed override</c> replaces the
/// method and then closes it: this is the final answer, and nothing below may
/// change it again.
///
/// Sealing is not about security. It is a statement — "this behaviour is now
/// decided" — and it is worth making when a subclass replacing it would break
/// something the class guarantees. A belt test is graded one way, by
/// definition, or it is not a belt test.
/// </summary>
public sealed class BeltTestDrill : SparringDrill
{
    private readonly string _belt;

    public BeltTestDrill(string name, int minutes, int rounds, string belt)
        : base(name, minutes, rounds)
    {
        _belt = belt;
    }

    public sealed override string Describe()
        => $"{base.Describe()} — grading for {_belt} belt";
}
