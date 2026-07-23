public sealed class PaymentGatewayFactory : IPaymentGatewayFactory
{
    private readonly IServiceProvider _provider;

    public PaymentGatewayFactory(IServiceProvider provider)
        => _provider = provider;

    public IPaymentGateway Create(string method) => method switch
    {
        "stripe" => _provider.GetRequiredService<StripeGateway>(),
        "paypal" => _provider.GetRequiredService<PayPalGateway>(),
        "klarna" => _provider.GetRequiredService<KlarnaGateway>(),
        _ => throw new NotSupportedException($"Unknown method '{method}'.")
    };
}
