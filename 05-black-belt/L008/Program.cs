using Azure.Monitor.OpenTelemetry.AspNetCore;
using WideEvents.Events;
using WideEvents.Models;
using WideEvents.Payments;
using WideEvents.Seeding;

var builder = WebApplication.CreateBuilder(args);

// --- telemetry -------------------------------------------------------------
// The connection string is NEVER passed in code and never committed. Azure
// Monitor reads APPLICATIONINSIGHTS_CONNECTION_STRING from the environment (or
// from user-secrets in development) entirely on its own — see README.md.
//
// Wired up only when a connection string is actually present, so the app runs
// standalone with no Azure account: the wide events still go to the console,
// they just do not leave the machine.
var hasConnectionString = !string.IsNullOrWhiteSpace(
    builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

if (hasConnectionString)
    builder.Services.AddOpenTelemetry().UseAzureMonitor(o =>
    {
        // Distro 1.5.0 changed the default sampler to RATE LIMITED at 5 traces
        // per second. Seed 400 checkouts in 17 seconds and roughly 85 of them
        // reach the portal — every percentile in this lesson would be computed
        // from a fifth of the data, and nothing would look broken.
        //
        // TracesPerSecond takes precedence over SamplingRatio, so it has to be
        // switched off explicitly; setting the ratio alone does nothing.
        o.TracesPerSecond = null;
        o.SamplingRatio = 1.0F;
    });

// --- application services --------------------------------------------------
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IPaymentGateway, SimulatedPaymentGateway>();
builder.Services.AddSingleton<TrafficSeeder>();

// No BaseAddress here on purpose. The app must not carry a second, hard-coded
// opinion about which port it is listening on — the two copies drift, and the
// seeder spends its whole run calling a port nothing is bound to. The address
// comes from the incoming /seed request instead, so the seeder always talks to
// the app you just hit.
builder.Services.AddHttpClient(TrafficSeeder.ClientName,
    client => client.Timeout = TimeSpan.FromSeconds(30));

var app = builder.Build();

app.Logger.LogInformation(
    hasConnectionString
        ? "Azure Monitor enabled — wide events will appear in the requests table."
        : "No APPLICATIONINSIGHTS_CONNECTION_STRING — wide events go to the console only.");

// One wide event per request, for every request, emitted once at the end.
app.UseMiddleware<WideEventMiddleware>();

app.MapPost("/checkout", async (
    CheckoutRequest request,
    HttpContext http,
    IPaymentGateway gateway,
    CancellationToken ct) =>
{
    // The endpoint contributes what it knows: who is buying, and what is in the
    // basket. The gateway adds its own fields from inside ChargeAsync — that is
    // the point of the pattern, not an accident of where the code lives.
    var evt = http.Event();
    evt.Set("user.id", request.UserId);
    evt.Set("user.tier", request.Tier);
    evt.Set("cart.value", request.Total);
    evt.Set("cart.items", request.Items);

    var result = await gateway.ChargeAsync(request, ct);

    return result.Approved
        ? Results.Ok(new { status = "approved", result.Gateway })
        : Results.Json(new { status = "declined", result.DeclineCode }, statusCode: 402);
});

// Generates enough traffic for a percentile to mean something — see TrafficSeeder.
app.MapPost("/seed", async (
    TrafficSeeder seeder,
    HttpContext http,
    CancellationToken ct,
    int count = 400,
    int concurrency = 16) =>
{
    // Whatever address you reached this endpoint on is the address the seeded
    // requests go to. Nothing to configure, nothing to keep in sync.
    var self = new Uri($"{http.Request.Scheme}://{http.Request.Host}");
    return Results.Ok(new { target = self, seeded = await seeder.SeedAsync(self, count, concurrency, ct) });
});

app.Run();
