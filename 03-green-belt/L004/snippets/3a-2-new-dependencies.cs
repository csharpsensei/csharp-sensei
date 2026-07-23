public sealed class OrderService
{
    private readonly SqlOrderRepository _repository =
        new SqlOrderRepository("Server=prod-db-01;Database=Orders;");

    private readonly SmtpEmailSender _email =
        new SmtpEmailSender("smtp.contoso.com", 587);

    private readonly StripePaymentGateway _payments =
        new StripePaymentGateway("sk_live_4f2ac91b");

    public void PlaceOrder(Order order)
    {
    }
}
