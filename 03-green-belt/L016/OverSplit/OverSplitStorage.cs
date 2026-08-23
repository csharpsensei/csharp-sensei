using DependencyInversion.Fines;

namespace DependencyInversion.OverSplit;

// Cycle c. THE BOUNDARY. DO NOT COPY.
//
// Every collaborator behind an interface, one implementation each, plus a
// factory so that something else can build the thing that builds the thing.
//
// SIMPLIFICATION, named here and in the README (PRODUCTION-SYSTEM.md §16.3):
// five interface declarations share this one file so that all five fit on
// one still. §16.2 wants one public type per file, and a real codebase built
// this way would carry five more files, which is part of the point.

public interface ICountDaysLate { int Days(DateOnly due, DateOnly today); }

public interface IChargePerDay { int Pence(int days); }

public interface IFormatMoney { string Format(int pence); }

public interface IBuildLine { string Line(Loan loan, string money); }

public interface IMakeOverdueReviews { OverSplitReview Make(); }

/// <summary>Six parameters, and four of them will never have a second implementation.</summary>
public sealed class OverSplitReview
{
    private readonly IListLoans _loans;
    private readonly IClock _clock;
    private readonly ICountDaysLate _days;
    private readonly IChargePerDay _charge;
    private readonly IFormatMoney _money;
    private readonly IBuildLine _lines;

    public OverSplitReview(IListLoans loans,
                           IClock clock,
                           ICountDaysLate days,
                           IChargePerDay charge,
                           IFormatMoney money,
                           IBuildLine lines)
    {
        _loans = loans;
        _clock = clock;
        _days = days;
        _charge = charge;
        _money = money;
        _lines = lines;
    }

    public IReadOnlyList<string> Lines()
    {
        List<string> output = new List<string>();
        foreach (Loan loan in _loans.Open())
        {
            int days = _days.Days(loan.Due, _clock.Today);
            int pence = _charge.Pence(days);
            output.Add(_lines.Line(loan, _money.Format(pence)));
        }
        return output;
    }
}
