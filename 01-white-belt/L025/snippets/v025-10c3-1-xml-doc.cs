    /// <summary>
    /// True when the loan is still out and it is further past its due date
    /// than the grace period allows.
    /// </summary>
    /// <param name="loan">The loan being judged.</param>
    /// <param name="today">The date the desk is running its report for.</param>
    public static bool IsOverdue(Loan loan, DateOnly today)
