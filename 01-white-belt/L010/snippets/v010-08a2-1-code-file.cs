public class FileDestination : IReportDestination
{
    private readonly string _folder;

    public FileDestination(string folder)
        => _folder = folder;

    public void Send(string report)
    {
        string path = Path.Combine(_folder, "report.txt");
        File.WriteAllText(path, report);
    }
}
