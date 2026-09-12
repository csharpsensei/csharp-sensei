using BuilderPattern.Rooms;

namespace BuilderPattern.Fluent;

/// <summary>
/// The builder. Every step names one value, the steps can arrive in any order,
/// and nothing is checked until Build is called, because three of the rules
/// need more than one value to be checkable at all.
/// </summary>
public sealed class BookingBuilder
{
    private readonly string _guestName;
    private readonly List<string> _requests = new List<string>();

    private DateOnly? _checkIn;
    private DateOnly? _checkOut;
    private RoomType? _room;
    private int _adults = 2;
    private int _children;
    private bool _breakfast;
    private bool _cot;

    private BookingBuilder(string guestName) => _guestName = guestName;

    public static BookingBuilder For(string guestName) => new BookingBuilder(guestName);

    // One line each, deliberately. A step is a named value and a return, and
    // eleven of them in full block form is three screens of nothing.
    public BookingBuilder ArrivingOn(DateOnly date) { _checkIn = date; return this; }

    public BookingBuilder LeavingOn(DateOnly date) { _checkOut = date; return this; }

    public BookingBuilder InA(RoomType room) { _room = room; return this; }

    public BookingBuilder ForAdults(int adults) { _adults = adults; return this; }

    public BookingBuilder AndChildren(int children) { _children = children; return this; }

    public BookingBuilder WithBreakfast() { _breakfast = true; return this; }

    public BookingBuilder WithACot() { _cot = true; return this; }

    public BookingBuilder Requesting(string request) { _requests.Add(request); return this; }

    /// <summary>
    /// The one moment a booking comes into existence. The list is copied on the
    /// way in: hand the builder's own list over and anything added afterwards
    /// would appear inside a booking that was already finished.
    /// </summary>
    public Booking Build()
    {
        List<string> problems = Problems();

        if (problems.Count > 0)
        {
            throw new InvalidOperationException(string.Join("; ", problems));
        }

        return new Booking(_guestName, _checkIn!.Value, _checkOut!.Value, _adults, _children,
                           _room!.Value, _breakfast, _cot, _requests.ToArray());
    }

    /// <summary>
    /// Every problem, not the first one. A caller told one thing at a time
    /// comes back three times.
    ///
    /// The three rules at the bottom are the reason this class exists: not one
    /// of them can be checked from a single property, so not one of them could
    /// live in a property setter or an init accessor.
    /// </summary>
    private List<string> Problems()
    {
        List<string> problems = new List<string>();

        if (_checkIn is null)
        {
            problems.Add("no arrival date");
        }

        if (_checkOut is null)
        {
            problems.Add("no departure date");
        }

        if (_room is null)
        {
            problems.Add("no room type");
        }

        if (_adults < 1)
        {
            problems.Add("a booking needs at least one adult");
        }

        if (_checkIn is DateOnly arrive && _checkOut is DateOnly leave && leave <= arrive)
        {
            problems.Add("departure " + leave.ToString("yyyy-MM-dd")
                         + " is not after arrival " + arrive.ToString("yyyy-MM-dd"));
        }

        if (_room is RoomType room && _adults + _children > RoomCapacity.Of(room))
        {
            problems.Add((_adults + _children) + " guests in a " + room
                         + " room, which sleeps " + RoomCapacity.Of(room));
        }

        if (_cot && _children == 0)
        {
            problems.Add("a cot needs a child on the booking");
        }

        return problems;
    }
}
