namespace EndToEndTests.App.Bookings;

/// <summary>
/// What a customer sends to book a repair: their name and the day they want.
/// </summary>
public sealed record BookingRequest(string Customer, DateOnly Day);
