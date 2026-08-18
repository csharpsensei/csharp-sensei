using LiskovSubstitution.Notifications;

namespace LiskovSubstitution.Legacy;

/// <summary>
/// DO NOT COPY. Pass 1's runner.
///
/// The try/catch is here so the lesson can carry on past the failure and
/// show the rest of the pass. A real caller holding a Notifier has no reason
/// to expect an exception and would not have written it. Needing this catch
/// at all is the bug, not the workaround, so it prints the exception type
/// and message rather than swallowing anything.
/// </summary>
public sealed class LegacyAlertRun
{
    private readonly IReadOnlyList<Notifier> _notifiers;

    public LegacyAlertRun(IReadOnlyList<Notifier> notifiers)
    {
        _notifiers = notifiers;
    }

    public void SendAll(string recipient, string message)
    {
        foreach (Notifier notifier in _notifiers)
        {
            try
            {
                Receipt receipt = notifier.Send(recipient, message);
                string status = receipt.Delivered ? "delivered" : "not delivered";
                Console.WriteLine($"  {receipt.Channel,-10}{status,-14}{receipt.Note}");
            }
            catch (ArgumentException ex)
            {
                string status = "THREW";
                string note = ex.GetType().Name + ": " + ex.Message;
                Console.WriteLine($"  {notifier.Channel,-10}{status,-14}{note}");
            }
        }
    }
}
