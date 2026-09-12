using BuilderPattern.Rooms;

namespace BuilderPattern.Reporting;

/// <summary>
/// One description format, used by all three versions of a booking, so that a
/// difference in the output is a difference in the booking rather than a
/// difference in the printing (PRODUCTION-SYSTEM.md section 16.11).
/// </summary>
public static class Describe
{
    public static string Booking(RoomType room, DateOnly arrive, DateOnly leave,
                                 int adults, int children, bool breakfast, bool cot)
    {
        int nights = leave.DayNumber - arrive.DayNumber;

        string line = room + " room, " + nights + " nights from " + arrive.ToString("yyyy-MM-dd")
                      + ", " + adults + "+" + children + " guests";

        if (breakfast)
        {
            line += ", breakfast";
        }

        if (cot)
        {
            line += ", cot";
        }

        return line;
    }
}
