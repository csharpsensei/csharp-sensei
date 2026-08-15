public class InvoiceRepository
{
    private readonly InvoiceCalculator _calculator;

    public void Save(Invoice invoice)
    {
        Console.WriteLine($"[db] saved invoice for {invoice.Customer}, " +
            $"total {_calculator.Calculate(invoice):C}");
    }
}
