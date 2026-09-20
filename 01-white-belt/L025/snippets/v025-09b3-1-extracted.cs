public static class OverdueRules
{
    public static bool IsOverdue(Loan loan, DateOnly today)
    {
        if (loan.Returned)
        {
            return false;
        }

        int daysPastDue = today.DayNumber - loan.DueOn.DayNumber;

        return daysPastDue > LendingPolicy.GraceDays;
