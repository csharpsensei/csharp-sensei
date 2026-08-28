using FactoryPattern.Stock;

namespace FactoryPattern.Exporting;

/// <summary>Comma separated, one header row, one row per counted line.</summary>
public sealed class CsvExporter : IExporter
{
    public string FileName => "stocktake.csv";

    public IEnumerable<string> Render(IReadOnlyList<StockLine> lines)
    {
        yield return "sku,name,count";
        foreach (StockLine line in lines)
        {
            yield return line.Sku + "," + line.Name + "," + line.Count;
        }
    }
}
