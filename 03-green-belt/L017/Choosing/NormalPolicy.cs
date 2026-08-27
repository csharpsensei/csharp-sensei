using DesignPatterns.Board;

namespace DesignPatterns.Choosing;

public sealed class NormalPolicy : IDelayPolicy
{
    public string Announce(Departure departure) => departure.DelayMinutes == 0
        ? "on time"
        : $"delayed {departure.DelayMinutes} min";
}
