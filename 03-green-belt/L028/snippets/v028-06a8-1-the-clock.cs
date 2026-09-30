public int FeeInPence(DateOnly due)
{
    DateOnly today = DateOnly.FromDateTime(DateTime.Today);
    int daysLate = today.DayNumber - due.DayNumber;

    if (daysLate <= 0)
    {
        return 0;
    }

    return Math.Min(daysLate * 20, 500);
}
