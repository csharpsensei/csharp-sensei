public sealed class OrderService
{
    private readonly IEmailSender _email;

    public OrderService(IEmailSender email) => _email = email;

    public IClock Clock { get; set; } = new SystemClock();

    public void PlaceOrder(Order order, ICurrencyConverter converter)
    {
    }
}
