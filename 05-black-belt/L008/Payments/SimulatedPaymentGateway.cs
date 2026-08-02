using WideEvents.Events;
using WideEvents.Models;

namespace WideEvents.Payments;

/// <summary>
/// Stands in for a real payment vendor.
///
/// The decision itself lives in <see cref="PaymentSimulation"/>; this class's
/// only job is to make that call and then RECORD what happened on the request's
/// wide event. Deciding and recording are different jobs, and keeping them in
/// one class is what let the BeginScope demo contaminate this one — see
/// PaymentSimulation.
/// </summary>
public sealed class SimulatedPaymentGateway(IHttpContextAccessor accessor) : IPaymentGateway
{
    public async Task<PaymentResult> ChargeAsync(
        CheckoutRequest request, CancellationToken ct = default)
    {
        var result = await PaymentSimulation.ChargeAsync(request, ct);

        // Each layer contributes the one or two things only it knows. Reaching
        // the event through IHttpContextAccessor is what "no parameter
        // threading" costs: a dependency here instead of a parameter on every
        // signature between the endpoint and this class.
        if (accessor.HttpContext is { } http)
        {
            var evt = http.Event();
            evt.Set("payment.gateway", result.Gateway);
            evt.Set("payment.attempt", result.Attempt);
            evt.Set("payment.approved", result.Approved);
            if (result.DeclineCode is not null)
                evt.Set("payment.decline_code", result.DeclineCode);
        }

        return result;
    }
}
