using EndToEndTests.App.Bookings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EndToEndTests.App;

/// <summary>
/// The whole application, wired together. In a real solution this wiring
/// lives in the app's own Program.cs. Here the end to end tests host it, so
/// the lesson stays in one project (see README).
/// </summary>
public static class RepairShopApi
{
    public static WebApplication Build(string url)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        // The server's own log lines would land in the middle of the test
        // runner's output, so the lesson's console stills turn them off.
        builder.Logging.ClearProviders();

        builder.Services.AddSingleton<IBookingStore, InMemoryBookingStore>();
        builder.Services.AddScoped<BookingService>();

        WebApplication app = builder.Build();
        app.Urls.Add(url);
        RepairShopEndpoints.Map(app);
        return app;
    }
}
