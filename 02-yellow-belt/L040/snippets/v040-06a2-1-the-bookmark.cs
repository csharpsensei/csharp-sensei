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
