using NamingAndComments.Lending;

namespace NamingAndComments.Seeding;

/// <summary>
/// The six loans the lesson runs everything against. Fixed dates, so the
/// printed output is the same on any machine and on any day.
/// </summary>
public static class DeskData
{
    public static Loan RopeAndRigging()
    {
        return new Loan("Rope and Rigging", "Ellis", new DateOnly(2026, 3, 18), false);
    }

    public static Loan TheTidalAlmanac()
    {
        return new Loan("The Tidal Almanac", "Ellis", new DateOnly(2026, 3, 8), false);
    }

    public static Loan DryStoneWalling()
    {
        return new Loan("Dry Stone Walling", "Nadia", new DateOnly(2026, 1, 2), false);
    }

    public static Loan CoastalBirds()
    {
        return new Loan("Coastal Birds", "Nadia", new DateOnly(2026, 3, 15), false);
    }

    public static Loan BellRinging()
    {
        return new Loan("Bell Ringing", "Tom", new DateOnly(2026, 2, 28), true);
    }

    public static Loan HedgeLaying()
    {
        return new Loan("Hedge Laying", "Tom", new DateOnly(2026, 3, 25), false);
    }

    public static List<Loan> AllLoans()
    {
        return new List<Loan>
        {
            RopeAndRigging(),
            TheTidalAlmanac(),
            DryStoneWalling(),
            CoastalBirds(),
            BellRinging(),
            HedgeLaying(),
        };
    }
}
