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
