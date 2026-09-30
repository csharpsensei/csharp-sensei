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
