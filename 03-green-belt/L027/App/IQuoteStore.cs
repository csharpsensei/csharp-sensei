namespace WhyWeTest.App;

/// <summary>Somewhere quotes are kept, so they can be fetched again later.</summary>
public interface IQuoteStore
{
    Task SaveAsync(Quote quote);

    Task<Quote?> LoadAsync(Guid id);
}
