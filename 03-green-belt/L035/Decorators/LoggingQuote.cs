using DecoratorPattern.Quotes;

namespace DecoratorPattern.Decorators;

/// <summary>A decorator that writes one line per call, then passes it on.</summary>
public sealed class LoggingQuote(IDeliveryQuote inner, List<string> journal)
    : IDeliveryQuote
{
    public int DaysTo(string postcode)
    {
        journal.Add("quote asked for " + postcode);
        return inner.DaysTo(postcode);
    }
}
