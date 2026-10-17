namespace GenericsFromScratch.Reporting;

/// <summary>Joins any list for printing. Generic too, so it takes ints and strings.</summary>
public static class Describe
{
    public static string List<T>(IEnumerable<T> items) =>
        string.Join(", ", items);
}
