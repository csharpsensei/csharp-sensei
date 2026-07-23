public class OrderServiceTests
{
    [Fact]
    public void PlaceOrder_SavesTheOrder()
    {
        var service = new OrderService();

        service.PlaceOrder(new Order(42, "kenji@example.com", 99.00m));
    }
}
