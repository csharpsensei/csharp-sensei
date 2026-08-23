namespace DependencyInversion.Fines;

/// <summary>
/// The one thing the overdue rule needs from the calendar: what day it is.
/// A date read from the middle of a rule is a dependency like any other.
/// </summary>
public interface IClock
{
    DateOnly Today { get; }
}
