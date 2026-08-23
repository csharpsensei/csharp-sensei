using DependencyInversion.Fines;

namespace DependencyInversion.Library;

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
