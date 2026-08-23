namespace DependencyInversion.Fines;

/// <summary>
/// Declared here, in the policy's own folder, in the policy's own words,
/// because the policy is the thing that needs it. Whatever implements it
/// lives elsewhere and depends on this file. Nothing here depends on that.
/// </summary>
public interface IListLoans
{
    IReadOnlyList<Loan> Open();
}
