using WideEvents.Events;
using WideEvents.Models;

namespace WideEvents.Payments;

/// <summary>
/// Stands in for a real payment vendor.
///
/// It is deliberately shaped so the queries in L008.http have
/// something true to find: enterprise customers with large carts really are
/// slower here, and really do decline more often. That is a simulation, not a
/// claim about any real gateway — but the numbers the KQL returns are honestly
/// derived from what the code did, rather than invented for a slide.
/// </summary>
public sealed class SimulatedPaymentGateway(IHttpContextAccessor accessor) : IPaymentGateway
{
    private const decimal LargeCart = 500m;

    public async Task<PaymentResult> ChargeAsync(
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
        var latency = baseline + Random.Shared.Next(0, 250);
        await Task.Delay(latency, ct);

        var attempt = large && Random.Shared.NextDouble() < 0.35 ? 2 : 1;
        var approved = !(large && Random.Shared.NextDouble() < 0.45);
        var declineCode = approved
            ? null
            : Random.Shared.NextDouble() < 0.7 ? "insufficient_funds" : "do_not_honour";

        // Each layer contributes the one or two things only it knows. Reaching
        // the event through IHttpContextAccessor is what "no parameter
        // threading" costs: a dependency here instead of a parameter on every
        // signature between the endpoint and this class.
        if (accessor.HttpContext is { } http)
        {
            var evt = http.Event();
            evt.Set("payment.gateway", gateway);
            evt.Set("payment.attempt", attempt);
            evt.Set("payment.approved", approved);
            if (declineCode is not null) evt.Set("payment.decline_code", declineCode);
        }

        return new PaymentResult(approved, gateway, declineCode, attempt);
    }
}
