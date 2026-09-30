namespace UnitTestsInDepth.Regression;

/// <summary>
/// DO NOT COPY THIS SHAPE. The late fee with its five pound cap lost, the
/// kind of one line slip a merge can make. It exists so the lesson can show
/// three explicit tests failing against the same bug, without the real tests
/// going red.
/// </summary>
public sealed class BrokenLateFeeCalculator
{
    public const int PencePerDay = 20;

    public int FeeInPence(DateOnly due, DateOnly returned)
    {
        int daysLate = returned.DayNumber - due.DayNumber;

        if (daysLate <= 0)
        {
            return 0;
        }

        return daysLate * PencePerDay;
    }
}
