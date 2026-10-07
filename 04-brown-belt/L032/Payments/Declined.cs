namespace WhatsNew.Payments;

/// <summary>The payment was refused, and why.</summary>
public sealed record Declined(string Reason);
