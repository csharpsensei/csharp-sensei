public static class LoanDesk
{
    public static List<string> BuildOverdueReport(
        List<Loan> loans, DateOnly today, bool overdueOnly)
    {
        List<string> lines = new List<string>();

        foreach (Loan loan in loans)
        {
            int daysPastDue = today.DayNumber - loan.DueOn.DayNumber;
            bool isOverdue = daysPastDue > LendingPolicy.GraceDays;
