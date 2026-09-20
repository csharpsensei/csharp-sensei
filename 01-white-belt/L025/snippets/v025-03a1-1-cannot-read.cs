public static class LendingDataManager
{
    public static List<string> Process(List<Loan> l, DateOnly d, bool f)
    {
        List<string> r = new List<string>();

        foreach (Loan x in l)
        {
            int n = d.DayNumber - x.DueOn.DayNumber;
            bool b = n > LendingPolicy.GraceDays;
