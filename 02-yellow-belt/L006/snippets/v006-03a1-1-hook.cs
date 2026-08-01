foreach (Order order in orders)
{
    foreach (Customer customer in customers)
    {
        if (customer.Id == order.CustomerId)
        {
            Console.WriteLine(customer.Name);
        }
    }
}
