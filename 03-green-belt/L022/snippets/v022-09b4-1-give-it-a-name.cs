public interface IInvoiceNumbers
{
    string Next();
}

public sealed class CountingInvoiceNumbers : IInvoiceNumbers
{
    private int _next = 1;

    public string Next() => "INV-" + _next++;
}
