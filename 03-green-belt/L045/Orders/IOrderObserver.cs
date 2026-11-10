namespace Shop.Orders;

public interface IOrderObserver
{
    void OnOrderPlaced(Order order);
}
