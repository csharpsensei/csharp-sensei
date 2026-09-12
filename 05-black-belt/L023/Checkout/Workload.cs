using TailSampling.Sampling;

namespace TailSampling.Checkout;

/// <summary>
/// Builds the same two thousand checkouts every time it is asked, so every
/// number this sample prints can be checked against the numbers on screen.
/// </summary>
public static class Workload
{
    public const int Count = 2000;

    private const int Seed = 20260908;
    private const int VipPercent = 4;
    private const int FailPercent = 6;
    private const int SlowPercent = 5;

    public static List<Order> Build()
    {
        Deterministic rng = new Deterministic(Seed);
        List<Order> orders = new List<Order>(Count);

        for (int id = 1; id <= Count; id++)
        {
            string tier = rng.Next(100) < VipPercent ? "vip" : "standard";
            bool failed = rng.Next(100) < FailPercent;
            bool slow = rng.Next(100) < SlowPercent;

            orders.Add(new Order(id, tier, failed, slow));
        }

        return orders;
    }
}
