public static T Largest<T>(IEnumerable<T> items)
    where T : IComparable<T>
{
    T best = items.First();
    foreach (T item in items)
    {
        if (item.CompareTo(best) > 0)
            best = item;
    }

    return best;
}
