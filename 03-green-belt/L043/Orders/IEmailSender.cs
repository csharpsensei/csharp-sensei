namespace Shop.Orders;

public interface IEmailSender
{
    void Send(string to, string message);
}
