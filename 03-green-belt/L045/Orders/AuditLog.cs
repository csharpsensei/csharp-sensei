namespace Shop.Orders;

public class AuditLog : IOrderObserver
{
    public void OnOrderPlaced(Order order) =>
        Console.WriteLine($"audit: order {order.Id}, {order.Total:0.00}");
}
