namespace WhatsNew.Payments;

/// <summary>
/// A pretend card gateway. A real one calls the bank; this one decides from
/// the amount so the lesson can show all three results. Named in the README.
/// </summary>
public static class CardGateway
{
    public static PaymentResult Charge(decimal amount)
    {
        if (amount <= 0)
        {
            return new Declined("amount must be above zero");
        }

        if (amount > 500)
        {
            return new Challenged("bank app");
        }

        return new Approved("A1B2");
    }
}
