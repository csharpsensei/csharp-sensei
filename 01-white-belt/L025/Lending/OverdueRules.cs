namespace NamingAndComments.Lending;

public static class OverdueRules
{
    /// <summary>
    /// True when the loan is still out and it is further past its due date
    /// than the grace period allows.
    /// </summary>
    /// <param name="loan">The loan being judged.</param>
    /// <param name="today">The date the desk is running its report for.</param>
    public static bool IsOverdue(Loan loan, DateOnly today)
    {
        if (loan.Returned)
        {
            return false;
        }

        int daysPastDue = today.DayNumber - loan.DueOn.DayNumber;

        return daysPastDue > LendingPolicy.GraceDays;
    }
}
