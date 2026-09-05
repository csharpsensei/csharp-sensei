namespace SingletonPattern.Naive;

/// <summary>
/// The textbook singleton, written exactly as it is usually taught: a private
/// constructor so nobody else can build one, a static field to hold the one
/// that exists, and a static property that hands it out.
///
/// Nothing here is wrong as code. What it does is take a decision that belongs
/// to the application (how many of these there are, and how long they live)
/// and move it inside the type, where no caller can see it or change it.
/// </summary>
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
