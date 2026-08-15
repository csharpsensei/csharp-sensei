namespace SingleResponsibility.Legacy;

/// <summary>
/// The "before". One class, three unrelated jobs: tax math, receipt
/// formatting, and storage. Demoed once in Program.cs and then abandoned,
/// the same convention as V011's Legacy/NaiveDispatch.cs.
///
/// DO NOT COPY into a real project. This is the violation the lesson
/// exists to fix.
/// </summary>
public sealed class InvoiceGodClass
{
    private readonly List<(string Item, int Quantity, decimal UnitPrice)> _lines = new();
    private readonly string _customer;
    private const decimal TaxRate = 0.08m;

    public InvoiceGodClass(string customer) => _customer = customer;

    public void AddLine(string item, int quantity, decimal unitPrice) =>
        _lines.Add((item, quantity, unitPrice));

    // Reason to change #1: a tax rule.
    public decimal CalculateTotal()
    {
        decimal subtotal = _lines.Sum(l => l.Quantity * l.UnitPrice);
        return subtotal + (subtotal * TaxRate);
    }

    // Reason to change #2: how the receipt looks on paper.
    public string PrintReceipt()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"Receipt for {_customer}");
        foreach (var line in _lines)
            sb.AppendLine($"  {line.Item,-20} x{line.Quantity,-3} {line.UnitPrice,8:C}");
        sb.AppendLine($"  {"Total",-20}     {CalculateTotal(),8:C}");
        return sb.ToString();
    }

    // Reason to change #3: where invoices are stored.
    public void Save()
    {
        // Stands in for a real database write for this lesson.
        Console.WriteLine($"[db] saved invoice for {_customer}, total {CalculateTotal():C}");
    }
}
