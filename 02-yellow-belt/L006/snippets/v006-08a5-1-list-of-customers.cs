public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

List<Customer> customers = new List<Customer>();

customers.Add(new Customer { Id = 1, Name = "Aiko" });
customers.Add(new Customer { Id = 2, Name = "Ben" });
customers.Add(new Customer { Id = 3, Name = "Chidi" });
