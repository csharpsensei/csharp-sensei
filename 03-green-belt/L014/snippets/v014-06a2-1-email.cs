public sealed class EmailNotifier : Notifier
{
    public override string Channel => "Email";

    public override Receipt Send(string recipient,
                                 string message)
    {
        return new Receipt(Channel, true, "1 message");
    }
}
