namespace GenericsFromScratch.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. A generic method that checks the type at runtime
/// and branches on it, which throws away what generics are for. Shown as
/// mistake two; no pass runs it.
/// </summary>
public static class UnconstrainedRanking
{
    public static string Label<T>(T value)
    {
        if (typeof(T) == typeof(int))
            return "weight " + value;
        if (typeof(T) == typeof(string))
            return "crop " + value;

        return "unknown";
    }
}
