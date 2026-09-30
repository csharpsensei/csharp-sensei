namespace ComponentTests.App.Booking;

/// <summary>
/// What a customer asks for: how many seats, whether they are students, and
/// where to send the confirmation.
/// </summary>
public sealed record BookingRequest(int Seats, bool Student, string Email);
