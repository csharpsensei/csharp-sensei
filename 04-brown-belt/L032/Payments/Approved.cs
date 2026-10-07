namespace WhatsNew.Payments;

/// <summary>The bank took the money. Code is the bank's approval code.</summary>
public sealed record Approved(string Code);
