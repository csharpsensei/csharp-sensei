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
