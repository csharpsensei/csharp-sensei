Customer found = customersById[2];

if (customersById.TryGetValue(99, out Customer other))
{
    Console.WriteLine(other.Name);
}
else
{
    Console.WriteLine("no customer with that id");
}
