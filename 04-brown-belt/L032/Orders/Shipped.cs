namespace WhatsNew.Orders;

public sealed record Shipped(DateOnly On) : OrderStatus;
