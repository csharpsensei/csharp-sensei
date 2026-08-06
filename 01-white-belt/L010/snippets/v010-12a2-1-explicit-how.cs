public class FileDestination
    : IReportDestination, IAuditLog
{
    void IReportDestination.Send(string report)
        => File.WriteAllText("report.txt", report);

    void IAuditLog.Send(string entry)
        => File.AppendAllText("audit.log", entry);
}

// Interface name in front. No access modifier.
