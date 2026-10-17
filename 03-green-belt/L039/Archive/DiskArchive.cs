namespace ProxyPattern.Archive;

/// <summary>
/// The real thing, and it is expensive to open: in a real system, mounting
/// storage, loading an index, authenticating. Here the constructor records
/// that it happened, a simplification named in the README.
/// </summary>
public sealed class DiskArchive : IReportArchive
{
    public DiskArchive(OpenCounter opened)
    {
        opened.Record();
    }

    public string Read(string reportId) => "contents of " + reportId;
}
