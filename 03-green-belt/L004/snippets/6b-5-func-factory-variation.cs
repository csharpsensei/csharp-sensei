services.AddSingleton<Func<string, IPaymentGateway>>(sp => method => method switch
{
    "stripe" => sp.GetRequiredService<StripeGateway>(),
    "paypal" => sp.GetRequiredService<PayPalGateway>(),
    _ => throw new NotSupportedException(method)
});

public sealed class CheckoutService
{
    private readonly Func<string, IPaymentGateway> _gateways;

    public CheckoutService(Func<string, IPaymentGateway> gateways)
        => _gateways = gateways;
}
