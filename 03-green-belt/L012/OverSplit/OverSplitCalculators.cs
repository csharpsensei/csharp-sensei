namespace SingleResponsibility.OverSplit;

using SingleResponsibility.Invoicing;

/// <summary>
/// The "over-applied" version of InvoiceCalculator: one class per method,
/// chasing "one class, one method" instead of "one reason to change".
///
/// Every one of these four classes is still technically single-responsibility
/// in isolation. The lesson's point is that splitting them did not remove a
/// reason to change; tax rate and volume discount are decided by the same
/// team, on the same roadmap. It just added three extra files to read every
/// time that one reason shows up, and a coordinator (TotalCalculator) whose
/// only job is wiring the other three together.
///
/// DO NOT COPY. This is the boundary the lesson warns against, not a
/// pattern to repeat.
/// </summary>
public sealed class TaxCalculator
{
    private const decimal TaxRate = 0.08m;
    public decimal Apply(decimal subtotal) => subtotal * TaxRate;
}

public sealed class DiscountCalculator
{
    public decimal Apply(decimal subtotal, int quantity) => quantity >= 10 ? subtotal * 0.05m : 0m;
}

public sealed class LineItemSummer
{
    public decimal Sum(Invoice invoice) => invoice.Lines.Sum(l => l.Quantity * l.UnitPrice);
}

public sealed class TotalCalculator
{
    private readonly LineItemSummer _summer = new();
    private readonly TaxCalculator _tax = new();
    private readonly DiscountCalculator _discount = new();

    public decimal Calculate(Invoice invoice)
    {
        decimal subtotal = _summer.Sum(invoice);
        decimal tax = _tax.Apply(subtotal);
        int totalQuantity = invoice.Lines.Sum(l => l.Quantity);
        decimal discount = _discount.Apply(subtotal, totalQuantity);
        return subtotal + tax - discount;
    }
}
