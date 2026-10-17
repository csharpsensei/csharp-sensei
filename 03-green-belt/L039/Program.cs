using ProxyPattern.Archive;
using ProxyPattern.Proxies;
using ProxyPattern.Reporting;
using ProxyPattern.Security;

// Composition root only. An OpenCounter is handed to every DiskArchive, so
// each pass can prove how many times the expensive thing was really opened.

Pass1Eager();
Pass2Lazy();
Pass3Guarded();

static void Pass1Eager()
{
    var opened = new OpenCounter();
    IReportArchive archive = new DiskArchive(opened);

    Log.Pass("Pass 1: the app starts, and nobody reads anything");
    Log.Item("archives opened        " + opened.Count);
}

static void Pass2Lazy()
{
    var opened = new OpenCounter();
    IReportArchive archive =
        new LazyArchiveProxy(() => new DiskArchive(opened));

    int atStart = opened.Count;
    archive.Read("sales-2026-10");
    archive.Read("sales-2026-09");

    Log.Pass("Pass 2: the same start, behind a lazy proxy");
    Log.Item("opened at start        " + atStart);
    Log.Item("opened after two reads " + opened.Count);
}

static void Pass3Guarded()
{
    var opened = new OpenCounter();
    var sam = new User("Sam", Roles: new[] { "sales" });
    IReportArchive archive = new GuardedArchiveProxy(
        new LazyArchiveProxy(() => new DiskArchive(opened)), sam);

    Log.Pass("Pass 3: a guard proxy, two requests from Sam");
    Log.Item("sales-2026-10  " + Attempt.Read(archive, "sales-2026-10"));
    Log.Item("pay-2026-10    " + Attempt.Read(archive, "pay-2026-10"));
    Log.Item("archives opened        " + opened.Count);
}
