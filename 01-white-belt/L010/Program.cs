// Program.cs is the composition root and nothing else (PRODUCTION-SYSTEM §16.2).
// It is the ONE place that decides which real destination is used. Every other
// file in this project knows only IReportDestination.
using Interfaces.Reporting;

Console.WriteLine("=== 1. A file destination ===");
IReportDestination file = new FileDestination("reports");
new ReportBuilder(file).Publish();

Console.WriteLine();
Console.WriteLine("=== 2. The console instead. One line changed. ===");
IReportDestination console = new ConsoleDestination();
new ReportBuilder(console).Publish();

Console.WriteLine();
Console.WriteLine("=== 3. Several at once ===");
var all = new List<IReportDestination>
{
    new ConsoleDestination(),
    new NullDestination()
};
var report = new ReportBuilder(new NullDestination()).Build();
foreach (IReportDestination destination in all)
{
    destination.Send(report);
}

Console.WriteLine();
Console.WriteLine("=== 4. The test that was impossible ===");
var recorder = new RecordingDestination();
new ReportBuilder(recorder).Publish();
Console.WriteLine(recorder.Last is null
    ? "FAIL: nothing was sent"
    : $"PASS: recorded {recorder.Last.Split('\n').Length} lines, no disk touched");
