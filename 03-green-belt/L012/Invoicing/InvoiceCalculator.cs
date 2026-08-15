namespace SingleResponsibility.Invoicing;

/// <summary>
/// One job: tax math. Its only reason to change is a tax rule, because
/// tax math is the only thing it does.
/// </summary>
public sealed class InvoiceCalculator
{
    private const decimal TaxRate = 0.08m;

    public decimal Calculate(Invoice invoice)
    {
        decimal subtotal = invoice.Lines.Sum(l => l.Quantity * l.UnitPrice);
        return subtotal + (subtotal * TaxRate);
    }
}
