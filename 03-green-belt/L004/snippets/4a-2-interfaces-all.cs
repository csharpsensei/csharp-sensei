public interface IEmailSender
{
    void Send(string to, string subject, string body);
}

public interface IOrderRepository
{
    void Save(Order order);
}

public interface IPaymentGateway
{
    PaymentResult Charge(int customerId, decimal amount);
}
