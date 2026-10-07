public static string Explain(PaymentResult result) => result switch
{
    Approved approved => $"approved, code {approved.Code}",
    Declined declined => $"declined: {declined.Reason}",
    Challenged challenged => $"check needed in the {challenged.Method}",
};
