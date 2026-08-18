// The caller. It holds Notifier and nothing more specific,
// and it never asks what it is really holding.

foreach (Notifier notifier in _notifiers)
{
    receipts.Add(notifier.Send(recipient, message));
}
