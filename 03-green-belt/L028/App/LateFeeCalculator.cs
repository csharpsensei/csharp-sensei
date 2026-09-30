namespace UnitTestsInDepth.App;

/// <summary>
/// Works out a library late fee in whole pence: twenty pence for each day
/// late, never more than five pounds. The return date is passed in, so the
/// answer never depends on what day the code happens to run.
/// </summary>
public sealed class LateFeeCalculator
{
    public const int PencePerDay = 20;
    public const int CapInPence = 500;

    public int FeeInPence(DateOnly due, DateOnly returned)
    {
        int daysLate = returned.DayNumber - due.DayNumber;

        if (daysLate <= 0)
        {
            return 0;
        }

        return Math.Min(daysLate * PencePerDay, CapInPence);
    }
}
