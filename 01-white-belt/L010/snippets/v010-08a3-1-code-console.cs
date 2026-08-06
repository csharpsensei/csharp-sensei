public class ConsoleDestination : IReportDestination
{
    public void Send(string report)
        => Console.WriteLine(report);
}

// No folder. No constructor. No file handling.
// Shares no code with FileDestination at all.
