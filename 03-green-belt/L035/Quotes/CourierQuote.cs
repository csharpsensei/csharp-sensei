namespace DecoratorPattern.Quotes;

/// <summary>
/// The real thing. Stands in for a call to a courier's service, which would
/// be slow and charged per call; here it counts calls instead. A
/// simplification named in the README.
/// </summary>
public sealed class CourierQuote : IDeliveryQuote
{
    public int Calls { get; private set; }

    public int DaysTo(string postcode)
    {
        Calls++;
        return postcode.StartsWith("LS") ? 2 : 3;
    }
}
