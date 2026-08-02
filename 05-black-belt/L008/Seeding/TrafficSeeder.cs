using System.Net.Http.Json;
using WideEvents.Models;

namespace WideEvents.Seeding;

/// <summary>
/// Fires a burst of realistic checkout traffic at this application.
///
/// WHY THIS EXISTS: a percentile over nine requests is not a percentile. The
/// queries this lesson builds — p95 by tier, decline rate by cart band,
/// failures per hour — only say anything truthful once there are a few hundred
/// events behind them. Clicking a .http file by hand cannot get you there, and
/// a chart drawn from five data points would be a lie told with real data.
/// </summary>
public sealed class TrafficSeeder(IHttpClientFactory factory, ILogger<TrafficSeeder> logger)
{
    /// <summary>Named client registered in Program.cs. Deliberately has no BaseAddress.</summary>
    public const string ClientName = "self";

    /// <summary>Four hundred identical stack traces tell you nothing the first one did not.</summary>
    private const int MaxFailuresLogged = 3;

    private static readonly string[] Tiers = ["free", "free", "free", "business", "business", "enterprise"];

    /// <summary>
    /// Sends <paramref name="count"/> randomised checkouts to <paramref name="baseAddress"/>,
    /// <paramref name="concurrency"/> at a time.
    /// </summary>
    /// <param name="baseAddress">
    /// Where to send them. Passed in by the caller — the seeder must not hold its own
    /// idea of which port the app is on, or the two can disagree.
    /// </param>
    public async Task<int> SeedAsync(
        Uri baseAddress, int count, int concurrency, CancellationToken ct = default)
    {
        using var client = factory.CreateClient(ClientName);
        client.BaseAddress = baseAddress;

        var sent = 0;
        var failed = 0;

        using var gate = new SemaphoreSlim(concurrency);
        var work = Enumerable.Range(0, count).Select(async _ =>
        {
            await gate.WaitAsync(ct);
            try
            {
                // A decline is a 402 and is still a real event worth recording —
                // it is the failure data half the queries in this lesson read.
                var response = await client.PostAsJsonAsync("/checkout", NextCheckout(), ct);
                if (response.IsSuccessStatusCode || (int)response.StatusCode == 402)
                    Interlocked.Increment(ref sent);
            }
            catch (Exception ex)
            {
                if (Interlocked.Increment(ref failed) <= MaxFailuresLogged)
                    logger.LogWarning(ex, "seed request to {Target} failed", baseAddress);
            }
            finally
            {
                gate.Release();
            }
        });

        await Task.WhenAll(work);

        if (failed > 0)
            logger.LogWarning(
                "{Failed} of {Count} seed requests failed against {Target} " +
                "(only the first {Logged} were logged in full)",
                failed, count, baseAddress, MaxFailuresLogged);

        logger.LogInformation("seeded {Sent} of {Count} checkouts to {Target}", sent, count, baseAddress);
        return sent;
    }

    private static CheckoutRequest NextCheckout()
    {
        var tier = Tiers[Random.Shared.Next(Tiers.Length)];

        // Enterprise carts skew large — which is what makes the cart-value
        // band query interesting rather than uniform noise.
        var total = tier switch
        {
            "enterprise" => Random.Shared.Next(200, 2400),
            "business" => Random.Shared.Next(80, 900),
            _ => Random.Shared.Next(10, 300)
        };

        return new CheckoutRequest(
            UserId: $"u_{Random.Shared.Next(10_000, 99_999)}",
            Tier: tier,
            Total: total + Math.Round((decimal)Random.Shared.NextDouble(), 2),
            Items: Random.Shared.Next(1, 9));
    }
}
