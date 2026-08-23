using DependencyInversion.Fines;

namespace DependencyInversion.Library;

/// <summary>
/// Cycle b. The low level detail. The using line above is the inversion made
/// visible: the machinery references the rules. Look in Fines for a using
/// pointing back at this folder. There is not one.
///
/// SIMPLIFICATION, named here and in the README (PRODUCTION-SYSTEM.md §16.3):
/// a real loan database opens a connection and runs a query.
/// </summary>
public sealed class LoanDatabase : IListLoans
{
    public IReadOnlyList<Loan> Open() => new List<Loan>
    {
        new Loan("The Pragmatic Programmer", new DateOnly(2026, 2, 10)),
        new Loan("Refactoring", new DateOnly(2026, 2, 18)),
        new Loan("Test Driven Development", new DateOnly(2026, 2, 25)),
        new Loan("Domain-Driven Design", new DateOnly(2026, 3, 5)),
    };
}
