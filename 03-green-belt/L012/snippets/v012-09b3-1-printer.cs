public class InvoicePrinter
{
    private readonly InvoiceCalculator _calculator;

    public string Print(Invoice invoice)
    {
        // ...formats invoice.Lines, calls _calculator.Calculate(invoice)
    }
}
