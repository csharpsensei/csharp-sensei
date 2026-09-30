using ComponentTests.App.Ports;

namespace ComponentTests.Tests.Fakes;

/// <summary>
/// A stand in for the email service. Nothing is sent; each confirmation is
/// written down so a test can check it.
/// </summary>
public sealed class FakeConfirmationSender : IConfirmationSender
{
    public List<string> Sent { get; } = new();

    public void Send(string email, int pence)
    {
        Sent.Add(email);
    }
}
