namespace ComponentTests.App.Ports;

/// <summary>
/// The edge where confirmations leave. In the real system this is an email
/// service.
/// </summary>
public interface IConfirmationSender
{
    void Send(string email, int pence);
}
