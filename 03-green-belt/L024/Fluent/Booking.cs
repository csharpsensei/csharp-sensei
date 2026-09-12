using BuilderPattern.Reporting;
using BuilderPattern.Rooms;

namespace BuilderPattern.Fluent;

/// <summary>
/// The finished booking. Every property is read only and the constructor is
/// internal, so the only route to one of these inside this assembly is through
/// BookingBuilder, and the only route from outside it is none at all.
/// </summary>
public sealed class Booking
{
    internal Booking(string guestName, DateOnly checkIn, DateOnly checkOut, int adults,
                     int children, RoomType room, bool breakfast, bool cot, string[] requests)
    {
        GuestName = guestName;
        CheckIn = checkIn;
        CheckOut = checkOut;
        Adults = adults;
        Children = children;
        Room = room;
        Breakfast = breakfast;
        Cot = cot;
        Requests = requests;
    }

    public string GuestName { get; }

    public DateOnly CheckIn { get; }

    public DateOnly CheckOut { get; }

    public int Adults { get; }

    public int Children { get; }

    public RoomType Room { get; }

    public bool Breakfast { get; }

    public bool Cot { get; }

    public IReadOnlyList<string> Requests { get; }

    public int Nights => CheckOut.DayNumber - CheckIn.DayNumber;

    public string Summary() =>
        Describe.Booking(Room, CheckIn, CheckOut, Adults, Children, Breakfast, Cot);
}
