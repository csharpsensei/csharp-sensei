namespace HowIterationWorks.Sequences;

/// <summary>A sequence with no end. Safe, because each number is made only when asked.</summary>
public static class Counting
{
    public static IEnumerable<int> From(int start)
    {
        int next = start;
        while (true)
        {
            yield return next++;
        }
    }
}
