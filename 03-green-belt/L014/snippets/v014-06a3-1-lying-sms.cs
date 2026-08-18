// DO NOT COPY
public sealed class LyingSmsNotifier : Notifier
{
    private const int SegmentLength = 160;

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
