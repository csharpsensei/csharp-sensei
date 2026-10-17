public sealed class LazyArchiveProxy(Func<DiskArchive> open) : IReportArchive
{
    private DiskArchive? _real;

    public string Read(string reportId)
    {
        _real ??= open();
        return _real.Read(reportId);
    }
