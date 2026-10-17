namespace ProxyPattern.Archive;

/// <summary>The shape callers depend on. The real archive and both proxies share it.</summary>
public interface IReportArchive
{
    string Read(string reportId);
}
