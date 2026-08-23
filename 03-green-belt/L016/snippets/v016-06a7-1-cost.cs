    private static void LegacyPass()
    {
        Console.WriteLine("Pass 1: it builds its own database (do not copy)");

        LegacyOverdueReview review = new LegacyOverdueReview();
        Console.WriteLine("  " + review.Summarise());
        Console.WriteLine("  No way to ask it about any other date.");

        // C# has no rule against a class building its own collaborators.
        // Every line here was the shortest thing to type on the day.
    }
