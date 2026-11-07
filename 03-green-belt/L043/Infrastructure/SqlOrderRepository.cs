using Shop.Orders;

namespace Shop.Infrastructure;

public class SqlOrderRepository : IOrderRepository
{
    public void Save(Order order) =>
        Console.WriteLine($"SQL: saved order {order.Id}");
}
