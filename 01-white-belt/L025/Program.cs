using NamingAndComments.Lending;
using NamingAndComments.Misleading;
using NamingAndComments.Reporting;
using NamingAndComments.Seeding;
using NamingAndComments.Unclear;

namespace NamingAndComments;

public static class Program
{
    private static readonly DateOnly Today = new DateOnly(2026, 3, 20);

    public static void Main()
    {
        TheSameWorkWrittenTwice();
        Log.Blank();
        TheCommentDeletedAndTheMethodExtracted();
        Log.Blank();
        TwoWaysTheCodeSaysSomethingUntrue();
        Log.Blank();
        TheCommentANameCannotReplace();
    }

    /// <summary>
    /// Pass one. The badly named report and the well named report, over the
    /// same six loans. Nothing about the behaviour changes, which is the point.
    /// </summary>
    private static void TheSameWorkWrittenTwice()
    {
        List<Loan> loans = DeskData.AllLoans();

        Log.Line("Pass 1: the same work, written twice");

        Log.Line("  LendingDataManager.Process");
        foreach (string line in LendingDataManager.Process(loans, Today, true))
        {
            Log.Line("    " + line);
        }

        Log.Line("  LoanDesk.BuildOverdueReport");
        foreach (string line in LoanDesk.BuildOverdueReport(loans, Today, true))
        {
            Log.Line("    " + line);
        }

        Log.Line("  identical, line for line. the machine cannot tell them apart.");
    }

    /// <summary>
    /// Pass two. Deleting four comments and extracting one method, and the
    /// answers not moving. This is what makes both of them safe to do.
    /// </summary>
    private static void TheCommentDeletedAndTheMethodExtracted()
    {
        List<Loan> loans = DeskData.AllLoans();

        Log.Line("Pass 2: the comment deleted, and the method extracted");

        Log.Line("  outstanding fees");
        Log.Line("    CommentedDesk.Total        "
            + CommentedDesk.Total(loans, Today).ToString("0.00"));
        Log.Line("    FeeTotals.OutstandingFees  "
            + FeeTotals.OutstandingFees(loans, Today).ToString("0.00"));

        int inline = 0;
        int extracted = 0;
        int agreements = 0;

        foreach (Loan loan in loans)
        {
            bool inlineSays = InlineRules.Check(loan, Today);
            bool extractedSays = OverdueRules.IsOverdue(loan, Today);

            if (inlineSays)
            {
                inline = inline + 1;
            }

            if (extractedSays)
            {
                extracted = extracted + 1;
            }

            if (inlineSays == extractedSays)
            {
                agreements = agreements + 1;
            }
        }

        Log.Line("  the overdue test");
        Log.Line("    InlineRules.Check       overdue on " + inline + " of " + loans.Count);
        Log.Line("    OverdueRules.IsOverdue  overdue on " + extracted + " of " + loans.Count);
        Log.Line("    agreed on " + agreements + " of " + loans.Count + " loans");
        Log.Line("  nothing moved but the reading.");
    }

    /// <summary>
    /// Pass three. A comment that is wrong, and a name that is wrong. Both of
    /// them compile, and neither of them is checked by anything.
    /// </summary>
    private static void TwoWaysTheCodeSaysSomethingUntrue()
    {
        Log.Line("Pass 3: two ways the code says something untrue");

        Loan coastalBirds = DeskData.CoastalBirds();
        int daysPastDue = Today.DayNumber - coastalBirds.DueOn.DayNumber;

        Log.Line("  the comment says a loan is overdue three days after the due date");
        Log.Line("    " + coastalBirds.Title + " is " + daysPastDue + " days past due");
        Log.Line("    the comment predicts: overdue");
        Log.Line("    the code answers:     "
            + Describe.Verdict(StaleCommentDesk.IsOverdue(daysPastDue)));
        Log.Line("  nothing anywhere checks a comment against the code under it.");

        Member nadia = new Member("Nadia");
        MemberLookup lookup = new MemberLookup(new List<Member> { nadia });

        Log.Line("  MemberLookup.GetMemberRecord");
        Log.Line("    last seen before the call: " + Describe.LastSeen(nadia));
        lookup.GetMemberRecord("Nadia", Today);
        Log.Line("    last seen after the call:  " + Describe.LastSeen(nadia));
        Log.Line("  the name says get. the call wrote.");
    }

    /// <summary>
    /// Pass four. The capped fee. No name on the method can carry the reason
    /// the cap is there, so the comment above it is the only thing that does.
    /// </summary>
    private static void TheCommentANameCannotReplace()
    {
        Loan dryStone = DeskData.DryStoneWalling();
        int daysPastDue = Today.DayNumber - dryStone.DueOn.DayNumber;
        int chargeableDays = daysPastDue - LendingPolicy.GraceDays;
        decimal beforeTheCap = chargeableDays * LendingPolicy.FeePerDay;

        Log.Line("Pass 4: the comment a name cannot replace");
        Log.Line("    " + dryStone.Title + " is " + daysPastDue + " days past due");
        Log.Line("    chargeable days:       " + chargeableDays);
        Log.Line("    fee before the cap: " + beforeTheCap.ToString("0.00").PadLeft(6));
        Log.Line("    fee charged:        "
            + LateFee.For(daysPastDue).ToString("0.00").PadLeft(6));
        Log.Line("  no name on that method can carry why the cap is there.");
        Log.Line("  the comment above it does, and it is the only thing that does.");
    }
}
