namespace SingleResponsibility.Invoicing;

/// <summary>
/// One job: how the receipt looks on paper. Its only reason to change is
/// a layout request. It does not know how tax is calculated, and it does
/// not need to.
/// </summary>
public sealed class InvoicePrinter
{
    private readonly InvoiceCalculator _calculator;

    public InvoicePrinter(InvoiceCalculator calculator) => _calculator = calculator;

    public string Print(Invoice invoice)
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"Receipt for {invoice.Customer}");
        foreach (var line in invoice.Lines)
            sb.AppendLine($"  {line.Item,-20} x{line.Quantity,-3} {line.UnitPrice,8:C}");
        sb.AppendLine($"  {"Total",-20}     {_calculator.Calculate(invoice),8:C}");
        return sb.ToString();
    }
}
