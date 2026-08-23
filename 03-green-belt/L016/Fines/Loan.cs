namespace DependencyInversion.Fines;

/// <summary>A book that is out, and the date it is due back.</summary>
public sealed record Loan(string Title, DateOnly Due);
