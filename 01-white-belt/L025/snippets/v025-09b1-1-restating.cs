    public static decimal Total(List<Loan> loans, DateOnly today)
    {
        // running total
        decimal t = 0m;

        // loop through the loans
        foreach (Loan loan in loans)
        {
            // work out how many days past due it is
            int n = today.DayNumber - loan.DueOn.DayNumber;

            // if it is more than the grace period, add the fee
            if (n > LendingPolicy.GraceDays)
