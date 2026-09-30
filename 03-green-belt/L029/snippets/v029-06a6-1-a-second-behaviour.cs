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
