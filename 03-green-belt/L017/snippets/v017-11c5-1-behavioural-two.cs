public sealed class NormalPolicy : IDelayPolicy
{
    public string Announce(Departure departure) => departure.DelayMinutes == 0
        ? "on time"
        : $"delayed {departure.DelayMinutes} min";
}

public sealed class QuietHoursPolicy : IDelayPolicy
{
    public string Announce(Departure departure) => departure.DelayMinutes >= 5
        ? $"delayed {departure.DelayMinutes} min"
        : string.Empty;
}
