public sealed class InvoiceNumbers
{
    private static InvoiceNumbers? _instance;

    private int _next = 1;

    private InvoiceNumbers()
    {
    }

    public static InvoiceNumbers Instance => _instance ??= new InvoiceNumbers();

    public string Next() => "INV-" + _next++;
}
