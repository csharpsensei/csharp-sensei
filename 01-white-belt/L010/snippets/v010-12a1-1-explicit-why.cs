public interface IReportDestination
{
    void Send(string report);
}

public interface IAuditLog
{
    void Send(string entry);   // same name,
}                              // different meaning
