using EndToEndTests.App;
using EndToEndTests.App.Bookings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EndToEndTests.Regression;

/// <summary>
/// DO NOT COPY THIS SHAPE. The same application with one line of wiring
/// wrong: the store is registered per request, so every request gets a new,
/// empty store. Every class still passes its own tests.
/// </summary>
public static class BrokenRepairShopApi
{
    public static WebApplication Build(string url)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Logging.ClearProviders();

        builder.Services.AddScoped<IBookingStore, InMemoryBookingStore>();
        builder.Services.AddScoped<BookingService>();

        WebApplication app = builder.Build();
        app.Urls.Add(url);
        RepairShopEndpoints.Map(app);
        return app;
    }
}
