// Program.cs — the composition root

IReportDestination destination =
    new FileDestination("reports");

var builder = new ReportBuilder(destination);
builder.Publish();

// To use the console, change one line:
//   new ConsoleDestination();
