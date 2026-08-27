public sealed class DepartureBoard
{
    private readonly IDepartureSource _source;
    private readonly IDelayPolicy _policy;

    public DepartureBoard(IDepartureSource source, IDelayPolicy policy)
    {
        _source = source;
        _policy = policy;
    }
