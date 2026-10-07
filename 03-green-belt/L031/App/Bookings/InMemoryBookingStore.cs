namespace EndToEndTests.App.Bookings;

/// <summary>
/// Keeps bookings in memory. A booking lives exactly as long as this instance
/// does, so the application has to create one of these and share it.
/// A real shop would keep them in a database: see the README.
/// </summary>
public sealed class InMemoryBookingStore : IBookingStore
{
    private readonly Lock _gate = new();
    private readonly Dictionary<Guid, Booking> _bookings = [];

    public bool TryAdd(Booking booking)
    {
        lock (_gate)
        {
            if (_bookings.Values.Any(existing => existing.Day == booking.Day))
            {
                return false;
            }

            _bookings.Add(booking.Id, booking);
            return true;
        }
    }

    public Booking? Find(Guid id)
    {
        lock (_gate)
        {
            return _bookings.TryGetValue(id, out Booking? booking) ? booking : null;
        }
    }
}
