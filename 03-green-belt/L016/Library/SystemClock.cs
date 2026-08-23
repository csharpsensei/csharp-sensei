using DependencyInversion.Fines;

namespace DependencyInversion.Library;

/// <summary>The real clock. This is what production is handed.</summary>
public sealed class SystemClock : IClock
{
    public DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
}
