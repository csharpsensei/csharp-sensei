public closed record OrderStatus;
public sealed record Packed : OrderStatus;
public sealed record Shipped(DateOnly On) : OrderStatus;

public static string Describe(OrderStatus status) => status switch
{
    Packed => "packed, waiting for the van",
    Shipped(var on) => $"shipped on {on:yyyy-MM-dd}",
};
