Customer found = null;

foreach (Customer customer in customers)
{
    if (customer.Id == order.CustomerId)
    {
        found = customer;
        break;
    }
}
