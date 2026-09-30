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
