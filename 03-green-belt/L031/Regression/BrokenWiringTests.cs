using System.Net;
using System.Net.Http.Json;
using EndToEndTests.App.Bookings;
using Microsoft.AspNetCore.Builder;

namespace EndToEndTests.Regression;

/// <summary>
/// The first end to end test, pointed at the broken wiring. Explicit, so a
/// plain `dotnet run` skips it and stays green.
/// </summary>
public sealed class BrokenWiringTests : IAsyncLifetime
{
    private static readonly DateOnly Monday = new(2026, 11, 2);

    private WebApplication? _app;
    private HttpClient? _client;

    public async ValueTask InitializeAsync()
    {
        _app = BrokenRepairShopApi.Build("http://127.0.0.1:0");
        await _app.StartAsync();
        _client = new HttpClient { BaseAddress = new Uri(_app.Urls.First()) };
    }

    [Fact(Explicit = true)]
    public async Task GetBooking_AfterBookingIt_ReturnsTheBooking()
    {
        // Arrange
        HttpResponseMessage posted = await _client!.PostAsJsonAsync(
            "/bookings", new BookingRequest("Ada Byrne", Monday));
        Booking? booked = await posted.Content.ReadFromJsonAsync<Booking>();

        // Act
        HttpResponseMessage fetched = await _client.GetAsync($"/bookings/{booked!.Id}");

        // Assert
        Assert.Equal(HttpStatusCode.OK, fetched.StatusCode);
        Assert.Equal(booked, await fetched.Content.ReadFromJsonAsync<Booking>());
    }

    public async ValueTask DisposeAsync()
    {
        _client?.Dispose();
        if (_app is not null)
        {
            await _app.StopAsync();
            await _app.DisposeAsync();
        }
    }
}
