namespace Shop.Orders;

public class Warehouse : IOrderObserver
{
    public void OnOrderPlaced(Order order) =>
        Console.WriteLine($"warehouse: pack order {order.Id}");
}
