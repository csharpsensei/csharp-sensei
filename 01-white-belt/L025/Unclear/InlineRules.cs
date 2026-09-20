using NamingAndComments.Lending;

namespace NamingAndComments.Unclear;

/// <summary>
/// The overdue test written inline, with a comment explaining it.
/// <see cref="OverdueRules.IsOverdue"/> is the same test with the comment
/// turned into the method name. Kept so the lesson can run both.
/// </summary>
public static class InlineRules
{
    public static bool Check(Loan loan, DateOnly today)
    {
        // A loan counts as overdue when it has not been returned and it is
        // further past its due date than the grace period allows.
        if (!loan.Returned
            && today.DayNumber - loan.DueOn.DayNumber > LendingPolicy.GraceDays)
        {
            return true;
        }

        return false;
    }
}
