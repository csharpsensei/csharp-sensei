using Shop.Orders;

namespace Shop.Testing;

public class FakeEmailSender : IEmailSender
{
    public List<string> Sent { get; } = [];

    public void Send(string to, string message) => Sent.Add($"{to}: {message}");
}
