public sealed class CachingQuote(IDeliveryQuote inner) : IDeliveryQuote
{
    private readonly Dictionary<string, int> _known =
        new Dictionary<string, int>();
    public int DaysTo(string postcode)
    {
        if (_known.TryGetValue(postcode, out int days))
            return days;
        days = inner.DaysTo(postcode);
        _known[postcode] = days;
        return days;
    }
}
