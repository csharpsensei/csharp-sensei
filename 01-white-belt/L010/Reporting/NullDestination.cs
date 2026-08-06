namespace Interfaces.Reporting;

/// <summary>Sends the report nowhere. Useful when a run must produce no output.</summary>
public sealed class NullDestination : IReportDestination, INamed
{
    public string Name => "null";

    public void Send(string report)
    {
        // Deliberately empty: doing nothing is this destination's whole job.
    }
}
