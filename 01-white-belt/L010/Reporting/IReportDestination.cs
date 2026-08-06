namespace Interfaces.Reporting;

/// <summary>
/// The socket. A list of members with no bodies and no data: it says WHAT must
/// exist and nothing about HOW. Anything that provides this shape can be handed
/// to <see cref="ReportBuilder"/>, and the builder never learns which one it got.
/// </summary>
public interface IReportDestination
{
    void Send(string report);
}
