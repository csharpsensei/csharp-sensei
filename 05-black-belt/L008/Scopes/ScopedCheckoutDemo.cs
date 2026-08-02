using WideEvents.Models;
using WideEvents.Payments;

namespace WideEvents.Scopes;

/// <summary>
/// The same checkout journey, written with <c>ILogger.BeginScope</c> — done
/// PROPERLY, because this is a technique worth knowing rather than a straw man.
///
/// THE SHAPE THAT MAKES SCOPES VALUABLE:
///
///   immutable context established at the door,
///   more context added by nesting as the journey progresses,
///   every line logged from that point on carrying the whole journey so far.
///
/// That really is elegant, and it costs nothing to thread because the scope
/// stack lives in an AsyncLocal — it flows across awaits and reaches code you
/// never passed anything to.
///
/// It deliberately does NOT touch the wide event: it calls
/// <see cref="PaymentSimulation"/> directly rather than IPaymentGateway, and
/// Program.cs excludes this route from WideEventMiddleware. Otherwise payment
/// fields would appear in customDimensions for this endpoint and it would look
/// as though scope state had reached Azure. It has not, and cannot.
/// </summary>
public sealed class ScopedCheckoutDemo(ILogger<ScopedCheckoutDemo> logger)
{
    public async Task<PaymentResult> RunAsync(CheckoutRequest request, CancellationToken ct)
    {
        // ─── AT THE DOOR ─────────────────────────────────────────────────
        // Who this request is for. Established once, immutable for the whole
        // journey, and every line logged from here down carries it.
        using var who = logger.BeginScope(new Dictionary<string, object>
        {
            ["user.id"] = request.UserId,
            ["user.tier"] = request.Tier
        });

        logger.LogInformation("checkout started");

        // ─── THE JOURNEY WIDENS ──────────────────────────────────────────
        // The cart is known slightly later. Nesting ADDS to the context
        // rather than replacing it: lines inside this block carry the
        // customer AND the cart.
        using var cart = logger.BeginScope(new Dictionary<string, object>
        {
            ["cart.value"] = request.Total,
            ["cart.items"] = request.Items
        });

        logger.LogInformation("cart priced");

        var result = await PaymentSimulation.ChargeAsync(request, ct);

        // ─── WIDER STILL ─────────────────────────────────────────────────
        // Three frames of context now. This innermost line is the richest
        // thing this technique can produce: the whole journey, on one line.
        using var payment = logger.BeginScope(new Dictionary<string, object>
        {
            ["payment.gateway"] = result.Gateway,
            ["payment.attempt"] = result.Attempt,
            ["payment.approved"] = result.Approved
        });

        logger.LogInformation("payment settled");

        // And this is the honest boundary, not a flaw in the code above.
        //
        // The line ABOVE has everything — but it is in the middle of the
        // journey, not at the end of it. To log at the end of the request you
        // have to be back outside these scopes, and by then the fields are
        // gone. "Everything gathered" and "at the end" cannot both be true,
        // because scopes are lexical.
        //
        // A wide event has no such rule: it accumulates in a bag that outlives
        // every frame, and the middleware emits it once when the request is
        // genuinely over.
        return result;
    }
}
