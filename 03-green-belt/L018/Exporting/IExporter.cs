using FactoryPattern.Stock;

namespace FactoryPattern.Exporting;

/// <summary>
/// One export format. The caller asks for this and never names an
/// implementation, which is the whole point of the pattern.
/// </summary>
public interface IExporter
{
    /// <summary>The file name this format would be written to.</summary>
    string FileName { get; }

    IEnumerable<string> Render(IReadOnlyList<StockLine> lines);
}
