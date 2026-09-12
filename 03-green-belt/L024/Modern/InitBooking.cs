using BuilderPattern.Reporting;
using BuilderPattern.Rooms;

namespace BuilderPattern.Modern;

/// <summary>
/// The same booking, expressed the way the language now allows. Required
/// members cannot be left out, init accessors close the object after
/// construction, and the call site names every value it sets.
///
/// What this cannot do is look at two properties at the same time, which is
/// where the builder in Fluent/ earns its place.
/// </summary>
public sealed class InitBooking
{
    public required string GuestName { get; init; }

    public required DateOnly CheckIn { get; init; }

    public required DateOnly CheckOut { get; init; }

    public required RoomType Room { get; init; }

    public int Adults { get; init; } = 2;

    public int Children { get; init; }

    public bool Breakfast { get; init; }

    public bool Cot { get; init; }

    public string Notes { get; init; } = "";

    public string Summary() =>
        Describe.Booking(Room, CheckIn, CheckOut, Adults, Children, Breakfast, Cot);
}
