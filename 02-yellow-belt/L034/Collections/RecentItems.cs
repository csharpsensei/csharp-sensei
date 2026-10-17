namespace GenericsFromScratch.Collections;

/// <summary>
/// Keeps the most recent items, up to a capacity. Written once, with T as a
/// blank for the type; the caller fills the blank, and the compiler checks
/// every Add against it.
/// </summary>
public sealed class RecentItems<T>(int capacity)
{
    private readonly List<T> _items = new List<T>();

    public IReadOnlyList<T> Items => _items;

    public void Add(T item)
    {
        _items.Add(item);
        if (_items.Count > capacity)
            _items.RemoveAt(0);
    }
}
