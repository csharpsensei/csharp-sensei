namespace EndToEndTests.App.Bookings;

/// <summary>
/// One repair booked at the bike shop. The shop takes one bike a day, so the
/// day is the thing two bookings can clash on.
/// </summary>
public sealed record Booking(Guid Id, string Customer, DateOnly Day);
