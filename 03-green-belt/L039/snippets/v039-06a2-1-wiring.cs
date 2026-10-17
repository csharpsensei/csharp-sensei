IReportArchive archive =
    new LazyArchiveProxy(() => new DiskArchive(opened));
