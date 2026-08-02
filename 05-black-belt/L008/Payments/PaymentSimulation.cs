using WideEvents.Models;

namespace WideEvents.Payments;

/// <summary>
/// The gateway's DECISION, with no opinion about how it gets recorded.
///
/// Split out from <see cref="SimulatedPaymentGateway"/> on 2 August 2026 so the
/// BeginScope comparison in <c>Scopes/ScopedCheckoutDemo.cs</c> can run exactly
/// the same logic without also writing to the wide event. Sharing the gateway
/// itself made the comparison dishonest: payment fields appeared in
/// customDimensions for the scoped endpoint, and it looked as though scopes had
/// reached Azure when in fact the wide event had put them there.
///
/// Deciding and recording are different jobs. Keeping them in one class is what
/// let the two demos contaminate each other.
/// </summary>
public static class PaymentSimulation
{
    private const decimal LargeCart = 500m;

    public static async Task<PaymentResult> ChargeAsync(
        CheckoutRequest request, CancellationToken ct = default)
    {
        var enterprise = request.Tier.Equals("enterprise", StringComparison.OrdinalIgnoreCase);
        var large = request.Total >= LargeCart;

        // Enterprise carts route through a gateway that does more work:
        // fraud scoring, invoicing checks, purchase-order lookup.
        var gateway = enterprise ? "adyen" : "stripe";

        // The latency the hook question is about.
        var baseline = enterprise ? 900 : 180;
        if (large) baseline += 700;
        await Task.Delay(baseline + Random.Shared.Next(0, 250), ct);

        var attempt = large && Random.Shared.NextDouble() < 0.35 ? 2 : 1;
        var approved = !(large && Random.Shared.NextDouble() < 0.45);
        var declineCode = approved
            ? null
            : Random.Shared.NextDouble() < 0.7 ? "insufficient_funds" : "do_not_honour";

        return new PaymentResult(approved, gateway, declineCode, attempt);
    }
}
