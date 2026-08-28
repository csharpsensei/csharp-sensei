using FactoryPattern.Stock;

namespace FactoryPattern.Legacy;

/// <summary>
/// The starting point. The choice of format is written here, at the call site,
/// as a chain of conditionals. It works. Do not copy it: the same chain is in
/// NightlyBackup.cs, and that is the actual problem.
/// </summary>
public static class HandRolledExport
{
    public static IEnumerable<string> Run(string format)
    {
        // The decision about which concrete exporter to build, written inline.
        if (format == "csv")
        {
            yield return "stocktake.csv";
            yield return "sku,name,count";
            foreach (StockLine line in Warehouse.Counted)
            {
                yield return line.Sku + "," + line.Name + "," + line.Count;
            }
        }
        else if (format == "json")
        {
            yield return "stocktake.json";
            yield return "[";
            IReadOnlyList<StockLine> all = Warehouse.Counted;
            for (int i = 0; i < all.Count; i++)
            {
                StockLine line = all[i];
                string comma = i < all.Count - 1 ? "," : "";

                yield return "  {\"sku\":\"" + line.Sku + "\","
                           + "\"name\":\"" + line.Name + "\","
                           + "\"count\":" + line.Count + "}" + comma;
            }
            yield return "]";
        }
        else
        {
            throw new ArgumentException($"Unknown format '{format}'.", nameof(format));
        }
    }
}
