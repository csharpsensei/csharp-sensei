public sealed class RecentItems<T>(int capacity)
{
    private readonly List<T> _items = new List<T>();

    public IReadOnlyList<T> Items => _items;
