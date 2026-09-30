using ComponentTests.App.Booking;
using ComponentTests.App.Pricing;
using ComponentTests.Tests.Fakes;

namespace ComponentTests.Regression;

/// <summary>
/// The first component test, pointed at the broken service. Explicit, so a
/// plain `dotnet run` skips it and stays green.
/// </summary>
public sealed class BrokenBookingTests
{
    [Fact(Explicit = true)]
    public void Book_TwoStudentSeats_ChargesTwentyPercentLess()
    {
        // Arrange
        FakeSeatStore seats = new(available: 10);
        FakePaymentGateway payments = new();
        FakeConfirmationSender confirmations = new();
        BrokenBookingService booking = new(
            new TicketPricer(), new StudentDiscount(),
            seats, payments, confirmations);
        BookingRequest request = new(Seats: 2, Student: true, Email: "sam@example.com");

        // Act
        BookingResult result = booking.Book(request);

        // Assert
        Assert.Equal(1440, result.ChargedPence);
    }
}
