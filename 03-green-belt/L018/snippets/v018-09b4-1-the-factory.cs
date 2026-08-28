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
