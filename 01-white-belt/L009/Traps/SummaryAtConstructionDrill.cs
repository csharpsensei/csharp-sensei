namespace HowInheritanceWorks.Traps;

using HowInheritanceWorks.Drills;

/// <summary>
/// THE CLASSIC BUG, half one — kept runnable on purpose (demo 09) so it can be
/// watched rather than described. DO NOT COPY THIS SHAPE.
///
/// This constructor calls a virtual method. That call is dispatched to the
/// override in the derived class, which has not run its own constructor yet.
///
/// Order of events, which is the whole explanation:
///
///   1. `new BrokenSummaryDrill(...)` starts
///   2. THIS constructor runs, and calls Describe()
///   3. dispatch sends that to the OVERRIDE in the subclass
///   4. the override reads a field nothing has assigned yet, and gets 0
///   5. THEN the derived constructor body runs and sets it
///
/// The rule that avoids it: **never call a virtual method from a constructor.**
/// If a base class needs a value only the subclass knows, take it as a
/// constructor parameter instead — see <see cref="SparringDrill"/>.
/// </summary>
public class SummaryAtConstructionDrill : Drill
{
    /// <summary>Computed during construction, which is exactly the mistake.</summary>
    public string CachedSummary { get; }

    public SummaryAtConstructionDrill(string name, int minutes)
        : base(name, minutes)
    {
        CachedSummary = Describe();   // virtual call, from a constructor
    }
}
