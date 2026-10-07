namespace WhatsNew.Payments;

/// <summary>The bank wants the customer to confirm it first, and where.</summary>
public sealed record Challenged(string Method);
