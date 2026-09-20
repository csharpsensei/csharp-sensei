using NamingAndComments.Lending;
using NamingAndComments.Reporting;

namespace NamingAndComments.Unclear;

/// <summary>
/// Deliberately badly named, and kept in the tree so the lesson has real code
/// to point at rather than a mock-up. Every line of it does exactly what
/// <see cref="LoanDesk"/> does. Do not copy the names.
/// PRODUCTION-SYSTEM.md section 16.3: a deliberate anti-pattern is labelled
/// where it lives and in the README.
/// </summary>
public static class LendingDataManager
{
    public static List<string> Process(List<Loan> l, DateOnly d, bool f)
    {
        List<string> r = new List<string>();

        foreach (Loan x in l)
        {
            int n = d.DayNumber - x.DueOn.DayNumber;
            bool b = n > LendingPolicy.GraceDays;

            if (f && !b)
            {
                continue;
            }

            decimal m = b ? LateFee.For(n) : 0m;

            r.Add(Describe.ReportLine(x, n, b, m));
        }

        return r;
    }
}
