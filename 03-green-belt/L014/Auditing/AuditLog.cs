using LiskovSubstitution.Notifications;

namespace LiskovSubstitution.Auditing;

/// <summary>
/// What SilentAuditNotifier became once it stopped pretending.
///
/// It has no base class, because it cannot keep the Notifier contract: it
/// never sends anything to anybody, so it can never honestly report that a
/// message reached a recipient. Taking it out of the hierarchy is the fix.
/// There is no override that would have made it honest.
/// </summary>
public sealed class AuditLog
{
    private readonly List<string> _entries = new List<string>();

    public int Count => _entries.Count;

    public void Record(Receipt receipt)
    {
        _entries.Add(receipt.Channel + ": " + receipt.Note);
    }
}
