namespace DependencyInversion.Legacy;

/// <summary>
/// Cycle a. The low level detail. Nothing in this file is wrong, which is the
/// point: the problem is in the class that constructs it, not in this one.
///
/// SIMPLIFICATION, named here and in the README (PRODUCTION-SYSTEM.md §16.3):
/// a real loan database opens a connection and runs a query. This one returns
/// a list, because the lesson is about which way a dependency points and not
/// about SQL.
/// </summary>
public sealed class LegacyLoanDatabase
{
    public IReadOnlyList<LegacyLoan> AllLoans() => new List<LegacyLoan>
    {
        new LegacyLoan("The Pragmatic Programmer", new DateOnly(2026, 2, 10)),
        new LegacyLoan("Refactoring", new DateOnly(2026, 2, 18)),
        new LegacyLoan("Test Driven Development", new DateOnly(2026, 2, 25)),
        new LegacyLoan("Domain-Driven Design", new DateOnly(2026, 3, 5)),
    };
}
