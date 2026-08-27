using DesignPatterns.Choosing;

namespace DesignPatterns.Board;

/// <summary>
/// The board after all three. It reads rows it understands, asks one question
/// about wording, and formats. There is no branch in it about anything else.
/// </summary>
public sealed class DepartureBoard
{
    private readonly IDepartureSource _source;
    private readonly IDelayPolicy _policy;

    public DepartureBoard(IDepartureSource source, IDelayPolicy policy)
    {
        _source = source;
        _policy = policy;
    }

    public IEnumerable<string> Rows()
    {
        foreach (Departure departure in _source.Next())
        {
            string note = _policy.Announce(departure);
            string label = departure.Service.Label;

            yield return (departure.Due.ToString("HH:mm") + "  "
                          + departure.Destination.PadRight(12)
                          + label.PadRight(16) + note).TrimEnd();
        }
    }
}
