using LiskovSubstitution.Notifications;

namespace LiskovSubstitution.Legacy;

/// <summary>
/// DO NOT COPY. Breaks the first rule: it DEMANDS MORE than the base does.
///
/// The base accepts any message of one character or more. This one accepts
/// messages of up to 160 characters and throws for the rest, so a caller
/// holding a Notifier now has a precondition it was never told about.
/// </summary>
public sealed class LyingSmsNotifier : Notifier
{
    private const int SegmentLength = 160;

    public override string Channel => "SMS";

    public override Receipt Send(string recipient, string message)
    {
        if (message.Length > SegmentLength)
        {
            throw new ArgumentException(
                message.Length + " characters, limit " + SegmentLength);
        }

        return new Receipt(Channel, true, "1 message");
    }
}
