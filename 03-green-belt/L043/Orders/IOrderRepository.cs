namespace Shop.Orders;

public interface IOrderRepository
{
    void Save(Order order);
}
