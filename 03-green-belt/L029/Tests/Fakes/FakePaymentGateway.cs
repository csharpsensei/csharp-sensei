using ComponentTests.App.Ports;

namespace ComponentTests.Tests.Fakes;

/// <summary>
/// A stand in for the payment provider. It remembers every charge, and a
/// test can tell it to decline.
/// </summary>
public sealed class FakePaymentGateway : IPaymentGateway
{
    public bool Declines { get; init; }

    public List<int> Charges { get; } = new();

    public bool TryCharge(string email, int pence)
    {
        if (Declines)
        {
            return false;
        }

        Charges.Add(pence);
        return true;
    }
}
