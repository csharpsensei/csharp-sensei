// Byte for byte the same class as cycle a. Nothing here moved.

foreach (Notifier notifier in _notifiers)
{
    receipts.Add(notifier.Send(recipient, message));
}
