IReportArchive archive = new GuardedArchiveProxy(
    new LazyArchiveProxy(() => new DiskArchive(opened)), sam);
