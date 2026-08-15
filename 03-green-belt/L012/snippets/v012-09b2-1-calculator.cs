public class InvoiceCalculator
{
    public decimal Calculate(Invoice invoice)
    {
        decimal subtotal = invoice.Lines.Sum(l => l.Quantity * l.UnitPrice);
        return subtotal + (subtotal * TaxRate);
    }
}
