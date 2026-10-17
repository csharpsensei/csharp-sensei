public static string Label<T>(T value)
{
    if (typeof(T) == typeof(int))
        return "weight " + value;
    if (typeof(T) == typeof(string))
        return "crop " + value;

    return "unknown";
}
