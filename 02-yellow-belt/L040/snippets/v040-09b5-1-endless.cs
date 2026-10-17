public static IEnumerable<int> From(int start)
{
    int next = start;
    while (true)
    {
        yield return next++;
    }
