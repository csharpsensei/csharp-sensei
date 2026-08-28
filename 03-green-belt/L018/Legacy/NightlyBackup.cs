using FactoryPattern.Stock;

namespace FactoryPattern.Legacy;

/// <summary>
/// The second place. A different feature, written by a different person on a
/// different day, holding its own copy of the same decision. Nothing stops a
/// third one appearing, and that is the cost the pattern is paid to remove.
///
/// Simplification named rather than hidden (PRODUCTION-SYSTEM.md §16.3): a real
/// nightly job would write to storage and log. This one returns the lines so
/// the lesson can print them.
/// </summary>
public static class NightlyBackup
{
    public static IEnumerable<string> Run(string format)
    {
        // The same decision again. Add a third format and BOTH files change,
        // or one of them is quietly left behind.
        if (format == "csv")
        {
            yield return "sku,name,count";
            foreach (StockLine line in Warehouse.Counted)
            {
                yield return line.Sku + "," + line.Name + "," + line.Count;
            }
        }
        else if (format == "json")
        {
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
