public void Add(T item)
{
    _items.Add(item);
    if (_items.Count > capacity)
        _items.RemoveAt(0);
}
