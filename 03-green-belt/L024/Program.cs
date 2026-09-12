using BuilderPattern.Fluent;
using BuilderPattern.Modern;
using BuilderPattern.Positional;
using BuilderPattern.Reporting;
using BuilderPattern.Rooms;

namespace BuilderPattern;

public static class Program
{
    private static readonly DateOnly Arrive = new DateOnly(2026, 3, 4);
    private static readonly DateOnly Leave = new DateOnly(2026, 3, 7);

    public static void Main()
    {
        TenArgumentsAndNothingToHoldThemApart();
        Log.Blank();
        OneNamedStepAtATime();
        Log.Blank();
        WhatTheLanguageAlreadyDoes();
    }

    /// <summary>
    /// Pass one. The same ten arguments, in three orders. All three compile,
    /// all three construct, and two of them are bookings nobody meant.
    /// </summary>
    private static void TenArgumentsAndNothingToHoldThemApart()
    {
        Log.Line("Pass 1: ten arguments, and nothing holding them apart");

        PositionalBooking meant = new PositionalBooking(
            "Waterhouse", Arrive, Leave, 2, 1, RoomType.Family, true, false, true, "");
        Log.Line("  the call the team meant to write:");
        Log.Line("    " + meant.Summary());

        PositionalBooking datesSwapped = new PositionalBooking(
            "Waterhouse", Leave, Arrive, 2, 1, RoomType.Family, true, false, true, "");
        Log.Line("  the two dates the wrong way round:");
        Log.Line("    " + datesSwapped.Summary());

        PositionalBooking guestsSwapped = new PositionalBooking(
            "Waterhouse", Arrive, Leave, 1, 2, RoomType.Family, true, false, true, "");
        Log.Line("  the two guest counts the wrong way round:");
        Log.Line("    " + guestsSwapped.Summary());

        Log.Line("  three bookings, one intended. the compiler was happy with all three.");
    }

    /// <summary>
    /// Pass two. The same booking through the builder: two attempts that are
    /// refused with every problem named, and one that is built.
    /// </summary>
    private static void OneNamedStepAtATime()
    {
        Log.Line("Pass 2: the same booking, one named step at a time");

        Attempt("the two dates the wrong way round", BookingBuilder
            .For("Waterhouse")
            .ArrivingOn(Leave)
            .LeavingOn(Arrive)
            .InA(RoomType.Family)
            .ForAdults(2)
            .AndChildren(1));

        Attempt("five adults in a double room, and a cot", BookingBuilder
            .For("Waterhouse")
            .ArrivingOn(Arrive)
            .LeavingOn(Leave)
            .InA(RoomType.Double)
            .ForAdults(5)
            .WithACot());

        Attempt("every step the booking needs", BookingBuilder
            .For("Waterhouse")
            .ArrivingOn(Arrive)
            .LeavingOn(Leave)
            .InA(RoomType.Family)
            .ForAdults(2)
            .AndChildren(1)
            .WithBreakfast()
            .WithACot()
            .Requesting("quiet room"));

        Log.Line("  the same booking, collected across three screens:");
        Log.Line("    built:   " + BookingWizard.Collect("Waterhouse").Summary());
    }

    /// <summary>
    /// Pass three. What required members and init accessors already give you,
    /// and the one thing they cannot do: look at two values together.
    /// </summary>
    private static void WhatTheLanguageAlreadyDoes()
    {
        Log.Line("Pass 3: what the language already does, and where it stops");

        InitBooking supplied = new InitBooking
        {
            GuestName = "Waterhouse",
            CheckIn = Arrive,
            CheckOut = Leave,
            Room = RoomType.Family,
            Adults = 2,
            Children = 1
        };
        Log.Line("  an object initialiser, every value named:");
        Log.Line("    " + supplied.Summary());

        InitBooking wrongWayRound = new InitBooking
        {
            GuestName = "Waterhouse",
            CheckIn = Leave,
            CheckOut = Arrive,
            Room = RoomType.Family,
            Adults = 2,
            Children = 1
        };
        Log.Line("  the same initialiser, dates the wrong way round:");
        Log.Line("    " + wrongWayRound.Summary());
        Log.Line("    no property is wrong on its own, so nothing objected.");

        Log.Line("  the builder, offered those same two dates:");
        Attempt("", BookingBuilder
            .For("Waterhouse")
            .ArrivingOn(Leave)
            .LeavingOn(Arrive)
            .InA(RoomType.Family)
            .ForAdults(2)
            .AndChildren(1));
    }

    /// <summary>
    /// Builds and reports. A refusal is an InvalidOperationException carrying
    /// every problem the builder found, which is why this catches rather than
    /// checking anything itself.
    /// </summary>
    private static void Attempt(string what, BookingBuilder builder)
    {
        if (what.Length > 0)
        {
            Log.Line("  " + what + ":");
        }

        try
        {
            Booking booking = builder.Build();
            Log.Line("    built:   " + booking.Summary());
        }
        catch (InvalidOperationException problem)
        {
            Log.Line("    refused: " + problem.Message);
        }
    }
}
