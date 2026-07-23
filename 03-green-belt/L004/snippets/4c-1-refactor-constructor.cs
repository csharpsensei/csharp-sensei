public sealed class InvoiceService
{
    private readonly IOrderRepository _repository;
    private readonly IEmailSender _email;
    private readonly IPdfRenderer _pdf;

    public InvoiceService(
        IOrderRepository repository, IEmailSender email, IPdfRenderer pdf)
    {
        _repository = repository;
        _email = email;
        _pdf = pdf;
    }
}
