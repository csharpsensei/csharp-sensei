foreach (int id in customersById.Keys)
{
    Console.WriteLine(id);
}

List<int> ordered = customersById.Keys.ToList();
ordered.Sort();
