using WideEvents.Models;

namespace WideEvents.Payments;

/// <summary>A payment gateway. Real ones talk to a vendor; this one pretends.</summary>
public interface IPaymentGateway
{
    Task<PaymentResult> ChargeAsync(CheckoutRequest request, CancellationToken ct = default);
}
