using WhatsNew.Payments;

namespace WhatsNew.Regression;

/// <summary>
/// DO NOT COPY THIS SHAPE. The switch was written before Refunded existed and
/// was never updated, so the compiler warns that it is not exhaustive.
/// </summary>
public static class MissingCaseMessages
{
    public static string Explain(PaymentResultWithRefund result) => result switch
    {
        Approved approved => $"approved, code {approved.Code}",
        Declined declined => $"declined: {declined.Reason}",
        Challenged challenged => $"check needed in the {challenged.Method}",
    };
}
