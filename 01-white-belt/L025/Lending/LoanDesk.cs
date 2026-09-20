using NamingAndComments.Reporting;

namespace NamingAndComments.Lending;

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

            if (overdueOnly && !isOverdue)
            {
                continue;
            }

            decimal lateFee = isOverdue ? LateFee.For(daysPastDue) : 0m;

            lines.Add(Describe.ReportLine(loan, daysPastDue, isOverdue, lateFee));
        }

        return lines;
    }
}
