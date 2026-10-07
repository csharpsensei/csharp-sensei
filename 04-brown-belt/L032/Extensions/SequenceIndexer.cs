namespace WhatsNew.Extensions;

/// <summary>
/// C# 15: an extension indexer. It reads like a list's indexer, but it walks
/// the sequence from the start every time it is used. See the README.
/// </summary>
public static class SequenceIndexer
{
    extension(IEnumerable<string> sequence)
    {
        public string this[int index] => sequence.ElementAt(index);
    }
}
