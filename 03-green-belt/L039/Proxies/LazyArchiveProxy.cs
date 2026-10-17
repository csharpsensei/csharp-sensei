using ProxyPattern.Archive;

namespace ProxyPattern.Proxies;

/// <summary>
/// A virtual proxy. Stands in front of the real archive, looks exactly like
/// it, and does not create it until the first read actually needs it.
/// </summary>
public sealed class LazyArchiveProxy(Func<DiskArchive> open) : IReportArchive
{
    private DiskArchive? _real;

    public string Read(string reportId)
    {
        _real ??= open();
        return _real.Read(reportId);
    }
}
