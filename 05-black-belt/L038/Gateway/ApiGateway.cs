using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Gateway;

/// <summary>
/// One front door. A path prefix picks the service; the rest of the path is
/// passed on. A simplification named in the README: production gateways use
/// a proxy such as YARP, with timeouts, retries and authentication.
/// </summary>
public static class ApiGateway
{
    public static void AddServices(IServiceCollection services) =>
        services.AddHttpClient();

    public static void Map(WebApplication app, GatewayRoutes routes)
    {
        app.MapGet("/catalog/{**rest}", (string rest, IHttpClientFactory http) =>
            Forwarder.GetAsync(http, routes.Catalog, rest, "catalog"));

        app.MapGet("/stock/{**rest}", (string rest, IHttpClientFactory http) =>
            Forwarder.GetAsync(http, routes.Stock, rest, "stock"));
    }
}
