public decimal CalculateTotal()
{
    decimal subtotal = _lines.Sum(l => l.Quantity * l.UnitPrice);
    return subtotal + (subtotal * TaxRate);
}
