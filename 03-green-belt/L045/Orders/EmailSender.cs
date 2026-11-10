namespace Shop.Orders;

public class EmailSender : IOrderObserver
{
    public void OnOrderPlaced(Order order) =>
        Console.WriteLine($"email: thanks {order.Customer}");
}
