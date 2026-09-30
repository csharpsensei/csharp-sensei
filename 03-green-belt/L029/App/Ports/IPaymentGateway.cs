namespace ComponentTests.App.Ports;

/// <summary>
/// The edge where money is taken. In the real system this is a payment
/// provider across the internet.
/// </summary>
public interface IPaymentGateway
{
    bool TryCharge(string email, int pence);
}
