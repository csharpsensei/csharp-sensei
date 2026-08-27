using DesignPatterns.Board;

namespace DesignPatterns.Choosing;

/// <summary>Overnight, the board only speaks up about a real delay.</summary>
public sealed class QuietHoursPolicy : IDelayPolicy
{
    public string Announce(Departure departure) => departure.DelayMinutes >= 5
        ? $"delayed {departure.DelayMinutes} min"
        : string.Empty;
}
