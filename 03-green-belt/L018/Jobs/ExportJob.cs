using FactoryPattern.Exporting;
using FactoryPattern.Stock;

namespace FactoryPattern.Jobs;

/// <summary>
/// Factory Method, and this is the Gang of Four one. The steps of an export
/// live here once. The single step this class refuses to decide, which exporter
/// to build, is left as an abstract method for a subclass to answer.
/// </summary>
public abstract class ExportJob
{
    protected ExportJob(string label) => Label = label;

    public string Label { get; }

    /// <summary>The factory method: the one step a subclass decides.</summary>
    protected abstract IExporter CreateExporter();

    public IEnumerable<string> Run()
    {
        IExporter exporter = CreateExporter();

        yield return Label + " -> " + exporter.FileName;
        foreach (string line in exporter.Render(Warehouse.Counted))
        {
            yield return line;
        }
    }
}
