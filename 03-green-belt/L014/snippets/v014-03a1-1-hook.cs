public IReadOnlyList<Receipt> SendAll(string recipient,
                                      string message)
{
    List<Receipt> receipts = new List<Receipt>();

    foreach (Notifier notifier in _notifiers)
    {
        receipts.Add(notifier.Send(recipient, message));
    }

    return receipts;
}
