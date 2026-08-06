namespace Interfaces.Reporting;

/// <summary>
/// Builds a report and hands it to a destination it knows nothing about.
/// The field's TYPE is the whole lesson: it is the interface, not a class.
/// </summary>
public sealed class ReportBuilder
{
    private readonly IReportDestination _destination;

    public ReportBuilder(IReportDestination destination)
        => _destination = destination;

    public string Build() =>
        """
        === Training Report ===
        Sessions this week: 4
        Attendance: 87%
        """;

    public void Publish() => _destination.Send(Build());
}
