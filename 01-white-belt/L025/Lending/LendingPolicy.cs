namespace NamingAndComments.Lending;

/// <summary>
/// The desk's lending rules, in one place.
/// </summary>
/// <remarks>
/// A static class holding constants and no state. This is the case the
/// singleton lesson deliberately left alone: there is nothing to mock, nothing
/// to swap and nothing that can be in a wrong state, so there is no seam worth
/// cutting here.
/// </remarks>
public static class LendingPolicy
{
    public const int GraceDays = 7;

    public const decimal FeePerDay = 0.20m;

    public const decimal MaximumFee = 12.00m;
}
