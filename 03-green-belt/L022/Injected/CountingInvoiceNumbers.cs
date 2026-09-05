namespace SingletonPattern.Injected;

/// <summary>
/// The same counter as the naive version, with the two static members taken
/// off it. The constructor is public, so the composition root can decide
/// whether the application gets one of these or several.
/// </summary>
public sealed class CountingInvoiceNumbers : IInvoiceNumbers
{
    private int _next = 1;

    public string Next() => "INV-" + _next++;
}
