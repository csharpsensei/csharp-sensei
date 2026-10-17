public sealed class ReadingList(string[] titles) : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator() => new Bookmark(titles);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
