// DO NOT COPY
public sealed class SilentAuditNotifier : Notifier
{
    public override string Channel => "Audit";

    public override Receipt Send(string recipient, string message)
    {
        _entries.Add(recipient + ": " + message);

        // Nothing was sent to anybody.
        return new Receipt(Channel, true, "written to the audit list");
    }
}
