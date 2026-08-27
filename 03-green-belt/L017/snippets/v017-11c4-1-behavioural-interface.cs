/// <summary>
/// Behavioural family, light touch. One decision, named, with a version of it
/// per set of conditions. An empty string means say nothing about this row.
/// </summary>
public interface IDelayPolicy
{
    string Announce(Departure departure);
}
