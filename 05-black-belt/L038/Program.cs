using Microservices.Gateway;
using Microservices.Hosting;
using Microservices.Monolith;
using Microservices.Reporting;
using Microservices.Services;
using Microsoft.AspNetCore.Builder;

// Composition root only. Three web apps start in this one process, each on a
// port the operating system picks (port 0), so nothing here hard-codes an
// address (PRODUCTION-SYSTEM.md §16.6).

Pass1Monolith();

WebApplication catalog = await ServiceHost.StartAsync(CatalogService.Map);
WebApplication stock = await ServiceHost.StartAsync(StockService.Map);
var routes = new GatewayRoutes(
    ServiceHost.AddressOf(catalog), ServiceHost.AddressOf(stock));
WebApplication gateway = await ServiceHost.StartAsync(
    app => ApiGateway.Map(app, routes), ApiGateway.AddServices);

using var client = new HttpClient();

await Pass2CalledSeparately(client, routes);
await Pass3ThroughTheGateway(client, ServiceHost.AddressOf(gateway));

await stock.StopAsync();
await Pass4StockStopped(client, ServiceHost.AddressOf(gateway));

await gateway.StopAsync();
await catalog.StopAsync();

static void Pass1Monolith()
{
    var page = new ProductPage(new CatalogModule(), new StockModule());

    Log.Pass("Pass 1: the monolith, one process");
    Log.Item(page.Describe(7));
    Log.Item("network calls made         0");
}

static async Task Pass2CalledSeparately(HttpClient client, GatewayRoutes routes)
{
    var name = await client.GetStringAsync(new Uri(routes.Catalog, "products/7"));
    var left = await client.GetStringAsync(new Uri(routes.Stock, "levels/7"));

    Log.Pass("Pass 2: two services, called separately");
    Log.Item("catalog answered  " + name);
    Log.Item("stock answered    " + left);
    Log.Item("addresses the client needed  2");
}

static async Task Pass3ThroughTheGateway(HttpClient client, Uri gateway)
{
    Log.Pass("Pass 3: the same two, through one gateway");
    Log.Item(await Probe.StatusOf(client, gateway, "catalog/products/7"));
    Log.Item(await Probe.StatusOf(client, gateway, "stock/levels/7"));
    Log.Item("addresses the client needed  1");
}

static async Task Pass4StockStopped(HttpClient client, Uri gateway)
{
    Log.Pass("Pass 4: the stock service is stopped");
    Log.Item(await Probe.StatusOf(client, gateway, "catalog/products/7"));
    Log.Item(await Probe.StatusOf(client, gateway, "stock/levels/7"));
}
