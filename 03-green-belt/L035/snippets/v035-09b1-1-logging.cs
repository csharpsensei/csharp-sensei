public sealed class LoggingQuote(IDeliveryQuote inner, List<string> journal)
    : IDeliveryQuote
{
    public int DaysTo(string postcode)
    {
        journal.Add("quote asked for " + postcode);
        return inner.DaysTo(postcode);
    }
}
