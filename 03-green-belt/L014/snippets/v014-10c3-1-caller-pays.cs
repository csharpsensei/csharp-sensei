foreach (LooseNotifier notifier in _notifiers)
{
    notifier.Send(recipient, message);

    string channel = "Email";
    string note = "Send returns void. Nothing to check.";

    if (notifier is LooseSmsNotifier)
    {
        channel = "SMS";
        note = "Caller type checked to find the 160 limit.";
    }
}
