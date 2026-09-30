using ComponentTests.App.Booking;
using ComponentTests.App.Pricing;
using ComponentTests.Tests.Fakes;

namespace ComponentTests.Tests.Component;

/// <summary>
/// Component tests: the whole booking component, driven through its front
/// door. The pricer and the discount are the real classes. Only the three
/// edges, seats, payment and confirmation, are stand ins.
/// </summary>
[Trait("Kind", "Component")]
public sealed class BookingServiceTests
{
    [Fact]
    public void Book_TwoStudentSeats_ChargesTwentyPercentLess()
    {
        // Arrange
        FakeSeatStore seats = new(available: 10);
        FakePaymentGateway payments = new();
        FakeConfirmationSender confirmations = new();
        BookingService booking = new(
            new TicketPricer(), new StudentDiscount(),
            seats, payments, confirmations);
        BookingRequest request = new(Seats: 2, Student: true, Email: "sam@example.com");

        // Act
        BookingResult result = booking.Book(request);

        // Assert
        Assert.Equal(1440, result.ChargedPence);
    }

    [Fact]
    public void Book_PaymentDeclined_GivesTheSeatsBack()
    {
        // Arrange
        FakeSeatStore seats = new(available: 10);
        FakePaymentGateway payments = new() { Declines = true };
        FakeConfirmationSender confirmations = new();
        BookingService booking = new(
            new TicketPricer(), new StudentDiscount(),
            seats, payments, confirmations);
        BookingRequest request = new(Seats: 2, Student: false, Email: "sam@example.com");

        // Act
        booking.Book(request);

        // Assert
        Assert.Equal(10, seats.Available);
    }

    [Fact]
    public void Book_PaymentDeclined_SendsNoConfirmation()
    {
        // Arrange
        FakeSeatStore seats = new(available: 10);
        FakePaymentGateway payments = new() { Declines = true };
        FakeConfirmationSender confirmations = new();
        BookingService booking = new(
            new TicketPricer(), new StudentDiscount(),
            seats, payments, confirmations);
        BookingRequest request = new(Seats: 2, Student: false, Email: "sam@example.com");

        // Act
        booking.Book(request);

        // Assert
        Assert.Empty(confirmations.Sent);
    }

    [Fact]
    public void Book_NotEnoughSeats_TakesNoPayment()
    {
        // Arrange
        FakeSeatStore seats = new(available: 1);
        FakePaymentGateway payments = new();
        FakeConfirmationSender confirmations = new();
        BookingService booking = new(
            new TicketPricer(), new StudentDiscount(),
            seats, payments, confirmations);
        BookingRequest request = new(Seats: 2, Student: false, Email: "sam@example.com");

        // Act
        booking.Book(request);

        // Assert
        Assert.Empty(payments.Charges);
    }
}
