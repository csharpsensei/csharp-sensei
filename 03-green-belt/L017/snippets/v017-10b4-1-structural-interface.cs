public interface IDepartureSource
{
    IReadOnlyList<Departure> Next();
}

public sealed record Departure(
    IService Service,
    string Destination,
    TimeOnly Due,
    int DelayMinutes);
