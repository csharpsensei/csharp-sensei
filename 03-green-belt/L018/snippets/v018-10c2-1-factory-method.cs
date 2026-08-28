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
