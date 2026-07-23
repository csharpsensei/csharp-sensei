services.AddKeyedScoped<IPaymentGateway, StripeGateway>("stripe");
services.AddKeyedScoped<IPaymentGateway, PayPalGateway>("paypal");
services.AddKeyedScoped<IPaymentGateway, KlarnaGateway>("klarna");

public sealed class StripeCheckout
{
    private readonly IPaymentGateway _gateway;

    public StripeCheckout([FromKeyedServices("stripe")] IPaymentGateway gateway)
        => _gateway = gateway;
}
