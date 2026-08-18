using LiskovSubstitution.Notifications;

namespace LiskovSubstitution.Legacy;

/// <summary>
/// DO NOT COPY. Breaks the second rule: it DELIVERS LESS than the base
/// promises.
///
/// The base says Delivered is true only when the message reached the
/// recipient. This one appends a line to its own list and returns true
/// anyway, so a caller that retries on Delivered false will never retry and
/// the customer hears nothing. It does not crash, which makes it the worse
/// of the two failures.
/// </summary>
public sealed class SilentAuditNotifier : Notifier
{
    private readonly List<string> _entries = new List<string>();

    public override string Channel => "Audit";

    public override Receipt Send(string recipient, string message)
    {
        _entries.Add(recipient + ": " + message);

        // Nothing was sent to anybody. The receipt below says otherwise.
        return new Receipt(Channel, true, "written to the audit list");
    }
}
