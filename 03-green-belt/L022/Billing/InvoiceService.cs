using SingletonPattern.Naive;

namespace SingletonPattern.Billing;

/// <summary>
/// The class the whole lesson is about, and the thing to look at is its
/// constructor: it takes nothing. Read the signature and you would say this
/// class has no dependencies at all. It has one, and it is a piece of shared,
/// mutable state that outlives every instance of this type.
/// </summary>
public sealed class InvoiceService
{
    public string Issue(string customer) =>
        InvoiceNumbers.Instance.Next() + "  " + customer;
}
