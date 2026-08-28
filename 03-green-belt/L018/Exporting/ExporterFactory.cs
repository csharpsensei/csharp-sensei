namespace FactoryPattern.Exporting;

/// <summary>
/// A Simple Factory. The one place in the program that knows which concrete
/// exporter a format name means. Adding a format edits this file and no other.
///
/// This is not one of the Gang of Four twenty three. It is the lightest shape
/// in the creational family and it is where most codebases stop, correctly.
/// </summary>
public static class ExporterFactory
{
    public static IExporter For(string format) => format switch
    {
        "csv" => new CsvExporter(),
        "json" => new JsonExporter(),
        _ => throw new ArgumentException(
                 $"Unknown format '{format}'.", nameof(format))
    };
}
