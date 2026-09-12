using BuilderPattern.Rooms;

namespace BuilderPattern.Fluent;

/// <summary>
/// The values do not always arrive together. Here three screens each fill in
/// the part they collected, and the booking itself does not exist until the
/// last line of Collect, so no half filled booking is ever passed around.
/// </summary>
public static class BookingWizard
{
    public static Booking Collect(string guestName)
    {
        BookingBuilder builder = BookingBuilder.For(guestName);

        DatesScreen(builder);
        GuestsScreen(builder);
        ExtrasScreen(builder);

        return builder.Build();
    }

    private static void DatesScreen(BookingBuilder builder) =>
        builder.ArrivingOn(new DateOnly(2026, 3, 4)).LeavingOn(new DateOnly(2026, 3, 7));

    private static void GuestsScreen(BookingBuilder builder) =>
        builder.InA(RoomType.Family).ForAdults(2).AndChildren(1);

    private static void ExtrasScreen(BookingBuilder builder) =>
        builder.WithBreakfast().Requesting("quiet room");
}
