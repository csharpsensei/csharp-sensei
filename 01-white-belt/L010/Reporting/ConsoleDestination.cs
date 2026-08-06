namespace Interfaces.Reporting;

/// <summary>
/// Shares no code, no fields and no base class with <see cref="FileDestination"/>.
/// The only thing the two have in common is the shape of Send — and that is
/// enough for <see cref="ReportBuilder"/> to treat them identically.
/// </summary>
public sealed class ConsoleDestination : IReportDestination, INamed
{
    public string Name => "console";

    public void Send(string report) => Console.WriteLine(report);
}
