public sealed record Approved(string Code);
public sealed record Declined(string Reason);
public sealed record Challenged(string Method);

public union PaymentResult(Approved, Declined, Challenged);
