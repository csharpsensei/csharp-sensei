namespace DependencyInversion.Legacy;

/// <summary>Cycle a. A book that is out, and the date it is due back.</summary>
public sealed record LegacyLoan(string Title, DateOnly Due);
