using DependencyInversion.Fines;

namespace DependencyInversion.Doubles;

/// <summary>
/// The test double, in four lines, with no mocking library. It exists only
/// because the rule asked for an interface instead of reading the machine.
/// Program.cs uses it so the output on screen is the same every run.
/// </summary>
public sealed class FixedClock : IClock
{
    public FixedClock(DateOnly today) => Today = today;

    public DateOnly Today { get; }
}
