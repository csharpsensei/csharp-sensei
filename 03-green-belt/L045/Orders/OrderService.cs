namespace Shop.Orders;

public class OrderService
{
    private readonly List<IOrderObserver> observers = [];

    public void Subscribe(IOrderObserver observer) =>
        observers.Add(observer);

    public void Place(Order order)
    {
        Console.WriteLine($"order {order.Id} placed");
        foreach (var observer in observers)
            observer.OnOrderPlaced(order);
    }
}
