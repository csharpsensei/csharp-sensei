public sealed class InvoiceService
{
    public string Issue(string customer) =>
        InvoiceNumbers.Instance.Next() + "  " + customer;
}
