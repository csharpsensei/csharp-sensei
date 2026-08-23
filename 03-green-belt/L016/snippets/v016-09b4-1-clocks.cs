// Library/SystemClock.cs
public sealed class SystemClock : IClock
{
    public DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
}

// Doubles/FixedClock.cs
public sealed class FixedClock : IClock
{
    public FixedClock(DateOnly today) => Today = today;

    public DateOnly Today { get; }
}
