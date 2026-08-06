namespace Interfaces.Reporting;

/// <summary>Writes the report to a file. Implements two contracts.</summary>
public sealed class FileDestination : IReportDestination, INamed
{
    private readonly string _folder;

    public FileDestination(string folder) => _folder = folder;

    public string Name => "file";

    public void Send(string report)
    {
        Directory.CreateDirectory(_folder);
        string path = Path.Combine(_folder, "report.txt");
        File.WriteAllText(path, report);
        Console.WriteLine($"Wrote report to {path}");
    }
}
