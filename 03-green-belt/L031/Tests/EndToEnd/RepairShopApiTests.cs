using System.Net;
using System.Net.Http.Json;
using EndToEndTests.App;
using EndToEndTests.App.Bookings;
using Microsoft.AspNetCore.Builder;

namespace EndToEndTests.Tests.EndToEnd;

/// <summary>
/// End to end tests: the whole application, wired exactly as it ships,
/// started on a real port and called over real HTTP, the way a customer's
/// app would call it. xUnit builds a new instance of this class for every
/// test, so every test gets an application of its own.
/// </summary>
[Trait("Kind", "EndToEnd")]
public sealed class RepairShopApiTests : IAsyncLifetime
{
    private static readonly DateOnly Monday = new(2026, 11, 2);

    private WebApplication? _app;
    private HttpClient? _client;

    public async ValueTask InitializeAsync()
    {
        // Port 0 asks the operating system for any free port, so nothing
        // here depends on a number that might already be taken.
        _app = RepairShopApi.Build("http://127.0.0.1:0");
        await _app.StartAsync();
        _client = new HttpClient { BaseAddress = new Uri(_app.Urls.First()) };
    }

    [Fact]
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

    [Fact]
    public async Task Book_DayAlreadyTaken_ReturnsConflict()
    {
        // Arrange
        await _client!.PostAsJsonAsync("/bookings", new BookingRequest("Ada Byrne", Monday));

        // Act
        HttpResponseMessage second = await _client.PostAsJsonAsync(
            "/bookings", new BookingRequest("Ben Okafor", Monday));

        // Assert
        Assert.Equal(HttpStatusCode.Conflict, second.StatusCode);
    }

    [Fact]
    public async Task Book_NoName_ReturnsBadRequest()
    {
        // Arrange
        BookingRequest noName = new("", Monday);

        // Act
        HttpResponseMessage response = await _client!.PostAsJsonAsync("/bookings", noName);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
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
