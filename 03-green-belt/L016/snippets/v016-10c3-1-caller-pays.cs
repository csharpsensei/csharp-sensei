    public OverSplitReview(IListLoans loans,
                           IClock clock,
                           ICountDaysLate days,
                           IChargePerDay charge,
                           IFormatMoney money,
                           IBuildLine lines)
    {
        _loans = loans;
        _clock = clock;
        _days = days;
        _charge = charge;
        _money = money;
        _lines = lines;
    }
