static void Pass1Eager()
{
    var opened = new OpenCounter();
    IReportArchive archive = new DiskArchive(opened);

    Log.Pass("Pass 1: the app starts, and nobody reads anything");
    Log.Item("archives opened        " + opened.Count);
}
