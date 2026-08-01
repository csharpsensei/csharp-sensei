Customer customer = customersById[99];

if (customersById.TryGetValue(99, out Customer safe))
{
    Console.WriteLine(safe.Name);
}
