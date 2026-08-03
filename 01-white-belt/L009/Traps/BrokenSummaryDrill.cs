namespace HowInheritanceWorks.Traps;

/// <summary>
/// THE CLASSIC BUG, half two — the subclass that gets bitten.
/// DO NOT COPY THIS SHAPE.
///
/// Nothing here is wrong on its own. The field is readonly, it is assigned in
/// the constructor, and the override reads it. The defect is entirely in the
/// ORDER: by the time this constructor body runs, the base has already called
/// Describe() and stored an answer built from a zero.
/// </summary>
public sealed class BrokenSummaryDrill : SummaryAtConstructionDrill
{
    private readonly int _rounds;

    public BrokenSummaryDrill(string name, int minutes, int rounds)
        : base(name, minutes)
    {
        _rounds = rounds;             // too late — Describe() already ran
    }

    public override string Describe() => $"{Name} — {_rounds} rounds";
}
