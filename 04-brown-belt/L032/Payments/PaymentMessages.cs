namespace WhatsNew.Payments;

/// <summary>
/// Turns a payment result into words. The switch names every case, so it
/// needs no discard arm, and the compiler warns if a case is ever missed.
/// </summary>
public static class PaymentMessages
{
    public static string Explain(PaymentResult result) => result switch
    {
        Approved approved => $"approved, code {approved.Code}",
        Declined declined => $"declined: {declined.Reason}",
        Challenged challenged => $"check needed in the {challenged.Method}",
    };
}
