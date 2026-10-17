public static void Map(WebApplication app, GatewayRoutes routes)
{
    app.MapGet("/catalog/{**rest}", (string rest, IHttpClientFactory http) =>
        Forwarder.GetAsync(http, routes.Catalog, rest, "catalog"));

    app.MapGet("/stock/{**rest}", (string rest, IHttpClientFactory http) =>
        Forwarder.GetAsync(http, routes.Stock, rest, "stock"));
}
