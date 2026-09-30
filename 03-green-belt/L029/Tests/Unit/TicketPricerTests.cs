using ComponentTests.App.Pricing;

namespace ComponentTests.Tests.Unit;

/// <summary>
/// Unit tests: the pricer on its own.
/// </summary>
[Trait("Kind", "Unit")]
public sealed class TicketPricerTests
{
    [Fact]
    public void PriceInPence_OneSeat_ChargesNinePounds()
    {
        // Arrange
        TicketPricer pricer = new();

        // Act
        int price = pricer.PriceInPence(1);

        // Assert
        Assert.Equal(900, price);
    }

    [Fact]
    public void PriceInPence_TwoSeats_ChargesEighteenPounds()
    {
        // Arrange
        TicketPricer pricer = new();

        // Act
        int price = pricer.PriceInPence(2);

        // Assert
        Assert.Equal(1800, price);
    }
}
