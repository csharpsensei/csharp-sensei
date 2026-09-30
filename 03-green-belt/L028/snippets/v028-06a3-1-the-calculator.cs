public int FeeInPence(DateOnly due, DateOnly returned)
{
    int daysLate = returned.DayNumber - due.DayNumber;

    if (daysLate <= 0)
    {
        return 0;
    }

    return Math.Min(daysLate * PencePerDay, CapInPence);
}
