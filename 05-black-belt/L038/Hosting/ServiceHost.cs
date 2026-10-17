using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microservices.Hosting;

/// <summary>
/// Starts one small web app on a port the operating system chooses, and
/// reports the address it really got. Server log lines are turned off so the
/// console shows only the lesson's own output.
/// </summary>
public static class ServiceHost
{
    public static async Task<WebApplication> StartAsync(
        Action<WebApplication> map,
        Action<IServiceCollection>? services = null)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Logging.ClearProviders();
        services?.Invoke(builder.Services);

        WebApplication app = builder.Build();
        app.Urls.Add("http://127.0.0.1:0");
        map(app);
        await app.StartAsync();
        return app;
    }

    public static Uri AddressOf(WebApplication app) =>
        new Uri(app.Urls.First() + "/");
}
