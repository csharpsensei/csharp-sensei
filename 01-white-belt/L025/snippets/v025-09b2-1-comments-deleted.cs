    public static decimal OutstandingFees(List<Loan> loans, DateOnly today)
    {
        decimal total = 0m;

        foreach (Loan loan in loans)
        {
            int daysPastDue = today.DayNumber - loan.DueOn.DayNumber;

            if (daysPastDue > LendingPolicy.GraceDays)
            {
                total = total + LateFee.For(daysPastDue);
            }
