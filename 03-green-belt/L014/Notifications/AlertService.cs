namespace LiskovSubstitution.Notifications;

/// <summary>
/// The caller. It holds Notifier and nothing more specific, and it never
/// asks what it is really holding.
///
/// This class is identical before and after the refactor. That is the whole
/// point: the fix is in the subclasses, not here.
/// </summary>
public sealed class AlertService
{
    private readonly IReadOnlyList<Notifier> _notifiers;

    public AlertService(IReadOnlyList<Notifier> notifiers)
    {
        _notifiers = notifiers;
    }

    public IReadOnlyList<Receipt> SendAll(string recipient, string message)
    {
        List<Receipt> receipts = new List<Receipt>();

        foreach (Notifier notifier in _notifiers)
        {
            receipts.Add(notifier.Send(recipient, message));
        }

        return receipts;
    }
}
