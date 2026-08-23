using DependencyInversion.Doubles;
using DependencyInversion.Fines;
using DependencyInversion.Legacy;
using DependencyInversion.Library;

namespace DependencyInversion;

public static class Program
{
    public static void Main()
    {
        LegacyPass();
        Console.WriteLine();
        InvertedPass();
    }

    /// <summary>Cycle a. The review builds its own database. Do not copy.</summary>
    private static void LegacyPass()
    {
        Console.WriteLine("Pass 1: it builds its own database (do not copy)");

        LegacyOverdueReview review = new LegacyOverdueReview();
        Console.WriteLine("  " + review.Summarise());
        Console.WriteLine("  No way to ask it about any other date.");

        // C# has no rule against a class building its own collaborators.
        // Every line here was the shortest thing to type on the day.
    }

    /// <summary>
    /// Cycle b. The composition root: the one place that knows both halves.
    /// No container, no registration, no framework. A constructor and a Main.
    /// </summary>
    private static void InvertedPass()
    {
        Console.WriteLine("Pass 2: it depends on interfaces it owns");

        IListLoans loans = new LoanDatabase();
        IClock marchFirst = new FixedClock(new DateOnly(2026, 3, 1));

        OverdueReview review = new OverdueReview(loans, marchFirst);

        Console.WriteLine("  as at 2026-03-01");
        foreach (string line in review.Lines())
        {
            Console.WriteLine(line);
        }

        IClock earlier = new FixedClock(new DateOnly(2026, 2, 24));
        int owed = new OverdueReview(loans, earlier).TotalPence();
        Console.WriteLine($"  as at 2026-02-24: {owed}p");

        OverdueReview live = new OverdueReview(loans, new SystemClock());
        int lateToday = live.OverdueCount();
        Console.WriteLine($"  on the real clock: {lateToday} of 4 late today");

        // What the fix was not: no container, no service locator, no factory
        // and no abstraction on top of an abstraction. Two interfaces were
        // declared next to the code that needed them, and two classes that
        // already existed were told to implement them.
    }
}
