namespace SingleResponsibility.Invoicing;

/// <summary>
/// The "after". Invoice itself is data only: the order lines and the
/// customer. It has no reason to change on its own, because it does not
/// do anything, it just holds what the other three classes need.
/// </summary>
public sealed class Invoice
{
    public string Customer { get; }
    public IReadOnlyList<(string Item, int Quantity, decimal UnitPrice)> Lines { get; }

    public Invoice(string customer, IEnumerable<(string Item, int Quantity, decimal UnitPrice)> lines)
    {
        Customer = customer;
        Lines = lines.ToList();
    }
}
