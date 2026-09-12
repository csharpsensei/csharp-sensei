using BuilderPattern.Reporting;
using BuilderPattern.Rooms;

namespace BuilderPattern.Positional;

/// <summary>
/// The shape this lesson starts from. One constructor, ten parameters, and
/// four of them the same type as the one beside them. Every value is here and
/// nothing at the call site says which is which.
/// </summary>
public sealed class PositionalBooking
{
    public PositionalBooking(
        string guestName,
        DateOnly checkIn,
        DateOnly checkOut,
        int adults,
        int children,
        RoomType room,
        bool breakfast,
        bool lateCheckout,
        bool cot,
        string notes)
    {
        GuestName = guestName;
        CheckIn = checkIn;
        CheckOut = checkOut;
        Adults = adults;
        Children = children;
        Room = room;
        Breakfast = breakfast;
        LateCheckout = lateCheckout;
        Cot = cot;
        Notes = notes;
    }

    public string GuestName { get; }

    public DateOnly CheckIn { get; }

    public DateOnly CheckOut { get; }

    public int Adults { get; }

    public int Children { get; }

    public RoomType Room { get; }

    public bool Breakfast { get; }

    public bool LateCheckout { get; }

    public bool Cot { get; }

    public string Notes { get; }

    public string Summary() =>
        Describe.Booking(Room, CheckIn, CheckOut, Adults, Children, Breakfast, Cot);
}
