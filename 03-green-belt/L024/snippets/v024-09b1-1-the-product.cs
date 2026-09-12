public sealed class Booking
{

    public string GuestName { get; }

    public DateOnly CheckIn { get; }

    public DateOnly CheckOut { get; }

    public IReadOnlyList<string> Requests { get; }

    public int Nights => CheckOut.DayNumber - CheckIn.DayNumber;
