public static string Describe(OrderStatus status) => status switch
{
    Packed => "packed, waiting for the van",
    Shipped(var on) => $"shipped on {on:yyyy-MM-dd}",
    _ => throw new ArgumentOutOfRangeException(nameof(status)),
};
