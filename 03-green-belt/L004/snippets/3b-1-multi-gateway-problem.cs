public sealed class CheckoutService
{
    private StripeGateway _stripe;
    private PayPalGateway _paypal;
    private KlarnaGateway _klarna;

    public PaymentResult Pay(Order order)
    {
        if (order.Method == "stripe")
        {
            return _stripe.Charge(order.CustomerId, order.Total);
        }

        if (order.Method == "paypal")
        {
            return _paypal.Charge(order.CustomerId, order.Total);
        }

        return _klarna.Charge(order.CustomerId, order.Total);
    }
}
