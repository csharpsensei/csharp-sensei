public interface IReportDestination
{
    void Send(string report);

    void SendAll(IEnumerable<string> reports)
    {
        foreach (string r in reports) Send(r);
    }
}

// For adding to a published interface
// without breaking its implementers.
