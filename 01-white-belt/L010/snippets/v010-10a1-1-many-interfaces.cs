public interface INamed
{
    string Name { get; }
}

public class FileDestination
    : IReportDestination, INamed
{
    public string Name => "file";
    public void Send(string report) { /* ... */ }
}
