using DecoratorPattern.Quotes;

namespace DecoratorPattern.Decorators;

/// <summary>
/// A decorator: the same interface outside, another IDeliveryQuote inside,
/// one extra job. It remembers answers. A simplification named in the
/// README: the cache never expires.
/// </summary>
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
