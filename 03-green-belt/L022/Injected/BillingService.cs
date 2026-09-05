namespace SingletonPattern.Injected;

/// <summary>
/// The same job as <see cref="SingletonPattern.Billing.InvoiceService"/>, with one difference
/// that is visible from outside: the constructor says what it needs. Nothing
/// in here knows or cares whether the object it was handed is shared with
/// anybody else.
/// </summary>
public sealed class BillingService
{
    private readonly IInvoiceNumbers _numbers;

    public BillingService(IInvoiceNumbers numbers) => _numbers = numbers;

    public string Issue(string customer) => _numbers.Next() + "  " + customer;
}
