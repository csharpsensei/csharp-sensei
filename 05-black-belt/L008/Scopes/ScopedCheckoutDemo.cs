using WideEvents.Models;
using WideEvents.Payments;

namespace WideEvents.Scopes;

/// <summary>
/// The SAME checkout, written the way most people would write it today: with
/// <c>ILogger.BeginScope</c> and nested scopes instead of a wide event.
///
/// WHY THIS EXISTS: "isn't a wide event just BeginScope?" is the first question
/// any C# developer asks, and it deserves a real answer rather than a slogan.
/// This class is the honest version of that approach — not a straw man. It uses
/// scopes correctly, nests them properly, and disposes them in the right order.
///
/// Run it and compare the console output with the wide-event endpoint. The
/// difference is not that this code is wrong. It is that scopes DECORATE log
/// lines, and a wide event REPLACES them.
/// </summary>
public sealed class ScopedCheckoutDemo(
    IPaymentGateway gateway,
    ILogger<ScopedCheckoutDemo> logger)
{
    public async Task<PaymentResult> RunAsync(CheckoutRequest request, CancellationToken ct)
    {
        // OUTER SCOPE — everything the request knows at the door.
        // BeginScope returns an IDisposable. The state is pushed onto a stack
        // that flows with the async execution context, so it survives awaits
        // and reaches code you never passed it to. That part is genuinely good.
        using (logger.BeginScope(new Dictionary<string, object>
               {
                   ["user.id"] = request.UserId,
                   ["user.tier"] = request.Tier
               }))
        {
            logger.LogInformation("checkout started");

            // NESTED SCOPE — the cart, known slightly later. Scopes nest, and
            // both frames apply to anything logged inside this block.
            using (logger.BeginScope(new Dictionary<string, object>
                   {
                       ["cart.value"] = request.Total,
                       ["cart.items"] = request.Items
                   }))
            {
                logger.LogInformation("cart priced");

                var result = await gateway.ChargeAsync(request, ct);

                // THE PROBLEM, IN ONE LINE.
                //
                // ChargeAsync knows the gateway, the attempt and the decline
                // code. It cannot put them on the scope opened above — there is
                // no API to write into an enclosing scope, only to open a new
                // one that ends when it is disposed. So the caller has to
                // receive the values and re-log them, which is exactly the
                // parameter threading the wide event exists to avoid.
                using (logger.BeginScope(new Dictionary<string, object>
                       {
                           ["payment.gateway"] = result.Gateway,
                           ["payment.attempt"] = result.Attempt,
                           ["payment.approved"] = result.Approved
                       }))
                {
                    logger.LogInformation("payment settled");
                }

                // ...and once that scope is disposed, those three fields are
                // gone. Anything logged from here on has forgotten them.
                logger.LogInformation("checkout finished");
                return result;
            }
        }
    }
}
