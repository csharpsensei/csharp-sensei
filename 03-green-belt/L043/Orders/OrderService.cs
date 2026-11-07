namespace Shop.Orders;

public class OrderService(IOrderRepository orders, IEmailSender email)
{
    public void PlaceOrder(Order order)
    {
        orders.Save(order);
        email.Send(order.Customer, $"Order {order.Id} confirmed, total {order.Total}");
    }
}
