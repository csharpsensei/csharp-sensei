using System.Collections;

namespace HowIterationWorks.Reading;

/// <summary>
/// The bookmark: one reader's place in the book. MoveNext turns the page and
/// says whether there was one; Current is the page you are on.
/// </summary>
public sealed class Bookmark(string[] titles) : IEnumerator<string>
{
    private int _position = -1;

    public string Current => titles[_position];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _position++;
        return _position < titles.Length;
    }

    public void Reset() => _position = -1;

    public void Dispose()
    {
        // Nothing to release: an array index holds no resources.
    }
}
