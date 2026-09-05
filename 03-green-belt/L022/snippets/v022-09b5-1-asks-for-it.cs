public sealed class BillingService
{
    private readonly IInvoiceNumbers _numbers;

    public BillingService(IInvoiceNumbers numbers) => _numbers = numbers;

    public string Issue(string customer) => _numbers.Next() + "  " + customer;
}
