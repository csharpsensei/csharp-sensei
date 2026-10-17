using System.Collections;

namespace HowIterationWorks.Reading;

/// <summary>
/// The book. It can hand out a bookmark, and that is all IEnumerable asks.
/// Written by hand so the two halves can be seen; yield does this for you.
/// </summary>
public sealed class ReadingList(string[] titles) : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator() => new Bookmark(titles);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
