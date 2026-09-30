namespace ComponentTests.App.Pricing;

/// <summary>
/// Nine pounds a seat, in whole pence.
/// </summary>
public sealed class TicketPricer
{
    public const int PencePerSeat = 900;

    public int PriceInPence(int seats) => seats * PencePerSeat;
}
