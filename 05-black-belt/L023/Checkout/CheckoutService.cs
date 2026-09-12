using System.Diagnostics;

namespace TailSampling.Checkout;

/// <summary>
/// The work, instrumented the ordinary way: one activity per checkout, tags
/// on it, status set if it failed.
///
/// Note the question mark on every line. StartActivity returns null when no
/// listener has asked for this source, which is the whole of head sampling in
/// one detail.
/// </summary>
public sealed class CheckoutService
{
    public const string SourceName = "Shop.Checkout";

    /// <summary>
    /// How long a slow checkout takes. Comfortably over TailPolicy's
    /// threshold, so the count does not depend on timer resolution.
    /// </summary>
    public const int SlowMilliseconds = 25;

    private static readonly ActivitySource Source = new ActivitySource(SourceName);

    public void Run(Order order)
    {
        using Activity? activity = Source.StartActivity("POST /checkout");

        activity?.SetTag("http.route", "/checkout/{id}");
        activity?.SetTag("http.response.status_code", order.Failed ? 500 : 200);

        // Nothing in ASP.NET Core and nothing in OpenTelemetry puts these on
        // the span. They are the only reason the policy can say anything
        // more interesting than "it failed" or "it was slow".
        activity?.SetTag("customer.tier", order.Tier);
        activity?.SetTag("cart.value", order.Id % 400);
        activity?.SetTag("order.id", order.Id);

        if (order.Slow)
        {
            Thread.Sleep(SlowMilliseconds);
        }

        if (order.Failed)
        {
            activity?.SetStatus(ActivityStatusCode.Error, "payment declined");
        }
    }
}
