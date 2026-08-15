namespace SingleResponsibility.Invoicing;

/// <summary>
/// One job: where invoices live. Its only reason to change is a storage
/// decision, a new database, a new table shape. It does not know how tax
/// is calculated or how a receipt is laid out.
/// </summary>
public sealed class InvoiceRepository
{
    private readonly InvoiceCalculator _calculator;

    public InvoiceRepository(InvoiceCalculator calculator) => _calculator = calculator;

    public void Save(Invoice invoice)
    {
        // Stands in for a real database write for this lesson.
        Console.WriteLine($"[db] saved invoice for {invoice.Customer}, total {_calculator.Calculate(invoice):C}");
    }
}
