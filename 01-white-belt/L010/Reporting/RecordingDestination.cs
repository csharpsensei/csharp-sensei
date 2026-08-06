namespace Interfaces.Reporting;

/// <summary>
/// The test double. Four lines, no disk, no network, nothing to clean up —
/// and <see cref="ReportBuilder"/> cannot tell it apart from the real thing,
/// because it was only ever talking to the shape.
/// </summary>
public sealed class RecordingDestination : IReportDestination
{
    public string? Last { get; private set; }

    public void Send(string report) => Last = report;
}
