    public string Summarise()
    {
        // Not a value being read. A call out to the operating system, from
        // inside a business rule, and as hard wired as the field above it.
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);

        IReadOnlyList<LegacyLoan> loans = _database.AllLoans();
        int overdue = 0;
