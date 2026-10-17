namespace DecoratorPattern.Quotes;

/// <summary>
/// A courier service that fails the first time it is asked about any
/// postcode, then answers. Engineered so the retry has something true to do.
/// </summary>
public sealed class FlakyCourierQuote : IDeliveryQuote
{
    private readonly HashSet<string> _seen = new HashSet<string>();

    public int Attempts { get; private set; }

    public int DaysTo(string postcode)
    {
        Attempts++;
        if (_seen.Add(postcode))
            throw new TransientQuoteException(postcode);

        return 3;
    }
}
