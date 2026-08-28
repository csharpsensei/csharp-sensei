using FactoryPattern.Stock;

namespace FactoryPattern.Exporting;

/// <summary>
/// Hand written JSON, on purpose. A real exporter would use System.Text.Json;
/// this one spells the string out so every character on screen is one you can
/// read, and so the output cannot move with a serialiser's defaults
/// (PRODUCTION-SYSTEM.md §16.3).
/// </summary>
public sealed class JsonExporter : IExporter
{
    public string FileName => "stocktake.json";

    public IEnumerable<string> Render(IReadOnlyList<StockLine> lines)
    {
        yield return "[";
        for (int i = 0; i < lines.Count; i++)
        {
            StockLine line = lines[i];
            string comma = i < lines.Count - 1 ? "," : "";

            yield return "  {\"sku\":\"" + line.Sku + "\","
                       + "\"name\":\"" + line.Name + "\","
                       + "\"count\":" + line.Count + "}" + comma;
        }
        yield return "]";
    }
}
