namespace DecoratorPattern.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. The courier call, a cache and a log, all edited
/// into one class. It works; it is the hook of the lesson. No pass runs it.
/// </summary>
public sealed class CourierQuoteWithEverything
{
    private readonly Dictionary<string, int> _known =
        new Dictionary<string, int>();

    public List<string> Journal { get; } = new List<string>();

    public int DaysTo(string postcode)
    {
        Journal.Add("quote asked for " + postcode);
        if (_known.TryGetValue(postcode, out int days))
            return days;

        days = postcode.StartsWith("LS") ? 2 : 3;
        _known[postcode] = days;
        return days;
    }
}
