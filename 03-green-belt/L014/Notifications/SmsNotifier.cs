namespace LiskovSubstitution.Notifications;

/// <summary>
/// Keeps the contract. The 160 character limit is real, and it belongs to
/// the phone network rather than to the caller, so this class absorbs it.
/// It accepts everything the base accepts.
/// </summary>
public sealed class SmsNotifier : Notifier
{
    private const int SegmentLength = 160;

    public override string Channel => "SMS";

    public override Receipt Send(string recipient, string message)
    {
        int parts = 0;

        for (int start = 0; start < message.Length; start += SegmentLength)
        {
            int length = Math.Min(SegmentLength, message.Length - start);
            SendOneSegment(recipient, message.Substring(start, length));
            parts++;
        }

        string note = parts == 1 ? "1 part" : parts + " parts";
        return new Receipt(Channel, true, note);
    }

    private static void SendOneSegment(string recipient, string segment)
    {
        // Simplification, named rather than hidden: a real one calls the
        // gateway here. Splitting is the part the lesson is about.
    }
}
