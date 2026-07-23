public sealed class CheckoutService
{
    private readonly IPaymentGatewayFactory _gateways;

    public CheckoutService(IPaymentGatewayFactory gateways)
        => _gateways = gateways;

    public PaymentResult Pay(Order order)
    {
        var gateway = _gateways.Create(order.Method);
        return gateway.Charge(order.CustomerId, order.Total);
    }
}
