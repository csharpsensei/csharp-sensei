namespace Shop.Orders;

public class LoyaltyScheme : IOrderObserver
{
    public void OnOrderPlaced(Order order) =>
        Console.WriteLine($"loyalty: {order.Total:0} points");
}
