namespace WhatsNew.Orders;

/// <summary>
/// C# 15: no discard arm. The compiler knows Packed and Shipped are every
/// direct case of the closed OrderStatus.
/// </summary>
public static class OrderMessages
{
    public static string Describe(OrderStatus status) => status switch
    {
        Packed => "packed, waiting for the van",
        Shipped(var on) => $"shipped on {on:yyyy-MM-dd}",
    };
}
