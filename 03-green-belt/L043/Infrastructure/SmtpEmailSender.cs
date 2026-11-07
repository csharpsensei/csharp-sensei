using Shop.Orders;

namespace Shop.Infrastructure;

public class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string message) =>
        Console.WriteLine($"SMTP: to {to}: {message}");
}
