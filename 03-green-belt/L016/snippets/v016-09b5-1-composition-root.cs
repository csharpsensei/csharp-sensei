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
