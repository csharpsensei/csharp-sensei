namespace EndToEndTests.App.Bookings;

/// <summary>
/// Books repairs. It tidies the name, gives the booking an ID, and refuses a
/// day that is already taken.
/// </summary>
public sealed class BookingService
{
    private readonly IBookingStore _store;

    public BookingService(IBookingStore store)
    {
        _store = store;
    }

    public Booking? Book(string customer, DateOnly day)
    {
        Booking booking = new(Guid.NewGuid(), customer.Trim(), day);
        return _store.TryAdd(booking) ? booking : null;
    }

    public Booking? Find(Guid id) => _store.Find(id);
}
