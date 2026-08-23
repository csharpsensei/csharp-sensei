public sealed class OverdueReview
{
    private const int PencePerDay = 10;

    private readonly IListLoans _loans;
    private readonly IClock _clock;

    public OverdueReview(IListLoans loans, IClock clock)
    {
        _loans = loans;
        _clock = clock;
    }
