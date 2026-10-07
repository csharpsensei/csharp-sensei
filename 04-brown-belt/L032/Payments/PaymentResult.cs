namespace WhatsNew.Payments;

/// <summary>
/// A C# 15 union: a payment result is exactly one of these three cases.
/// </summary>
public union PaymentResult(Approved, Declined, Challenged);
