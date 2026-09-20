namespace NamingAndComments.Lending;

public static class LateFee
{
    // The cap is here because a fee larger than the price of the book made
    // members keep the book rather than bring it back and face the desk.
    // Takings went down and stock went missing. Removing the cap is a policy
    // decision, not a tidy-up.
    public static decimal For(int daysPastDue)
    {
        int chargeableDays = daysPastDue - LendingPolicy.GraceDays;
        decimal fee = chargeableDays * LendingPolicy.FeePerDay;

        return Math.Min(fee, LendingPolicy.MaximumFee);
    }
}
