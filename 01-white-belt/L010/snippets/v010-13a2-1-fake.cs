public class RecordingDestination : IReportDestination
{
    public string? Last { get; private set; }
    public void Send(string report) => Last = report;
}

var recorder = new RecordingDestination();
new ReportBuilder(recorder).Publish();

// recorder.Last holds exactly what was built.
// No disk. No network. Nothing to clean up.
