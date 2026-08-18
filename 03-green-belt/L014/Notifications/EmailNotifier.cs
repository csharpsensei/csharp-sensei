namespace LiskovSubstitution.Notifications;

/// <summary>
/// Keeps the contract. Accepts any message, reports honestly.
/// </summary>
public sealed class EmailNotifier : Notifier
{
    public override string Channel => "Email";

    public override Receipt Send(string recipient, string message)
    {
        // Simplification, named rather than hidden (PRODUCTION-SYSTEM.md 16.3):
        // a real one hands this to an SMTP client or an email API. Nothing
        // leaves the machine here, so the lesson runs with no account and no
        // credentials anywhere in the repo.
        return new Receipt(Channel, true, "1 message");
    }
}
