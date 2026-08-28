namespace FactoryPattern.Stock;

/// <summary>One counted line of a stocktake.</summary>
public sealed record StockLine(string Sku, string Name, int Count);
