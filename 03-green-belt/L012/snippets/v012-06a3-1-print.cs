public string PrintReceipt()
{
    var sb = new StringBuilder();
    sb.AppendLine($"Receipt for {_customer}");
    foreach (var line in _lines)
        sb.AppendLine($"  {line.Item} x{line.Quantity} {line.UnitPrice:C}");
    return sb.ToString();
}
