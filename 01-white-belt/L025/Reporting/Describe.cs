using NamingAndComments.Lending;

namespace NamingAndComments.Reporting;

public static class Describe
{
    public static string ReportLine(
        Loan loan, int daysPastDue, bool isOverdue, decimal lateFee)
    {
        string state = isOverdue ? "overdue" : "in time";

        return loan.Title.PadRight(18)
            + " " + daysPastDue.ToString().PadLeft(3)
            + "  " + state
            + "  " + lateFee.ToString("0.00").PadLeft(5);
    }

    public static string Verdict(bool isOverdue)
    {
        return isOverdue ? "overdue" : "in time";
    }

    public static string LastSeen(Member member)
    {
        if (member.LastSeenOn is DateOnly seen)
        {
            return seen.ToString("yyyy-MM-dd");
        }

        return "never";
    }
}
