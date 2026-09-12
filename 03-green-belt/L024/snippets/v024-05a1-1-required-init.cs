public sealed class InitBooking
{
    public required string GuestName { get; init; }

    public required DateOnly CheckIn { get; init; }

    public required DateOnly CheckOut { get; init; }

    public required RoomType Room { get; init; }

    public int Adults { get; init; } = 2;

    public int Children { get; init; }
