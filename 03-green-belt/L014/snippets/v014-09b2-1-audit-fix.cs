// No base class. It cannot keep the Notifier contract, so
// it is not a subtype, and no override would have fixed that.
public sealed class AuditLog
{
    private readonly List<string> _entries = new List<string>();

    public int Count => _entries.Count;

    public void Record(Receipt receipt)
    {
        _entries.Add(receipt.Channel + ": " + receipt.Note);
    }
}
