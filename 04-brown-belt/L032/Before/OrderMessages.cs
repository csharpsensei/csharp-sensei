namespace WhatsNew.Before;

/// <summary>
/// Before C# 15: the switch needs a discard arm, because the compiler cannot
/// prove that Packed and Shipped are the only kinds of OrderStatus.
/// </summary>
public static class OrderMessages
{
    public static string Describe(OrderStatus status) => status switch
    {
        Packed => "packed, waiting for the van",
        Shipped(var on) => $"shipped on {on:yyyy-MM-dd}",
        _ => throw new ArgumentOutOfRangeException(nameof(status)),
    };
}
