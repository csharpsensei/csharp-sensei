namespace ComponentTests.App.Booking;

/// <summary>
/// What came back: whether the booking went through, and what was charged.
/// </summary>
public sealed record BookingResult(bool Confirmed, int ChargedPence);
