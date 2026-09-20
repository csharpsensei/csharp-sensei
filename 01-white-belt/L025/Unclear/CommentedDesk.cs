using NamingAndComments.Lending;

namespace NamingAndComments.Unclear;

/// <summary>
/// Deliberately over-commented, and every comment in it restates the line
/// underneath. <see cref="FeeTotals"/> is the same method with the comments
/// deleted and the names fixed. Do not copy.
/// </summary>
public static class CommentedDesk
{
    public static decimal Total(List<Loan> loans, DateOnly today)
    {
        // running total
        decimal t = 0m;

        // loop through the loans
        foreach (Loan loan in loans)
        {
            // work out how many days past due it is
            int n = today.DayNumber - loan.DueOn.DayNumber;

            // if it is more than the grace period, add the fee
            if (n > LendingPolicy.GraceDays)
            {
                t = t + LateFee.For(n);
            }
        }

        return t;
    }
}
