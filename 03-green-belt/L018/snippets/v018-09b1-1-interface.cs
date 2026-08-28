public interface IExporter
{
    /// <summary>The file name this format would be written to.</summary>
    string FileName { get; }

    IEnumerable<string> Render(IReadOnlyList<StockLine> lines);
}
