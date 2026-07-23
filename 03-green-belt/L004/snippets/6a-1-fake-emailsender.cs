public sealed class FakeEmailSender : IEmailSender
{
    public List<(string To, string Subject)> Sent { get; } = new();

    public void Send(string to, string subject, string body)
        => Sent.Add((to, subject));
}
