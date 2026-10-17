public static IEnumerable<string> Written(int count, List<string> trace)
{
    for (int page = 1; page <= count; page++)
    {
        trace.Add("  making page " + page);
        yield return "page " + page;
    }
