[Fact]
public void PlaceOrder_EmailsTheCustomer()
{
    var email = new FakeEmailSender();
    var service = new OrderService(
        new InMemoryOrderRepository(), email, new AlwaysApprovesGateway());

    service.PlaceOrder(new Order(42, "kenji@example.com", 99.00m));

    Assert.Single(email.Sent);
    Assert.Equal("kenji@example.com", email.Sent[0].To);
}
