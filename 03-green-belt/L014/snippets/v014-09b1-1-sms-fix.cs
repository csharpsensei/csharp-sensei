private const int SegmentLength = 160;

public override Receipt Send(string recipient, string message)
{
    int parts = 0;
    for (int start = 0; start < message.Length; start += SegmentLength)
    {
        int length = Math.Min(SegmentLength, message.Length - start);
        SendOneSegment(recipient, message.Substring(start, length));
        parts++;
    }

    return new Receipt(Channel, true, parts + " parts");
}
