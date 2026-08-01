Dictionary<int, Customer> byId =
    new Dictionary<int, Customer>();

foreach (Customer customer in customers)
{
    byId[customer.Id] = customer;
}

foreach (Order order in orders)
{
    Customer customer = byId[order.CustomerId];
}
