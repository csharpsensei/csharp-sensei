using WhyWeTest.App;

namespace WhyWeTest.Tests.Integration;

/// <summary>
/// Integration tests: the store against a real folder on a real disk, through
/// the real JSON serialiser. Slower than a unit test, and it checks the part a
/// unit test cannot: that what goes out comes back.
/// </summary>
[Trait("Kind", "Integration")]
public sealed class JsonQuoteStoreTests : IDisposable
{
    private readonly string _folder =
        Path.Combine(Path.GetTempPath(), "l027-quotes-" + Guid.NewGuid().ToString("N"));

    [Fact]
    public async Task LoadAsync_AfterSaveAsync_ReturnsTheSameQuote()
    {
        // Arrange
        Quote saved = new(
            Guid.NewGuid(), Grams: 1500, Express: true, PriceInPence: 800);
        await new JsonQuoteStore(_folder).SaveAsync(saved);
        JsonQuoteStore freshStore = new(_folder);

        // Act
        Quote? loaded = await freshStore.LoadAsync(saved.Id);

        // Assert
        Assert.Equal(saved, loaded);
    }

    [Fact]
    public async Task LoadAsync_UnknownId_ReturnsNull()
    {
        // Arrange
        JsonQuoteStore store = new(_folder);

        // Act
        Quote? loaded = await store.LoadAsync(Guid.NewGuid());

        // Assert
        Assert.Null(loaded);
    }

    public void Dispose()
    {
        if (Directory.Exists(_folder))
        {
            Directory.Delete(_folder, recursive: true);
        }
    }
}
