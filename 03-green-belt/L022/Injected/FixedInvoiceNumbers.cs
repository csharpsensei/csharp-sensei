namespace SingletonPattern.Injected;

/// <summary>
/// A test double, and the point is that it is possible at all. Against the
/// static version there is no way to write this: the caller does not ask for
/// a number source, so there is nothing to give it.
/// </summary>
public sealed class FixedInvoiceNumbers : IInvoiceNumbers
{
    private readonly string _number;

    public FixedInvoiceNumbers(string number) => _number = number;

    public string Next() => _number;
}
