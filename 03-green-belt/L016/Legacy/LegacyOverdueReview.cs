namespace DependencyInversion.Legacy;

/// <summary>
/// Cycle a. THE VIOLATION. DO NOT COPY.
/// </summary>
public sealed class LegacyOverdueReview
{
    private readonly LegacyLoanDatabase _database = new LegacyLoanDatabase();

    public string Summarise()
    {
        // Not a value being read. A call out to the operating system, from
        // inside a business rule, and as hard wired as the field above it.
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);

        IReadOnlyList<LegacyLoan> loans = _database.AllLoans();
        int overdue = 0;
        foreach (LegacyLoan loan in loans)
        {
            if (loan.Due.DayNumber < today.DayNumber)
            {
                overdue++;
            }
        }

        return $"{overdue} of {loans.Count} loans overdue, as at today";
    }

    // The test nobody can write:
    //
    //   Given a book due on the 25th of February, when it is the 1st of
    //   March, the fine should be 40p.
    //
    // Every noun in that sentence is a value you would need to set. The
    // loans come out of a field initialiser and today comes off the machine,
    // so there is nothing to set and nowhere to set it from.
}
