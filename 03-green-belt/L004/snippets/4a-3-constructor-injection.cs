public sealed class OrderService
{
    private readonly IOrderRepository _repository;
    private readonly IEmailSender _email;
    private readonly IPaymentGateway _payments;

    public OrderService(
        IOrderRepository repository,
        IEmailSender email,
        IPaymentGateway payments)
    {
        _repository = repository;
        _email = email;
        _payments = payments;
    }
}
