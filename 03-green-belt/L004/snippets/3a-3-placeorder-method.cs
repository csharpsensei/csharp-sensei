public sealed class OrderService
{
    private readonly SqlOrderRepository _repository = new("Server=prod-db-01;");
    private readonly SmtpEmailSender _email = new("smtp.contoso.com", 587);
    private readonly StripePaymentGateway _payments = new("sk_live_4f2ac91b");

    public void PlaceOrder(Order order)
    {
        _payments.Charge(order.CustomerId, order.Total);
        _repository.Save(order);
        _email.Send(order.CustomerEmail, "Order confirmed",
            $"Thanks for order {order.Id}.");
    }
}
