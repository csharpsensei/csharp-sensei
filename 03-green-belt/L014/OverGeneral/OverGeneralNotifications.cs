namespace LiskovSubstitution.OverGeneral;

/// <summary>
/// DO NOT COPY. The over-corrected base.
///
/// Every subclass is substitutable here, because there is nothing left to
/// break. Send returns void, so there is no receipt to be wrong about, and
/// the contract says only that the method exists. By the letter of the
/// principle this passes perfectly, and it is worse than the version it
/// replaced, because the cost moved onto every caller.
///
/// Several types share this file, which PRODUCTION-SYSTEM.md 16.2 says not
/// to do. Deliberate, and the only deviation in this project: the point of
/// the example is how little each of these types says, and spreading four
/// near-empty classes across four files hides that.
/// </summary>
public abstract class LooseNotifier
{
    public abstract void Send(string recipient, string message);
}

/// <summary>DO NOT COPY.</summary>
public sealed class LooseEmailNotifier : LooseNotifier
{
    public override void Send(string recipient, string message)
    {
    }
}

/// <summary>
/// DO NOT COPY. Silently drops anything past 160 characters, which is legal
/// under a contract that promises nothing.
/// </summary>
public sealed class LooseSmsNotifier : LooseNotifier
{
    public override void Send(string recipient, string message)
    {
    }
}

/// <summary>
/// DO NOT COPY. The caller pays for the empty contract.
///
/// It needs to know what happened and the base cannot tell it, so it asks
/// what type it really has. That type check is substitutability leaving the
/// compiler and moving into an if statement, where nothing can check it.
/// </summary>
public sealed class LooseAlertService
{
    private readonly IReadOnlyList<LooseNotifier> _notifiers;

    public LooseAlertService(IReadOnlyList<LooseNotifier> notifiers)
    {
        _notifiers = notifiers;
    }

    public void SendAll(string recipient, string message)
    {
        const string Status = "sent?";

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

            Console.WriteLine($"  {channel,-10}{Status,-14}{note}");
        }
    }
}
