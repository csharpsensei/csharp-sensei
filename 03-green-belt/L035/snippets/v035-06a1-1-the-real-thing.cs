public sealed class CourierQuote : IDeliveryQuote
{
    public int Calls { get; private set; }

    public int DaysTo(string postcode)
    {
        Calls++;
        return postcode.StartsWith("LS") ? 2 : 3;
    }
