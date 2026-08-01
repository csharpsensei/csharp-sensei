foreach (KeyValuePair<int, Customer> pair
         in customersById)
{
    Console.WriteLine(pair.Key + " " + pair.Value.Name);
}

foreach (int id in customersById.Keys)
{
    Console.WriteLine(id);
}
