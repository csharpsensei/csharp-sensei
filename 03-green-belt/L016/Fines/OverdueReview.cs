namespace DependencyInversion.Fines;

/// <summary>
/// Cycle b. The high level rule, and the only file in the solution that says
/// what overdue costs. It names what it needs and receives it. There is no
/// using here pointing at Library, and there never will be.
/// </summary>
public sealed class OverdueReview
{
    private const int PencePerDay = 10;

    private readonly IListLoans _loans;
    private readonly IClock _clock;

    public OverdueReview(IListLoans loans, IClock clock)
    {
        _loans = loans;
        _clock = clock;
    }

    public IReadOnlyList<string> Lines()
    {
        List<string> lines = new List<string>();
        int total = 0;

        foreach (Loan loan in _loans.Open())
        {
            int days = DaysLate(loan);
            if (days <= 0)
            {
                lines.Add($"  {loan.Title,-26}{"not due yet",-14}".TrimEnd());
                continue;
            }

            int pence = days * PencePerDay;
            total += pence;

            string late = $"{days} days late";
            string money = $"{pence}p";
            lines.Add($"  {loan.Title,-26}{late,-14}{money,6}");
        }

        lines.Add($"  {"total",-26}{"",-14}{total + "p",6}");
        return lines;
    }

    public int TotalPence()
    {
        int total = 0;
        foreach (Loan loan in _loans.Open())
        {
            int days = DaysLate(loan);
            if (days > 0)
            {
                total += days * PencePerDay;
            }
        }
        return total;
    }

    public int OverdueCount()
    {
        int count = 0;
        foreach (Loan loan in _loans.Open())
        {
            if (DaysLate(loan) > 0)
            {
                count++;
            }
        }
        return count;
    }

    private int DaysLate(Loan loan) => _clock.Today.DayNumber - loan.Due.DayNumber;
}
