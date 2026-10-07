namespace EndToEndTests.App.Bookings;

/// <summary>
/// Where bookings are kept.
/// </summary>
public interface IBookingStore
{
    bool TryAdd(Booking booking);

    Booking? Find(Guid id);
}
