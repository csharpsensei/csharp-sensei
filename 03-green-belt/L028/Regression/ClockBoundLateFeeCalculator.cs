namespace UnitTestsInDepth.Regression;

/// <summary>
/// DO NOT COPY THIS SHAPE. The late fee reading today's date from the system
/// clock inside the method. Any test of it gives a different answer depending
/// on the day it runs, so it has no test here, which is the point.
/// </summary>
public sealed class ClockBoundLateFeeCalculator
{
    public int FeeInPence(DateOnly due)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        int daysLate = today.DayNumber - due.DayNumber;

        if (daysLate <= 0)
        {
            return 0;
        }

        return Math.Min(daysLate * 20, 500);
    }
}
