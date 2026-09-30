using System.Net.Http.Json;
using Microsoft.AspNetCore.Builder;
using WhyWeTest.App;

namespace WhyWeTest.Tests.EndToEnd;

/// <summary>
/// An end to end test: the whole application started on a real port, called
/// over real HTTP, saving to a real disk. The slowest and most expensive kind,
/// so there is one of it, for the journey that matters most.
/// </summary>
[Trait("Kind", "EndToEnd")]
public sealed class QuoteApiTests : IAsyncLifetime
{
    private readonly string _folder =
        Path.Combine(Path.GetTempPath(), "l027-e2e-" + Guid.NewGuid().ToString("N"));

    private WebApplication? _app;
    private HttpClient? _client;

    public async ValueTask InitializeAsync()
    {
        // Port 0 asks the operating system for any free port, so nothing
        // here depends on a number that might already be taken.
        _app = PostageApi.Build("http://127.0.0.1:0", _folder);
        await _app.StartAsync();
        _client = new HttpClient { BaseAddress = new Uri(_app.Urls.First()) };
    }

    [Fact]
    public async Task GetQuote_AfterPostingIt_ReturnsTheSavedPrice()
    {
        // Arrange
        QuoteRequest request = new(Grams: 1500, Express: true);
        HttpResponseMessage posted =
            await _client!.PostAsJsonAsync("/quotes", request);
        Quote? created = await posted.Content.ReadFromJsonAsync<Quote>();

        // Act
        Quote? fetched =
            await _client.GetFromJsonAsync<Quote>($"/quotes/{created!.Id}");

        // Assert
        Assert.Equal(800, fetched!.PriceInPence);
    }

    public async ValueTask DisposeAsync()
    {
        _client?.Dispose();
        if (_app is not null)
        {
            await _app.StopAsync();
            await _app.DisposeAsync();
        }

        if (Directory.Exists(_folder))
        {
            Directory.Delete(_folder, recursive: true);
        }
    }
}
