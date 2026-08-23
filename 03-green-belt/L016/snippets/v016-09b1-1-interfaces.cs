// Fines/IListLoans.cs
public interface IListLoans
{
    IReadOnlyList<Loan> Open();
}

// Fines/IClock.cs
public interface IClock
{
    DateOnly Today { get; }
}
