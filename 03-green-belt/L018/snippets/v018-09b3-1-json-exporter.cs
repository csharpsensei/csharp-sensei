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
