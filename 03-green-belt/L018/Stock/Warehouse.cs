namespace FactoryPattern.Stock;

/// <summary>
/// The counted stock. Three lines, held in memory, so that every pass in this
/// lesson exports exactly the same data and any difference in the output is
/// the exporter and nothing else.
/// </summary>
public static class Warehouse
{
    public static IReadOnlyList<StockLine> Counted { get; } = new[]
    {
        new StockLine("BOLT-M6", "Hex bolt M6", 1420),
        new StockLine("WSHR-M6", "Washer M6", 860),
        new StockLine("NUT-M6", "Nyloc nut M6", 95)
    };
}
