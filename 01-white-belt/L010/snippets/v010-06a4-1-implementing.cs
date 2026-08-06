public class ConsoleDestination : IReportDestination
{
    public void Send(string report)
    {
        Console.WriteLine(report);
    }
}
