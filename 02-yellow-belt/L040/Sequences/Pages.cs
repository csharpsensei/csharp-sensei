namespace HowIterationWorks.Sequences;

/// <summary>
/// A yield method. The compiler writes the bookmark for you, and none of
/// this body runs until somebody asks for the first item.
/// </summary>
public static class Pages
{
    public static IEnumerable<string> Written(int count, List<string> trace)
    {
        for (int page = 1; page <= count; page++)
        {
            trace.Add("  making page " + page);
            yield return "page " + page;
        }
    }
}
